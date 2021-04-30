using System.Collections.Generic;
using System.IO;
using KataFootballChampionship.Core;
using NUnit.Framework;

namespace KataFootballChampionship.Test
{
    public class CalendarTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AT1_Having_TeamA_TeamB_TeamC_and_TeamD_teams_there_will_be_3_turns_with_2_matches_each()
        {
            ChampionshipCalendar calendar = new ChampionshipCalendar();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT1-teams.txt");
            calendar.LoadTeams(path);
            List<Match> matchs = calendar.CalculateMatchs();

            Assert.AreEqual(12, matchs.Count);
            AssertMatches(matchs);

            Assert.That(matchs.Contains(new Match("Team A", "Team B")));
        }

        [Test]
        public void AT2_Having_only_TeamA_and_TeamB_there_will_be_only_a_turn_with_1_match()
        {
            ChampionshipCalendar calendar = new ChampionshipCalendar();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT2-teams.txt");
            calendar.LoadTeams(path);
            List<Match> matches = calendar.CalculateMatchs();

            Assert.AreEqual(2, matches.Count);
            Assert.That(matches.Contains(new Match("Team A", "Team B")));
        }
        private void AssertMatches(List<Match> turns)
        {
            foreach (var element in turns)
            {
                Assert.AreNotEqual(element.t1, element.t2);
            }
        }
    }
}