using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KataFootballChampionship.Core
{
    public enum EErrorType
    {
        NoValidInputFile,
        NotEnoghTeams
    }
    public class ChampionshipCalendar
    {
        private List<string> _teamsList = new List<string>();
        private string _outputResult;
        private DateTime StartingDate;

        private bool AreTeamsValid()
        {
            if(GetTeamsCount() == (int)EErrorType.NoValidInputFile)
            {
                _outputResult = "Provide a valid input file!";
                return false;
            }

            if (GetTeamsCount() == (int)EErrorType.NotEnoghTeams)
            {
                _outputResult = "Provide at least 2 teams!";
                return false;
            }

            return true;
        }

        public void LoadTeams(string teamsTxt)
        {
            try
            {
                var teamsArray = File.ReadAllLines(teamsTxt);
                _teamsList = new List<string>(teamsArray);
            }
            catch(Exception e)
            {
                _outputResult = e.Message;
            }
        }
        
        public TurnsList CalculateTurns()
        {
            TurnsList turns = new TurnsList();

            List<Match> matches = CalculateMatchs();
            List<Match> matchesRemove = new List<Match>();

            DateTime dateTurn = StartingDate;
            do
            {
                Turn turn = new Turn(dateTurn);
                foreach (var match in matches)
                {
                    if (!turn.containsTeams(match) && !matchesRemove.Contains(match))              
                    {
                        turn.AddMatch(match);
                        matchesRemove.Add(match);
                    }
                }
                turns.AddTurn(turn);
                dateTurn = dateTurn.AddDays(7);
            }
            while (matches.Count != matchesRemove.Count);
           
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

            if (AreTeamsValid())
            {
                IEnumerable<IEnumerable<string>> result = GetPermutations(_teamsList, 2);

                foreach (var list in result)
                {
                    Match match = new Match(list.First(), list.Last());
                    matches.Add(match);
                }
            }   
            
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

        public void SetStartingDate(DateTime startingDate)
        {
            this.StartingDate = startingDate;
        }
    }
}