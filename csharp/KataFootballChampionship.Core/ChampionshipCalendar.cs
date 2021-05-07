using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KataFootballChampionship.Core
{
    /* Cosa ho fatto
     * 
     * - merge dei due rami feat1 e feat2
     * - rivisto algoritmo di generazione turni e match
     * - rivisto test AT1
     * 
     * - ho portato le implementazioni della gestione degli errori com'è, da discutere insieme
     *   - test AT4: non passa...
     * 
     *
     * Temi da discutere insieme
     * 
     * - rivediamo insieme scelte implementative; discussione
     * - facciamo passare AT4
     *
     * - discussione: come evitare "merge hell?"
     *   - limiti del versionamento: serve una maggiore disciplina nella strutturazione del codice
     *
     * -spunti:
     *  - CRC cards (Class-Responsibility-Collaboration cards, see: http://c2.com/doc/oopsla89/paper.html)
     *  - Port & Adapters (see: https://wiki.c2.com/?HexagonalArchitecture)
     *  - Domain vs Infrastructure ()
     *
     * TODO
     * - rivediamo qualche implementazione
     *   - separiamo file di test in piu file?
     * - evidenziamo collaboratori, separiamo codice
     * - sviluppiamo altre 2 feature in parallelo, vediamo se ci incartiamo ancora... :)
     */

    public enum EErrorType
    {
        NoValidInputFile,
        NotEnoghTeams
    }

    public class ChampionshipCalendar
    {
        private TurnSet _turns;
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

        public TurnSet CalculateTurns()
        {
            var matches = CalculateMatches();
            _turns = new TurnSet();
            var list = new List<int>(Enumerable.Range(1, 10));
            
            DateTime dateTurn = StartingDate;
            for (var i = matches.Count-1; i >= 0; i--)
            {
                var m1 = matches[i];
                Turn turn = new Turn(dateTurn);
                turn.AddMatch(m1);
                matches.Remove(m1);
                for (var j = matches.Count-1; j >= 0; j--)
                {
                    var m2 = matches[j];
                    if (!turn.ContainsTeam(m2))
                    {
                        turn.AddMatch(m2);
                        matches.Remove(m2);
                        i--;
                    }
                }

                dateTurn = dateTurn.AddDays(7);
                _turns.Add(turn);
            }

            return _turns;
        }
        
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        
        private List<Match> CalculateMatches()
        {
            var permutationElementsSize = 2;
            var result = GetPermutations(_teamsList, permutationElementsSize);

            var matches = new List<Match>();
            if (AreTeamsValid())
            {
                foreach (var list in result)
                {
                    var match = new Match(list.First(), list.Last());
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