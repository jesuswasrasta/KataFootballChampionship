using System;
using System.Collections.Generic;
using System.IO;
using KataFootballChampionship.Core;
using NUnit.Framework;

namespace KataFootballChampionship.Test
{
    public class CalendarTestScenario2
    {
        ChampionshipCalendar _calendar;

        public CalendarTestScenario2()
        {
        }
        
        
        [Test]
        public void AT1_Scenario2()
        {            
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT1-teams.txt");
            var startingDate = new DateTime(2021,04,30);

            _calendar = new ChampionshipCalendar(new TeamsLoader(path));
            _calendar.SetStartingDate(startingDate);

            var at1Turns = GetAt1Turns(startingDate);
            
            var turns = _calendar.CalculateTurns();
            Assert.AreEqual(6, turns.Count);
            
            foreach (Turn turn in at1Turns)
            {
                Assert.That(turns.Contains(turn), $"turns.Contains({turn})");    
            }
        }

        private TurnSet GetAt1Turns(DateTime startingDate)
        {
            
            /*
             * (Team D - Team C)(Team B - Team A) |
             * (Team D - Team B)(Team C - Team A) |
             * (Team D - Team A)(Team C - Team B) |
             * (Team C - Team D)(Team A - Team B) |
             * (Team B - Team D)(Team A - Team C) |
             * (Team B - Team C)(Team A - Team D) | 
             */
            
            var at1Turns = new TurnSet();

            var turn1 = new Turn(startingDate);
            var match1 = new Match("Team D", "Team C");
            var match2 = new Match("Team B", "Team A");
            turn1.AddMatch(match1);
            turn1.AddMatch(match2);
            at1Turns.Add(turn1);
            
            var turn2 = new Turn(startingDate.AddDays(7));
            var match3 = new Match("Team D", "Team B");
            var match4 = new Match("Team C", "Team A");
            turn2.AddMatch(match3);
            turn2.AddMatch(match4);
            at1Turns.Add(turn2);
            
            var turn3 = new Turn(startingDate.AddDays(7));
            var match5 = new Match("Team D", "Team A");
            var match6 = new Match("Team C", "Team B");
            turn3.AddMatch(match5);
            turn3.AddMatch(match6);
            at1Turns.Add(turn3);
            
            var turn4 = new Turn(startingDate.AddDays(7));
            var match7 = new Match("Team C", "Team D");
            var match8 = new Match("Team A", "Team B");
            turn4.AddMatch(match7);
            turn4.AddMatch(match8);
            at1Turns.Add(turn4);
            
            var turn5 = new Turn(startingDate.AddDays(7));
            var match9 = new Match("Team B", "Team D");
            var match10 = new Match("Team A", "Team C");
            turn5.AddMatch(match9);
            turn5.AddMatch(match10);
            at1Turns.Add(turn5);
            
            var turn6 = new Turn(startingDate.AddDays(7));
            var match11 = new Match("Team B", "Team C");
            var match12 = new Match("Team A", "Team D");
            turn6.AddMatch(match11);
            turn6.AddMatch(match12);
            at1Turns.Add(turn6);

            return at1Turns;
        }
    }
}