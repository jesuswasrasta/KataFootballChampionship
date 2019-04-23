import java.io.File;
import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertArrayEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class TeamListTest {

    @Test
    public void shouldLoadTeamsFromTextFile() throws InvalidFileException {
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
        String message = "Expected load() to throw MissingFileException, but it didn't";

        assertThrows(MissingFileException.class, () -> teamList.load(file), message);
    }

    @Test
    void shouldThrowAnExceptionIfFileIsEmpty() {
        ClassLoader classLoader = getClass().getClassLoader();
        File file = new File(classLoader.getResource("empty.txt").getFile());

        TeamList teamList = new TeamList();
        String message = "Expected load() to throw EmptyFileException, but it didn't";

        assertThrows(EmptyFileException.class, () -> teamList.load(file), message);
    }

    @Test
    void shouldThrowAnExceptionIfFileContainsOnlyOneLine() {
        ClassLoader classLoader = getClass().getClassLoader();
        File file = new File(classLoader.getResource("only-one-team.txt").getFile());

        TeamList teamList = new TeamList();
        String message = "Expected load() to throw InvalidFileException, but it didn't";

        assertThrows(InvalidFileException.class, () -> teamList.load(file), message);
    }
}