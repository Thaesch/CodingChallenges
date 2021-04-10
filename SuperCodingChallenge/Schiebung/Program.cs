using Schiebung.Marco;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiebung
{
    class Program
    {
        static Tuple<int[,], int> currentChallenge;
        static int[] currentSolution;
        static int[] processedSolution;
        static int numChallenges;
        static Random random;

        static Tuple<int[,], int>[] premadeChallenge;
        static int[][] premadeSolution;

        static void Main(string[] args)
        {
            ChallengeProcessor<Tuple<int[,], int>, int[]> processor = new ChallengeProcessor<Tuple<int[,], int>, int[]>(
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

            numChallenges = 1000000;
            random = new Random(6001);

            premadeChallenge = new Tuple<int[,], int>[7];
            premadeSolution = new int[7][];

            premadeChallenge[0] = new Tuple<int[,], int>(new int[3, 2] { { 3, 5 }, { 6, 2 }, { 7, 8 } }, 10);
            premadeChallenge[1] = new Tuple<int[,], int>(new int[3, 2] { { 3, 5 }, { 6, 2 }, { 7, 8 } }, 17);
            premadeChallenge[2] = new Tuple<int[,], int>(new int[3, 2] { { 3, 5 }, { 6, 2 }, { 7, 8 } }, 21);
            premadeChallenge[3] = new Tuple<int[,], int>(new int[2, 3] { { 1, 4, 5 }, { 2, 8, 3 } }, 1);
            premadeChallenge[4] = new Tuple<int[,], int>(new int[2, 3] { { 1, 4, 5 }, { 2, 8, 3 } }, 3);
            premadeChallenge[5] = new Tuple<int[,], int>(new int[2, 3] { { 1, 4, 5 }, { 2, 8, 3 } }, 7);
            premadeChallenge[6] = new Tuple<int[,], int>(new int[2, 3] { { 1, 4, 5 }, { 2, 8, 3 } }, 20);

            premadeSolution[0] = new int[3] {0, 1, 0};
            premadeSolution[1] = new int[3] {0, 0, 1};
            premadeSolution[2] = new int[3] {0, 1, 0};
            premadeSolution[3] = new int[2] {0, 0};
            premadeSolution[4] = new int[2] {0, 0};
            premadeSolution[5] = new int[2] {0, 1};
            premadeSolution[6] = new int[2] {1, 0};

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

            int elapsedSeconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
            long elapsedMillis = stopwatch.ElapsedMilliseconds % 1000;
            int averageElapsedSeconds = (int)((stopwatch.ElapsedMilliseconds / (double)numChallenges) / 1000);
            double averageElapsedMillis = (stopwatch.ElapsedMilliseconds / (double)numChallenges) % 1000;

            Print("Completed in: " + elapsedSeconds + " seconds and " + elapsedMillis + " milliseconds");
            Print("Average process in: " + averageElapsedSeconds + " seconds and " + averageElapsedMillis + " milliseconds");
            Print("Correct Answers: " + numCorrect);
            Print("Incorrect Answers: " + numFalse);

            Console.WriteLine("Press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static string StringArray(int[] arrayToString)
        {
            string s = "";
            for (int i = 0; i < arrayToString.Length; i++)
            {
                s += arrayToString[i] + " ";
            }
            return s;
        }

        private static bool CompareSolutions(int[] currentSolution, int[] processedSolution)
        {
            if (currentSolution.Length != processedSolution.Length) return false;
            for (int i = 0; i < currentSolution.Length; i++)
            {
                if (currentSolution[i] != processedSolution[i])
                    return false;
            }
            return true;
        }

        private static void PopulateChallenge(int currentChallengeIndex)
        {
            currentChallenge = premadeChallenge[Math.Min(premadeChallenge.Length - 1, currentChallengeIndex)];
            currentSolution = premadeSolution[Math.Min(premadeSolution.Length - 1, currentChallengeIndex)];
        }


        public static void Print(object message)
        {
            Console.WriteLine(message);
        }

    }
}
