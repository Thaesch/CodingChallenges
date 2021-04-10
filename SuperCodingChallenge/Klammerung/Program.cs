using Klammerung.Marco;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klammerung
{
    class Program
    {
        static string currentChallenge;
        static string expectedSolution;
        static string actualSolution;
        static int numChallenges;
        static Random random;

        static string[] premadeChallenge;
        static string[] premadeSolution;

        static void Main(string[] args)
        {
            ChallengeProcessor<string, string> processor = new ChallengeProcessor<string, string>(
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

            premadeChallenge = new string[1];
            premadeSolution = new string[1];

            premadeChallenge[0] = "A AND B OR !(C OR D) => F";

            premadeSolution[0] = "((((A) AND (B)) OR (!(((C) OR (D))))) => (F))";

            int numCorrect = 0;
            int numFalse = 0;


            Stopwatch stopwatch = new Stopwatch();
            Print("Processing...");
            for (int i = 0; i < numChallenges; i++)
            {
                PopulateChallenge(i);
                stopwatch.Start();
                actualSolution = processor.Process(currentChallenge);
                stopwatch.Stop();

                if (CompareSolutions(expectedSolution, actualSolution))
                {
                    numCorrect++;
                }
                else
                {
                    numFalse++;
                    Print($"Solution {(i + 1)}: {expectedSolution} your answer: {actualSolution}");
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
        private static bool CompareSolutions(string actualSolution, string expectedSolution)
        {
            int i = 0;
            int j = 0;
            while(i < actualSolution.Length && j < expectedSolution.Length)
            {
                if(actualSolution[i] == ' ')
                {
                    i++;
                    continue;
                }
                if(expectedSolution[j] == ' ')
                {
                    j++;
                    continue;
                }
                if (actualSolution[i] != expectedSolution[j])
                {
                    return false;
                }
                i++;
                j++;
            }
            return i == actualSolution.Length && j == expectedSolution.Length;
        }

        private static void PopulateChallenge(int currentChallengeIndex)
        {
            currentChallenge = premadeChallenge[Math.Min(premadeChallenge.Length - 1, currentChallengeIndex)];
            expectedSolution = premadeSolution[Math.Min(premadeSolution.Length - 1, currentChallengeIndex)];
        }


        public static void Print(object message)
        {
            Console.WriteLine(message);
        }

    }
}
