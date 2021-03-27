using SightSeeing.Marco;
using SightSeeing.Tom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SightSeeing
{
    class Program
    { 

        static int[,] currentChallenge;
        static int[] currentSolution;
        static int[] processedSolution;
        static int numChallenges;
        static Random random;

        static int[][,] premadeChallenge;
        static int[][] premadeSolution;

        static void Main(string[] args)
        {
            premadeChallenge = new int[1][,];
            premadeChallenge[0] = new int[,]
            { 
               {4,0,0},
                {4  ,3  ,12},
                {3  ,2  ,1},
                {6  ,2  ,2},
                {1  ,3  ,2},
                {3  ,2  ,30},
                {1  ,2  ,27},
                {3  ,2  ,1},
                {4  ,1  ,11},
                {2  ,1  ,2},
                {4  ,1  ,5},
                {8  ,2  ,2},
                {5  ,10 ,5000},
                {14 ,27 ,31},
                {27 ,11 ,44},
                {30 ,8  ,20},
                {2000, 4000, 3}
            };
            premadeSolution = new int[1][];
            premadeSolution[0] = new int[4]
            {
                2,
                0,
                -1,
                4
            };


            ChallengeProcessor<int[,], int[]> processor = new ChallengeProcessor<int[,], int[]>(
                ///ToDo: Set your own Solution Here:
                // Uncomment all other solutions
                new MarcoSolution()
                //new TomSolution()
                );


            // ###################################################
            // ###################################################
            // ########### Ignore everything else! ###############
            // ###################################################
            // ###################################################


            numChallenges = 1;

            random = new Random(6001);

            int numCorrect = 0;
            int numFalse = 0;


            Stopwatch stopwatch = new Stopwatch();
            Print("Processing...");
            for (int i = 0; i < numChallenges; i++)
            {
                PopulateChallenge(i);
                stopwatch.Start();
                processedSolution = processor.Process(currentChallenge);
                stopwatch.Stop();

                if (CompareSolutions(currentSolution, processedSolution))
                {
                    numCorrect++;
                }
                else
                {
                    numFalse++;
                    Print("Solution " + (i + 1) + ": " + StringArray(currentSolution) + " your answer: " + StringArray(processedSolution));
                }
            }

            Print("Completed in: " + stopwatch.ElapsedMilliseconds + " milliseconds");
            Print("Average process in: " + (stopwatch.ElapsedMilliseconds / (double)numChallenges) + " milliseconds");
            Print("Correct Answers: " + numCorrect);
            Print("Incorrect Answers: " + numFalse);

            Console.WriteLine("Press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static string StringArray(int[] arrayToString)
        {
            string s = "";
            for(int i = 0; i < arrayToString.Length; i++)
            {
                s += arrayToString[i] + " ";
            }
            return s;
        }

        private static bool CompareSolutions(int[] currentSolution, int[] processedSolution)
        {
            if (currentSolution.Length != processedSolution.Length) return false;
            for(int i = 0; i < currentSolution.Length; i++)
            {
                if (currentSolution[i] != processedSolution[i])
                    return false;
            }
            return true;
        }

        private static void PopulateChallenge(int currentChallengeIndex)
        {
            currentChallenge = premadeChallenge[currentChallengeIndex];
            currentSolution = premadeSolution[currentChallengeIndex];
        }


        public static void Print(object message)
        {
            Console.WriteLine(message);
        }

    }
}
