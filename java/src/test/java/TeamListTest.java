import java.io.File;
import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertArrayEquals;

public class TeamListTest {

    @Test
    public void shouldLoadTeamsFromTextFile() {
        List<String> expectedTeams = new ArrayList<>();
        expectedTeams.add("A");
        expectedTeams.add("B");

        ClassLoader classLoader = getClass().getClassLoader();
        File file = new File(classLoader.getResource("teams.txt").getFile());

        TeamList teamList = new TeamList();
        List<String> actualTeams = teamList.load(file);

        assertArrayEquals(expectedTeams.toArray(), actualTeams.toArray(), "Team lists are different! ");
    }
}