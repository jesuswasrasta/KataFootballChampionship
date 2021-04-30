using System;
using System.Collections.Generic;

namespace KataFootballChampionship.Core
{
    public class Turn
    {
        //membro pubblico
        // vìolo incapsulamento
        // vìolo Legge di Demetra
        // possibile soluzione: "Tell, don't ask"
        private List<Match> matches;
        
        public Turn()
        {
            matches = new List<Match>();
        }
        
        public bool containsMatch(Match match)
        {
            return matches.Contains(match);
        }
        internal bool containsTeams(Match match)
        {
            return containsTeam(match.t1) || containsTeam(match.t2);            
        }

        public IEnumerable<Match> GetMatches()
        {
            return matches;
        }

        internal bool containsTeam(string team)
        {
            foreach (var match in matches)
            {
                if (match.t1 == team || match.t2 == team)
                    return true;
            }
            return false;
        }

        public void AddMatch(Match match)
        {
            matches.Add(match);
        }

        protected bool Equals(Turn other)
        {
            return Equals(matches, other.matches);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Turn)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(matches);
        }
        public override string ToString()
        {
            string turn="";
            foreach (var match in matches)
            {
                turn = turn + match.ToString() + Environment.NewLine;
            }
            return turn;
        }
    }
}