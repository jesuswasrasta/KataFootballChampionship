using System.Collections;
using System.Collections.Generic;

namespace KataFootballChampionship.Core
{
    public class TurnsList
    {
        List<Turn> turnList = new List<Turn>();

        public TurnsList()
        {
        }

        public TurnsList(List<Turn> turnList)
        {
            this.turnList = turnList;
        }

        public void AddTurn(Turn turn)
        {
            turnList.Add(turn);
        }

        public bool containsTurn(Turn turn)
        {
            foreach (var t in turnList)
            {
                if (t.ToString() == turn.ToString())
                    return true;
            }
            return false;
        }

        public double Count()
        {
            return turnList.Count;
        }
    }
}