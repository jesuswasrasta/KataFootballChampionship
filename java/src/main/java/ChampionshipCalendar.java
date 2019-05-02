import java.util.LinkedList;
import java.util.List;

public class ChampionshipCalendar {
    private final Teams teams;

    public ChampionshipCalendar(Teams teams) {
        this.teams = teams;
    }

    public Turns generate() {
        Turns turns = getCombinationForTeam(teams);
        return turns;
    }

    private Turns getCombinationForTeam(Teams teams) {
        Turns turns = new Turns();

        Teams tt = new Teams();
        tt.addAll(teams);

        List<Match> matches = new LinkedList<>();

        for (int i = 0; i < teams.size() - 1; i++) {
            Team first = teams.toArray()[i];
            for (int j = 0; j < tt.size() - 1; j++) {
                Match match = new Match(first, tt.toArray()[j + 1]);
                matches.add(match);
            }
            tt.remove(0);
        }

        int size = matches.size() > 2 ? matches.size() / 2 : matches.size();
        if (size == 1) {
            Turn turn = new Turn();
            Match firstMatch = matches.get(0);
            turn.add(firstMatch);
            turns.add(turn);
        } else {
            for (int i = 0; i < size; i++) {
                Turn turn = new Turn();
                Match firstMatch = matches.get(i);
                turn.add(firstMatch);
                Match secondMatch = matches.get(matches.size() - 1 - i);
                turn.add(secondMatch);
                turns.add(turn);
            }
        }

        return turns;
    }

    @Override
    public String toString() {
        return "ChampionshipCalendar{" +
                "teams=" + teams +
                '}';
    }
}
