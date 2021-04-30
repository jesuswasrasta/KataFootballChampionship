using System.IO;
using KataFootballChampionship.Core;
using NUnit.Framework;

namespace KataFootballChampionship.Test
{
    public class TurnTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void turns_are_equal()
        {
            var turn1 = new Turn();
            turn1.AddMatch(new Match("a","b"));
            turn1.AddMatch(new Match("c","d"));
            
            var turn2 = new Turn();
            turn2.AddMatch(new Match("a","b"));
            turn2.AddMatch(new Match("c","d"));
            
            Assert.AreEqual(turn1, turn2);
        }

        [Test]
        public void turns_are_not_equal()
        {
            var turn1 = new Turn();
            turn1.AddMatch(new Match("a","b"));
            turn1.AddMatch(new Match("c","d"));
            
            var turn2 = new Turn();
            turn2.AddMatch(new Match("a","b"));
            turn2.AddMatch(new Match("d","c"));
            
            Assert.AreNotEqual(turn1, turn2);
        }
    }
}