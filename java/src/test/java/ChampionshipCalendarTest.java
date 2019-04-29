import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class ChampionshipCalendarTest {

    /**
     * ### AT1: Having TeamA, TeamB, TeamC and TeamD teams, there will be 3 turns with 2 matches each
     */
    @Test
    public void AT1_Having4teamsShouldGenerate3TurnsWith2MatchesEach() {
        Team teamA = new Team("A");
        Team teamB = new Team("B");
        Team teamC = new Team("C");
        Team teamD = new Team("D");

        Match matchAB = new Match(teamA, teamB);
        Match matchCD = new Match(teamC, teamD);
        Turn turn1 = new Turn();
        turn1.add(matchAB);
        turn1.add(matchCD);

        Match matchAC = new Match(teamA, teamC);
        Match matchBD = new Match(teamB, teamD);
        Turn turn2 = new Turn();
        turn2.add(matchAC);
        turn2.add(matchBD);

        Match matchAD = new Match(teamA, teamD);
        Match matchBC = new Match(teamB, teamC);
        Turn turn3 = new Turn();
        turn3.add(matchAD);
        turn3.add(matchBC);

        Turns expectedTurns = new Turns();
        expectedTurns.add(turn1);
        expectedTurns.add(turn2);
        expectedTurns.add(turn3);


        ClassLoader classLoader = getClass().getClassLoader();
        TeamsFile teamsFile = new TeamsFile();
        Teams actualTeams = teamsFile.load(classLoader.getResource("teams.txt").getFile());

        ChampionshipCalendar calendar = new ChampionshipCalendar(actualTeams);
        Turns actualTurns = calendar.generate();

        assertTurnsEquals(expectedTurns, actualTurns, "Turns are different!");
    }

    private static void assertTurnsEquals(Turns expectedTurns, Turns actualTurns, String message){
        assertEquals(expectedTurns, actualTurns, message);
    }
}