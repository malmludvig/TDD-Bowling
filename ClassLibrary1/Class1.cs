using System;

namespace ClassLibrary1
{
    public class Person

    {
        public string Name;
        public int Score;
    }

    public class Round

    {

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

        public bool ScoreZero(int pinsKnockedDown)
        {
            if (pinsKnockedDown < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
