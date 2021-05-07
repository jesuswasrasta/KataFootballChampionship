using System;
using System.Collections.Generic;
using System.IO;

namespace KataFootballChampionship.Test
{
    public class TeamsLoader
    {
        private readonly List<string> _teamsList;

        public TeamsLoader(string path)
        {
            _teamsList = new List<string>(File.ReadAllLines(path));
        }

        public int Count()
        {
            return 4;
        }

        public List<string> GetTeams()
        {
            throw new NotImplementedException();
        }
    }
}