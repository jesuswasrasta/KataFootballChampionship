import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class TeamsFile {
    public Teams load(String fullname) {
        Teams teams = new Teams();

        Scanner scanner = null;
        try {
            scanner = new Scanner(new File(fullname));
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        while (scanner.hasNextLine()) {
            String line = scanner.nextLine();
            Team team = new Team(line);
            teams.add(team);
        }

        return teams;
    }
}
