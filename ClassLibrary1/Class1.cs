using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Person

    {
        public string Name;
        public int Score;
    }

    public class BowlingGame

    {
        public List<Person> PersonList = new List<Person>();
        public Person CurrentPlayer;

        public void StartGame(int numberOfPlayers)
        {
            
        }
    }

    public class Round

    {
        public int currentFrame;
        private int _personScore;
        private int _pins;

        public void Roll(int pins)
        {
            _pins += pins;
            _personScore += pins;
        }

        public int Score()
        {
            return _pins;
        }
        public int PersonScoreMethod()
        {
            return _personScore;
        }
    }
}
