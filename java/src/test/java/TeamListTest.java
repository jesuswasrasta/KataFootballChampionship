import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.assertArrayEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

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

    @Test
    void shouldThrowAnExceptionIfFileDoesNotExist() {
        File file = new File("this-file-does-not-exists.txt");

        TeamList teamList = new TeamList();
        String message = "Expected load() to throw FileNotFoundException, but it didn't";

        FileNotFoundException thrown =  assertThrows(FileNotFoundException.class, () -> teamList.load(file), message);
        assertTrue(thrown.getMessage().contains("File does not exists! Verify name and path."));
    }
}