public class ChampionshipCalendar {
    private final Teams teams;

    public ChampionshipCalendar(Teams teams) {
        this.teams = teams;
    }

    public Turns generate() {
        Teams teamsList = new Teams();
        teamsList.addAll(teams);

        Turns turns = new Turns();
        turns.addAll(getTurns(teamsList));
        System.out.println("1: " + turns);

        Teams teamsList2 = new Teams();
        teamsList2.addAll(teamsList);
        shift(teamsList2, 1);
        Turns turns2 = getTurns(teamsList2);
        System.out.println("2: " + turns2);
        turns.addAll(turns2);

        Teams teamsList3 = new Teams();
        teamsList3.addAll(teamsList2);
        swap(teamsList3, 3);
        Turns turns3 = getTurns(teamsList3);
        System.out.println("3: " + turns3);
        turns.addAll(turns3);

        return turns;
    }

    private Teams shift(Teams teams, int shift) {
        if (teams.size() == 0) {
            return teams;
        }

        Team team;
        for (int i = 0; i < shift; i++) {
            team = teams.remove(teams.size() - 1);
            teams.add(0, team);
        }

        return teams;
    }

    private Teams swap(Teams teams, int swap) {
        if (teams.size() == 0) {
            return teams;
        }

        for (int i = swap; i < teams.size(); i += swap) {
            int firstIndex = i - swap;
            Team first = teams.toArray()[firstIndex];

            int secondIndex = firstIndex + swap;
            Team second = teams.toArray()[secondIndex];

            teams.remove(firstIndex);
            teams.add(firstIndex, second);

            teams.remove(secondIndex);
            teams.add(secondIndex, first);
        }

        return teams;
    }

    private Turns getTurns(Teams teamsList) {
        Turns turns = new Turns();

        Turn turn = new Turn();

        Team[] a = teamsList.toArray();
        for (int i = 0; i < a.length; i += 2) {
            Match match = new Match(a[i], a[i + 1]);
            turn.add(match);
        }

        turns.add(turn);
        return turns;
    }

    @Override
    public String toString() {
        return "ChampionshipCalendar{" +
                "teams=" + teams +
                '}';
    }
}
