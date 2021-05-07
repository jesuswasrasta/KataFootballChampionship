using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace KataFootballChampionship.Test
{
    public class TeamsLoaderTest
    {
        [Test]
        public void Given_file_with_4_lines_should_return_list_with_4_teams()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT1-teams.txt");
            TeamsLoader teamsloader = new TeamsLoader(path);
            
            List<string> teams = teamsloader.GetTeams();

            Assert.AreEqual(4, teams.Count);
        }
    }
}