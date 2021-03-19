﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCodingChallenge
{
    class Program
    {

        // Find k-tes Maximum

        static Tuple<List<int>, int>[] currentChallenge;
        static int[] currentSolutions;
        static int[] processedSolutions;
        static int numChallenges;
        static Random random;

        static void Main(string[] args)
        {
            ChallengeProcessor<Tuple<List<int>, int>, int> processor = new ChallengeProcessor<Tuple<List<int>, int>, int>(
            ///ToDo: Set your own Solution Here:
                new MySolution()
                // Uncomment all other solutions
                );


            // ###################################################
            // ###################################################
            // ########### Ignore everything else! ###############
            // ###################################################
            // ###################################################


            numChallenges = 10000;

            currentChallenge = new Tuple<List<int>, int>[numChallenges];
            currentSolutions = new int[numChallenges];
            processedSolutions = new int[numChallenges];

            random = new Random();

            PopulateChallenge();


            int numCorrect = 0;
            int numFalse = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numChallenges; i++)
            {
                processedSolutions[i] = processor.Process(
                    new Tuple<List<int>, int>
                    (new List<int>(currentChallenge[i].Item1), currentChallenge[i].Item2)
                    );
            }

            stopwatch.Stop();

            for (int i = 0; i < numChallenges; i++)
            {
                if(currentSolutions[i] == processedSolutions[i])
                {
                    numCorrect++;
                }
                else
                {
                    Print("Solution " + (i + 1) + ": " + currentSolutions[i] + " your answer: " + processedSolutions[i]);
                    numFalse++;
                }
            }

            Print("Completed in: " + stopwatch.ElapsedMilliseconds + " milliseconds");
            Print("Correct Answers: " + numCorrect);
            Print("Incorrect Answers: " + numFalse);

            Console.WriteLine("Press 'Enter' to exit...");
            Console.ReadLine();
        }


        private static void PopulateChallenge()
        {
            for (int i = 0; i < numChallenges; i++)
            {

                currentChallenge[i] = new Tuple<List<int>, int>(new List<int>(), random.Next(1, 50));
                for (int l = 0; l < currentChallenge[i].Item2 + random.Next(0, 5000); l++)
                {
                    currentChallenge[i].Item1.Add(random.Next(-250,251));
                }
                currentSolutions[i] = CalculateKthMaximum(currentChallenge[i].Item1, currentChallenge[i].Item2);
            }
        }

        private static int CalculateKthMaximum(List<int> input, int k)
        {
            List<int> tempList = new List<int>(input);
            tempList.Sort();
            return tempList[tempList.Count - k];
        }

        public static void Print(object message)
        {
            Console.WriteLine(message);
        }


    }
}