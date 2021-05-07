using System.IO;
using NUnit.Framework;

namespace KataFootballChampionship.Test
{
    public class TeamsLoaderTest
    {
        [Test]
        public void test()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT1-teams.txt");
            TeamsLoader teamsloader = new TeamsLoader(path);
            
            int teams = teamsloader.Count();

            Assert.AreEqual(4, teams);
        }
    }
}