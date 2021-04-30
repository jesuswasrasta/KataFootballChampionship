using System;

namespace KataFootballChampionship.Core
{
    public class Match : IEquatable<Match>
    {
        public readonly string Team1;
        public readonly string Team2;

        public Match(string team1, string team2)
        {            
            Team1 = team1;
            Team2 = team2;
        }

        public bool Equals(Match other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Team1 == other.Team1 && Team2 == other.Team2;
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Match) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Team1, Team2);
        }
        
        public static bool operator ==(Match left, Match right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Match left, Match right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return Team1 + " - " + Team2;
        }

        public bool ContainsTeam(string team)
        {
            return (Team1.Equals(team) || Team2.Equals(team));
        }
    }
}