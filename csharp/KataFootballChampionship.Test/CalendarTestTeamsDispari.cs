using KataFootballChampionship.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFootballChampionship.Test
{
    public class CalendarTestTeamsDispari
    {
        ChampionshipCalendar _calendar;

        [SetUp]
        public void Setup()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S3-TeamDispari.txt");
            _calendar = new ChampionshipCalendar(new TeamsLoader(path));
        }
            [Test]
        public void AT3_Having_TeamA_TeamB_TeamC__there_will_be_Match_A_B_with_C_in_bye()
        {          
            var turns = _calendar.CalculateTurnsWithOdd();

            Assert.AreEqual(6, turns.Count);

            var turn1 = new Turn();
            var match1 = new Match("Team A", "Team B");
            turn1.AddMatch(match1);
            turn1.AddByeTeam(new Riposo("Team C"));

            Assert.That(turns.Contains(turn1));
        }
        
        [Test]
        public void Test_difference_between_turnlist_with2_1()
        {
            TeamList teamList1 = new TeamList();
            teamList1.AddTeams("Team A");
            teamList1.AddTeams("Team B");

            TeamList teamList2 = new TeamList();
            teamList2.AddTeams("Team A");

            Assert.AreEqual(teamList1.GetByeTeam(teamList2), "Team B");
        }

        [Test]
        public void Test_difference_between_turnlist_with2teams()
        {
            TeamList teamList1 = new TeamList();
            teamList1.AddTeams("Team A");
            teamList1.AddTeams("Team B");

            TeamList teamList2 = new TeamList();
            teamList2.AddTeams("Team A");
            teamList2.AddTeams("Team B");

            Assert.AreEqual(teamList1.GetByeTeam(teamList2), "");
        }
        [Test]
        public void Test_difference_between_turnlist_with3_2()
        {
            TeamList teamList1 = new TeamList();
            teamList1.AddTeams("Team A");
            teamList1.AddTeams("Team B");
            teamList1.AddTeams("Team C");

            TeamList teamList2 = new TeamList();
            teamList2.AddTeams("Team A");
            teamList2.AddTeams("Team B");

            Assert.AreEqual(teamList1.GetByeTeam(teamList2), "Team C");
        }


    }
}
