using System;
using System.Collections.Generic;
using System.IO;

namespace KataFootballChampionship.Test
{
    public class TeamsLoader : ITeamsLoader
    {
        private readonly List<string> _teamsList = new List<string>();

        public TeamsLoader(string path)
        {
            if(File.Exists(path))
                _teamsList = new List<string>(File.ReadAllLines(path));
        }

        public List<string> GetTeams()
        {
            return _teamsList;
        }
    }
}