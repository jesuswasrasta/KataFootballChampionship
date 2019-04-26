import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

public class Teams {
    private List<Team> teams;

    public Teams() {
        this.teams = new ArrayList<>();
    }

    public void add(Team team) {
        teams.add(team);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        Teams teams1 = (Teams) o;
        return teams.equals(teams1.teams);
    }

    @Override
    public int hashCode() {
        return Objects.hash(teams);
    }
}
