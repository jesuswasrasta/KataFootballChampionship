using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFootballChampionship.Core
{
    public class TeamList : IEnumerable<string>
    {
        private List<string> _teamsList = new List<string>();        

        public TeamList()
        {

        }

        public TeamList(string[] teams)
        {
            _teamsList.AddRange(teams);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _teamsList.GetEnumerator();
        }

        public int GetCount()
        {
            return _teamsList.Count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _teamsList.GetEnumerator();
        }

        public void AddTeams(string team)
        {
            _teamsList.Add(team);
        }
        public void AddTeamsMatch(Match team)
        {
            AddTeams(team.Team1);
            AddTeams(team.Team2);
        }

        public string GetByeTeam(TeamList teamsInGame)
        {
            string teamBye = "";
            var differences = _teamsList.Except(teamsInGame._teamsList).ToList();            
            if (differences.Count > 0)
                teamBye = differences[0];
            return teamBye;
        }
    }
}
