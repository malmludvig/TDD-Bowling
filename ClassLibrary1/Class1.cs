using System;
using System.Collections.Generic;

namespace ClassLibrary1
{

    public class Person

    {
        public string Name;
        public int Score;
    }

    public class BowlingGameWithPeople

    {
        public List<Person> PersonList = new List<Person>();
        public Person CurrentPlayer;

        public List<Person> StartGame(int numberOfPlayers)
        {
            var myList = PersonList;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                var newPerson = new Person();

                if (i == 0)
                    {
                    newPerson.Name = "Peter";
                    CurrentPlayer = newPerson;
                    }

                if (i == 1)
                    newPerson.Name = "Jonas";

                if (i == 2)
                    newPerson.Name = "Erik";

                if (i == 3)
                    newPerson.Name = "Magnus";

                myList.Add(newPerson);
            }

            return myList;
        }

        public void PrintPlayerNamesAndScores(List<Person> PersonList)

        {
            foreach (var person in PersonList)
                
            {
            Console.WriteLine("Name of player: " + person.Name + " Score of player: "+ person.Score);
            }  
        }
    }


    public class BowlingGame
    {
        private int[] rolls = new int[21];
        private int[] frame = new int[10];
        int currentRoll = 0;
        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public void Roll(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                rolls[currentRoll++] = pins[i];
            }
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isSpare(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else if (isStrike(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
                    frameIndex++;
                }
                else
                {
                    score += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }

            }

            return score;
        }
    }
}