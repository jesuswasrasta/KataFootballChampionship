using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataFootballChampionship.Core
{
    public class TurnSet : IEquatable<TurnSet>, IEnumerable
    {
        private readonly HashSet<Turn> _turns;

        public TurnSet()
        {
            _turns = new HashSet<Turn>();
        }

        public int Count => _turns.Count;

        public void Add(Turn turn)
        {
            _turns.Add(turn);
        }


        public bool Equals(TurnSet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _turns.SetEquals(other._turns);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TurnSet) obj);
        }

        public override int GetHashCode()
        {
            return (_turns != null ? _turns.GetHashCode() : 0);
        }

        public static bool operator ==(TurnSet left, TurnSet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TurnSet left, TurnSet right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var turn in _turns)
            {
                sb.Append($"{turn} | ");
            }

            return sb.ToString();
        }

        public bool Contains(Turn turn)
        {
            return _turns.Any(turn.Equals);
        }

        public IEnumerator GetEnumerator()
        {
            return _turns.GetEnumerator();
        }
    }
}