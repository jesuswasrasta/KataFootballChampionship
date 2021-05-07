using System;
using System.Collections.Generic;
using System.IO;
using KataFootballChampionship.Core;
using NUnit.Framework;

namespace KataFootballChampionship.Test
{
    public class CalendarTest
    {
        ChampionshipCalendar _calendar;

        TurnSet AT1_Turns;
        
        [SetUp]
        public void Setup()
        {
            _calendar = new ChampionshipCalendar();

            /*
             * (Team D - Team C)(Team B - Team A) |
             * (Team D - Team B)(Team C - Team A) |
             * (Team D - Team A)(Team C - Team B) |
             * (Team C - Team D)(Team A - Team B) |
             * (Team B - Team D)(Team A - Team C) |
             * (Team B - Team C)(Team A - Team D) | 
             */
            
            AT1_Turns = new TurnSet();

            var turn1 = new Turn();
            var match1 = new Match("Team D", "Team C");
            var match2 = new Match("Team B", "Team A");
            turn1.AddMatch(match1);
            turn1.AddMatch(match2);
            AT1_Turns.Add(turn1);
            
            var turn2 = new Turn();
            var match3 = new Match("Team D", "Team B");
            var match4 = new Match("Team C", "Team A");
            turn2.AddMatch(match3);
            turn2.AddMatch(match4);
            AT1_Turns.Add(turn2);
            
            var turn3 = new Turn();
            var match5 = new Match("Team D", "Team A");
            var match6 = new Match("Team C", "Team B");
            turn3.AddMatch(match5);
            turn3.AddMatch(match6);
            AT1_Turns.Add(turn3);
            
            var turn4 = new Turn();
            var match7 = new Match("Team C", "Team D");
            var match8 = new Match("Team A", "Team B");
            turn4.AddMatch(match7);
            turn4.AddMatch(match8);
            AT1_Turns.Add(turn4);
            
            var turn5 = new Turn();
            var match9 = new Match("Team B", "Team D");
            var match10 = new Match("Team A", "Team C");
            turn5.AddMatch(match9);
            turn5.AddMatch(match10);
            AT1_Turns.Add(turn5);
            
            var turn6 = new Turn();
            var match11 = new Match("Team B", "Team C");
            var match12 = new Match("Team A", "Team D");
            turn6.AddMatch(match11);
            turn6.AddMatch(match12);
            AT1_Turns.Add(turn6); 
        }


        [Test]
        public void AT1_Having_TeamA_TeamB_TeamC_and_TeamD_teams_there_will_be_6_turns_with_2_matches_each()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT1-teams.txt");
            _calendar.LoadTeams(path);
            var turns = _calendar.CalculateTurns();

            Assert.AreEqual(6, turns.Count);
            
            foreach (Turn turn in AT1_Turns)
            {
                Assert.That(turns.Contains(turn), $"turns.Contains({turn})");    
            }
        }
        
        
        [Test]
        public void AT2_Having_only_TeamA_and_TeamB_there_will_be_only_a_turn_with_1_match()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT2-teams.txt");
            _calendar.LoadTeams(path);
            var turns = _calendar.CalculateTurns();

            Assert.AreEqual(2, turns.Count);
            
            var turn1 = new Turn();
            turn1.AddMatch(new Match("Team A", "Team B"));

            var turn2 = new Turn();
            turn2.AddMatch(new Match("Team B", "Team A"));
            
            Assert.That(turns.Contains(turn1));
            Assert.That(turns.Contains(turn2));
        }

        [Test]
        public void AT3_Having_only_TeamA_return_an_error()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT3-teams.txt");
            _calendar.LoadTeams(path);
            var turns = _calendar.CalculateTurns();

            string matchResult = _calendar.Print();
            int numberOfTeams = _calendar.GetTeamsCount();

            Assert.AreEqual(numberOfTeams, 1);
            Assert.AreEqual(matchResult, "Provide at least 2 teams!");
        }
        
        [Test]
        public void AT4_Having_no_teams_return_an_error()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT4-teams.txt");
            _calendar.LoadTeams(path);
            var turns = _calendar.CalculateTurns();

            string matchResult = _calendar.Print();
            int numberOfTeams = _calendar.GetTeamsCount();

            Assert.AreEqual(numberOfTeams, 0);
            Assert.AreEqual(matchResult, "Provide at least 2 teams!");
        }

        [Test]
        public void AT5_Having_no_input_file_return_an_error()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "sò_lillo.txt");
            _calendar.LoadTeams(path);
            var turns = _calendar.CalculateTurns();

            string matchResult = _calendar.Print();
            int numberOfTeams = _calendar.GetTeamsCount();

            Assert.AreEqual(numberOfTeams, 0);
            Assert.AreEqual(matchResult, "Provide a valid input file!");
        }
    }
}