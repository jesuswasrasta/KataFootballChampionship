import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class TeamList {
    public List<String> load(File file) throws IOException {
        List<String> teams = new ArrayList<>();
        teams = Files.lines(file.toPath()).collect(Collectors.toList());
        return teams;
    }
}
