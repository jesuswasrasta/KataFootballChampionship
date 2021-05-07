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
    }
}
