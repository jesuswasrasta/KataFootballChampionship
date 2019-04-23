import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class TeamListTest {

    @Test
    public void shouldLoadTeamsFromTextFile() {
        List<String> expectedTeams = new ArrayList<>();
        expectedTeams.add("A");
        expectedTeams.add("B");

        TeamList teamList = new TeamList();
        List<String> actualTeams = teamList.load("teams.txt");
        assertArrayEquals(expectedTeams.toArray(), actualTeams.toArray(), "Team lists are different! ");
    }
}