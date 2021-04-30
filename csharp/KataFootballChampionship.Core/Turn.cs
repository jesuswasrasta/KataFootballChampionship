using System;
using System.Collections.Generic;
using System.Text;

namespace KataFootballChampionship.Core
{
    public class Turn : IEquatable<Turn>
    {
        private readonly HashSet<Match> _matches;
        private DateTime startDate;

        public Turn()
        {
            _matches = new HashSet<Match>();
            this.startDate = new DateTime();
        }
        
        public Turn(DateTime startDate)
        {
            this.startDate = startDate;
            _matches = new HashSet<Match>();
        }
        
        public void AddMatch(Match match)
        {
            _matches.Add(match);
        }

       
        public bool containsMatch(Match match)
        {
            return _matches.Contains(match);
        }
        

        public IEnumerable<Match> GetMatches()
        {
            return _matches;
        }

        public bool ContainsTeam(Match match)
        {
            foreach (var m in _matches)
            {
                if (m.ContainsTeam(match.Team1) || m.ContainsTeam(match.Team2))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Equals(Turn? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _matches.SetEquals(other._matches);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Turn) obj);
        }

        public override int GetHashCode()
        {
            return (_matches != null ? _matches.GetHashCode() : 0);
        }
        
        public static bool operator ==(Turn left, Turn right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Turn left, Turn right)
        {
            return !Equals(left, right);
        }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var match in _matches)
            {
                stringBuilder.Append($"({match})");
            }

            return stringBuilder.ToString();
        }
    }
}