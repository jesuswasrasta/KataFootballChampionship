import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

class TeamsFileTest {
    @Test
    void shouldLoadTeamsFromExistingFile() {
        Team teamA = new Team("A");
        Team teamB = new Team("B");
        Team teamC = new Team("C");
        Team teamD = new Team("D");
        Teams expectedTeams = new Teams();
        expectedTeams.add(teamA);
        expectedTeams.add(teamB);
        expectedTeams.add(teamC);
        expectedTeams.add(teamD);

        ClassLoader classLoader = getClass().getClassLoader();
        TeamsFile teamsFile = new TeamsFile();
        Teams actualTeams = teamsFile.load(classLoader.getResource("teams.txt").getFile());

        assertEquals(expectedTeams, actualTeams);
    }
}