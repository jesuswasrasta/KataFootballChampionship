import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class TeamsFile {
    public Teams load(String fullname) {
        File file = new File(fullname);

        if (!file.exists()){
            throw new TeamFileException("Provide a valid input file!");
        }

        Teams teams = new Teams();
        Scanner scanner = null;
        try {
            scanner = new Scanner(file);
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
