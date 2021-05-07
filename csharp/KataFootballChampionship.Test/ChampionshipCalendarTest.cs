using System.IO;
using KataFootballChampionship.Core;
using NUnit.Framework;

namespace KataFootballChampionship.Test
{
    public class ChampionshipCalendarTest
    {
        [Test]
        public void championship_calendar_uses_teamsloader()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT1-teams.txt");
            var teamsLoader = new TeamsLoader(path);
            
            var calendar = new ChampionshipCalendar(teamsLoader);
            
            var teamsCount = calendar.GetTeamsCount();
            Assert.Equals(4, teamsCount);
        }
    }
}