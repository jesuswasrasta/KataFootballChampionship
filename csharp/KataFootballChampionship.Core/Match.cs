namespace KataFootballChampionship.Core
{
    public class Match
    {
        private readonly string t1;
        private readonly string t2;

        public Match(string t1, string t2)
        {            
            this.t1 = t1;
            this.t2 = t2;
        }

        public string GetT1()
        {
            return this.t1;
        }

        public string GetT2()
        {
            return this.t2;
        }
    }
}