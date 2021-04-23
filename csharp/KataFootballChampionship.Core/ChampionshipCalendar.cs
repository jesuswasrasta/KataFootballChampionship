using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KataFootballChampionship.Core
{
    public class ChampionshipCalendar
    {
        private List<string> _teamsList;

        public void LoadTeams(string teamsTxt)
        {
            var teamsArray = File.ReadAllLines(teamsTxt);
            _teamsList = new List<string>(teamsArray);
        }

        public List<Turn> CalculateTurns()
        {
            List<Turn> turns = new List<Turn>();

            List<Match> matches = CalculateMatchs();

            do
            {
                Turn turn = new Turn();
                foreach (var match in matches)
                {
                    if(turn.containsTeam(match.t1) && turn.containsTeam(match.t2))
                    { 
                        turn.matches.Add(match);
                        matches.Remove(match);
                    }
                }
            }
            while (matches.Count != 0);

            //TODO: creare i Turn con i Match

            return turns;
        }
        
        
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public List<Match> CalculateMatchs()
        {
            IEnumerable<IEnumerable<string>> result = GetPermutations(_teamsList, 2);

            List<Match> matches = new List<Match>();
            foreach (var list in result)
            {
                Match match = new Match(list.First(), list.Last());

                matches.Add(match);

            }
            return matches;
        }
    }
}