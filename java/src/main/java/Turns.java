import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Objects;

public class Turns {
    private List<Turn> turns;

    public Turns() {
        this.turns = new ArrayList<>();
    }

    public void add(Turn turn) {
        turns.add(turn);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        Turns turns1 = (Turns) o;
        return turns.equals(turns1.turns);
    }

    @Override
    public int hashCode() {
        return Objects.hash(turns);
    }

    @Override
    public String toString() {
        return "Turns{" +
                "turns=" + turns +
                '}';
    }

    public void addAll(Turns turns) {
        this.turns.addAll(turns.toList());
    }

    private List<Turn> toList() {
        return this.turns;
    }
}
