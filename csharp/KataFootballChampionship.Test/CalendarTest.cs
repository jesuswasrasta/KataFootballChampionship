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
        

            //Team A - Team D
            //Team B - Team C
        }
        [Test]
        public void AT3_Having_only_TeamA_return_an_error()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S1-AT3-teams.txt");
            _calendar.LoadTeams(path);
            List<Match> matches = _calendar.CalculateMatchs();

            string matchResult = _calendar.Print();
            int numberOfTeams = _calendar.GetTeamsCount();

            Assert.AreEqual(numberOfTeams, 1);
            Assert.AreEqual(matchResult, "Provide at least 2 teams!");
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
        TurnsList turns = calendar.CalculateTurns();

        Assert.AreEqual(6, turns.Count());
        AssertTurns(turns);

        //Team A - Team B
        //Team C - Team D

        //Team A - Team C
        //Team B - Team D

        //Team A - Team D
        //Team B - Team C
    }

    private void AssertTurns(TurnsList turns)
    {
        Turn turn1 = new Turn();
        turn1.AddMatch(new Match("Team A", "Team B"));
        turn1.AddMatch(new Match("Team C", "Team D"));

        Assert.That(turns.containsTurn(turn1));

        Turn turn2 = new Turn();
        turn2.AddMatch(new Match("Team A", "Team C"));
        turn2.AddMatch(new Match("Team B", "Team D"));

        Assert.That(turns.containsTurn(turn2));

        Turn turn3 = new Turn();
        turn3.AddMatch(new Match("Team A", "Team D"));
        turn3.AddMatch(new Match("Team B", "Team C"));

        Assert.That(turns.containsTurn(turn3));

        Turn turn4 = new Turn();
        turn4.AddMatch(new Match("Team B", "Team A"));
        turn4.AddMatch(new Match("Team D", "Team C"));

        Assert.That(turns.containsTurn(turn4));

        Turn turn5 = new Turn();
        turn5.AddMatch(new Match("Team C", "Team A"));
        turn5.AddMatch(new Match("Team D", "Team B"));

        Assert.That(turns.containsTurn(turn5));

        Turn turn6 = new Turn();
        turn6.AddMatch(new Match("Team C", "Team B"));
        turn6.AddMatch(new Match("Team D", "Team A"));

        Assert.That(turns.containsTurn(turn6));
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
        [Test]
        public void AT5_Having_no_input_file_return_an_error()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "sò_lillo.txt");
            _calendar.LoadTeams(path);
            List<Match> matches = _calendar.CalculateMatchs();

            string matchResult = _calendar.Print();
            int numberOfTeams = _calendar.GetTeamsCount();

            Assert.AreEqual(numberOfTeams, 0);
            Assert.AreEqual(matchResult, "Provide a valid input file!");
        }        
    }
}