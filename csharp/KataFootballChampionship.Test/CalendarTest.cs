using System.Collections.Generic;
using System.IO;
using KataFootballChampionship.Core;
using NUnit.Framework;

namespace KataFootballChampionship.Test
{
    public class CalendarTest
    {
        ChampionshipCalendar _calendar;

        [SetUp]
        public void Setup()
        {
            _calendar = new ChampionshipCalendar();
        }

        [Test]
        public void AT1_Having_TeamA_TeamB_TeamC_and_TeamD_teams_there_will_be_3_turns_with_2_matches_each()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT1-teams.txt");
            _calendar.LoadTeams(path);
            List<Match> matchs = _calendar.CalculateMatchs();

            Assert.AreEqual(12, matchs.Count);
            AssertMatches(matchs);
            Assert.That(matchs.Contains(new Match("Team A", "Team B")));
        }

        [Test]
        public void AT2_Having_only_TeamA_and_TeamB_there_will_be_only_a_turn_with_1_match()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT2-teams.txt");
            _calendar.LoadTeams(path);
            List<Match> matches = _calendar.CalculateMatchs();

            Assert.AreEqual(2, matches.Count);
            Assert.That(matches.Contains(new Match("Team A", "Team B")));
        }

        [Test]
        public void AT3_Having_only_TeamA_return_an_error()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT3-teams.txt");
            _calendar.LoadTeams(path);
            List<Match> matches = _calendar.CalculateMatchs();

            var matchResult = _calendar.Print();
            var numberOfTeams = _calendar.GetTeamsCount();

            Assert.AreEqual(numberOfTeams, 1);
            Assert.AreEqual(matchResult, "Provide at least 2 teams!");
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