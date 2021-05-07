using KataFootballChampionship.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace KataFootballChampionship.Test
{
    public class TeamsLoader : ITeamsLoader
    {
        private readonly TeamList _teamsList = new TeamList();

        public TeamsLoader(string path)
        {
            if(File.Exists(path))
                _teamsList = new TeamList(File.ReadAllLines(path));
        }

        public TeamList GetTeams()
        {
            return _teamsList;
        }
    }
}