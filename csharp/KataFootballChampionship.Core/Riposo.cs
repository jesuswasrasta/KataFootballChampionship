using System;

namespace KataFootballChampionship.Core
{
    public class Riposo
    {
        private string _teamDiRiposo = string.Empty;

        public Riposo()
        {
        }

        public Riposo(string teamDiRiposo)
        {
            _teamDiRiposo = teamDiRiposo;
        }

        internal bool AnyTeams()
        {
            return string.IsNullOrEmpty(_teamDiRiposo);
        }
    }
}