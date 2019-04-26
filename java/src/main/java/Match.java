import java.util.Objects;

public class Match {
    private final Team home;
    private final Team visitor;

    public Match(Team home, Team visitor) {
        this.home = home;
        this.visitor = visitor;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        Match match = (Match) o;
        return home.equals(match.home) &&
                visitor.equals(match.visitor);
    }

    @Override
    public int hashCode() {
        return Objects.hash(home, visitor);
    }

    @Override
    public String toString() {
        return "Match{" +
                "home=" + home +
                ", visitor=" + visitor +
                '}';
    }
}
