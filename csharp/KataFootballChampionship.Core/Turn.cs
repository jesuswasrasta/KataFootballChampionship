using System;
using System.Collections.Generic;
using System.Text;

namespace KataFootballChampionship.Core
{
    public class Turn : IEquatable<Turn>
    {
        private readonly HashSet<Match> _matches;
        private Riposo _riposo = new Riposo();        
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

        public void AddByeTeam(Riposo byeteam)
        {
            _riposo = byeteam;
        }

        public bool Equals(Turn other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (!_riposo.Equals(other._riposo)) return false;
            //TODO: uguaglianza tiene conto anche della data --> return Equals(_matches, other._matches) && startDate.Equals(other.startDate);
            return _matches.SetEquals(other._matches);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Turn) obj);
        }

        public override int GetHashCode()
        {
            //TODO: hash tiene conto anche della data --> return HashCode.Combine(_matches, startDate);
            return HashCode.Combine(_matches, _riposo);
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
            stringBuilder.Append(_riposo);

            return stringBuilder.ToString();
        }
    }
}