using System;
using System.Collections.Generic;

namespace ConsoleAppForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
        List<int> _rolls = new List<int>(21);
        List<int> _frames = new List<int>(10);

            for (int i = 0; i < 6; i++)
            {
                _frames.Add(0);
            }

            int score = 0;

            _rolls.Add(5);
            _rolls.Add(5);
            _rolls.Add(5);
            _rolls.Add(5);
            _rolls.Add(1);
            _rolls.Add(1);


            int frameCounter = 0;

            for (int i = 0; i < _rolls.Count-1; i += 2)
            {
                if (_rolls[i] == 10)
                {
                    Console.Write("Strike!");
                    _frames[frameCounter] = (_rolls[i] + _rolls[i + 1] + _rolls[i + 2]);
                }
                else
                {
                    _frames[frameCounter] = (_rolls[i] + _rolls[i + 1]);
                }

                Console.Write("Frame: "+frameCounter+" ");
                Console.Write(" = "+ _frames[frameCounter]);
                Console.Write(" points.\n");
                frameCounter++;
            }

            Console.WriteLine("\n_frames list:");

            foreach(var item in _frames)
            {
                Console.WriteLine(item);
            }

            /*
            for (int i = 0; i < _rolls.Count+1; i++)
            {
                if(_frames[i] == _frames.Count)
                _frames[i] += _rolls[i] + _rolls[i+1];

                if (i % 2 == 0)
                {
                    Console.WriteLine("Varannat värde: "+_rolls[i]);
                }
            }

    */
            Console.WriteLine("\n_rolls list:");
            foreach (var item in _rolls)
            {
                
                Console.WriteLine(item);
                score += item;
            }

            Console.WriteLine("Total score from all rolls: " +score);

            score = 0;
            foreach (var item in _frames)
            {

                score += item;
            }

            Console.WriteLine("Total score from all frames: " + score);


            Console.WriteLine("Frame 0: "+_frames[0]);

        }
    }
}
