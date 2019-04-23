import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class TeamList {
    public List<String> load(File file) throws InvalidFileException {
        List<String> teams = new ArrayList<>();

        if (!file.exists()) {
            throw new MissingFileException(String.format("File %s is missing!", file.getAbsolutePath()));
        }

        try {
            teams = Files.lines(file.toPath()).collect(Collectors.toList());
            if (teams.isEmpty()){
                throw new EmptyFileException("File is empty!");
            }
            if (teams.size() == 1){
                throw new InvalidFileException("File contains only 1 team!");
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return teams;
    }
}
