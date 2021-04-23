using System;
using System.Collections.Generic;

namespace KataFootballChampionship.Core
{
    public class Turn
    {
        public List<Match> matches;
        public Turn()
        {
            matches = new List<Match>();
        }

        public override bool Equals(object obj)
        {
            return obj is Turn turn &&
                   EqualityComparer<List<Match>>.Default.Equals(matches, turn.matches);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(matches);
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
    }
}