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
        public void Having_TeamA_TeamB_TeamC_and_TeamD_teams_there_will_be_3_turns_with_2_matches_each()
        {
            /* ## Scenario 1: Basic calendar generation
               Given a list of teams,
               as a ChampionshipManager
               I want to generate a list of matches
                
               ### AT1: Having TeamA, TeamB, TeamC and TeamD teams, there will be 3 turns with 2 matches each
                * Load the list of team from a text file, one team per row.
                * generate turns with matches (only one match between each teams)
                * print turns and matches to the video (console)
              
             */
            ChampionshipCalendar calendar = new ChampionshipCalendar();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT1-teams.txt");
            calendar.LoadTeams(path);
            List<Turn> turns = calendar.CalculateTurns();
            
            Assert.AreEqual(6, turns.Count);
            AssertTurns(turns);
            
            //Team A - Team B
            //Team C - Team D

            //Team A - Team C
            //Team B - Team D

            //Team A - Team D
            //Team B - Team C
        }

        private void AssertTurns(List<Turn> turns)
        {
            Turn turn1 = new Turn();
            turn1.matches.Add(new Match("Team A", "Team B"));
            turn1.matches.Add(new Match("Team C", "Team D"));
            Assert.That(turns.Contains(turn1));

            Turn turn2 = new Turn();
            turn2.matches.Add(new Match("Team A", "Team C"));
            turn2.matches.Add(new Match("Team B", "Team D"));

            Assert.That(turns.Contains(turn2));
        }

        [Test]
        public void Generazione_match()
        {
            /* ## Scenario 1: Basic calendar generation
               Given a list of teams,
               as a ChampionshipManager
               I want to generate a list of matches
                
               ### AT1: Having TeamA, TeamB, TeamC and TeamD teams, there will be 3 turns with 2 matches each
                * Load the list of team from a text file, one team per row.
                * generate turns with matches (only one match between each teams)
                * print turns and matches to the video (console)
              
             */
            ChampionshipCalendar calendar = new ChampionshipCalendar();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT1-teams.txt");
            calendar.LoadTeams(path);
            List<Match> matchs = calendar.CalculateMatchs();

            Assert.AreEqual(12, matchs.Count);
            AssertMatches(matchs);

            Assert.That(matchs.Contains(new Match("Team A", "Team B")));
            
            //Team A - Team B
            //Team C - Team D

            //Team A - Team C
            //Team B - Team D

            //Team A - Team D
            //Team B - Team C
        }


        //My assertion utils
        private void AssertMatches(List<Match> turns)
        {
            foreach (var element in turns)
            {
                Assert.AreNotEqual(element.t1, element.t2);
            }
        }
    }
}