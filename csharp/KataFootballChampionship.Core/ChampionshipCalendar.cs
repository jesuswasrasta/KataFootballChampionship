using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KataFootballChampionship.Core
{
    public class ChampionshipCalendar
    {
        private List<string> _teamsList;
        private string _outputResult;

        public void LoadTeams(string teamsTxt)
        {
            var teamsArray = File.ReadAllLines(teamsTxt);
            _teamsList = new List<string>(teamsArray);
        }

        public List<Turn> CalculateTurns()
        {
            List<Turn> turns = new List<Turn>();
            List<Match> matches = CalculateMatchs();
                            
            for (int i = 0; i < matches.Count; i++)
            {
                Turn turn=new Turn();
                turn.matches.Add(matches[i]);
                turn.matches.Add(matches[++i]);
                turns.Add(turn);
            }

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
            List<Match> matches = new List<Match>();
            const int minimumNumberOfTeams = 2;

            if (GetTeamsCount() >= minimumNumberOfTeams)
            {
                IEnumerable<IEnumerable<string>> result = GetPermutations(_teamsList, 2);

                foreach (var list in result)
                {
                    Match match = new Match(list.First(), list.Last());
                    matches.Add(match);
                }
            }
            else
                _outputResult = "Provide at least 2 teams!";
            
            return matches;
        }

        public string Print()
        {
            return _outputResult;
        }

        public int GetTeamsCount()
        {
            return _teamsList.Count();
        }
    }
}