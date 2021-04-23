using System;

namespace KataFootballChampionship.Core
{
    public class Match
    {
        public readonly string t1;
        public readonly string t2;

        public Match(string t1, string t2)
        {            
            this.t1 = t1;
            this.t2 = t2;
        }

        public override bool Equals(object obj)
        {
            return obj is Match match &&
                   t1 == match.t1 &&
                   t2 == match.t2;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(t1, t2);
        }

        public override bool Equals(object obj)
        {
            return obj is Match match &&
                   t1 == match.t1 &&
                   t2 == match.t2;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(t1, t2);
        }
    }
}