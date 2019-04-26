import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

public class Turn {
    private List<Match> matches;

    public Turn() {
        matches = new ArrayList<>();
    }

    public void add(Match match) {
        matches.add(match);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        Turn turn = (Turn) o;
        return matches.equals(turn.matches);
    }

    @Override
    public int hashCode() {
        return Objects.hash(matches);
    }

    @Override
    public String toString() {
        return "Turn{" +
                "matches=" + matches +
                '}';
    }
}
