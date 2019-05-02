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

        for (int i = 0; i < teams.size()-1; i++) {
            Team first = teams.toArray()[i];
            for (int j = 0; j < tt.size()-1; j++) {
                Match match = new Match(first, tt.toArray()[j + 1]);
                matches.add(match);
            }
            tt.remove(0);
        }

        for (int i = 0; i < matches.size()/2; i++) {
            Turn turn = new Turn();
            turn.add(matches.get(i));
            turn.add(matches.get(matches.size()-1-i));
            turns.add(turn);
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
