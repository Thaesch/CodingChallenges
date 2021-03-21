using SuperCodingChallenge.Tom;
using System;
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

        static Tuple<List<int>, int> currentChallenge;
        static int currentSolution;
        static int processedSolution;
        static int numChallenges;
        static Random random;

        static void Main(string[] args)
        {
            ChallengeProcessor<Tuple<List<int>, int>, int> processor = new ChallengeProcessor<Tuple<List<int>, int>, int>(
            ///ToDo: Set your own Solution Here:
                new TomSolution()
                //new SortSolution()
                // Uncomment all other solutions
                );


            // ###################################################
            // ###################################################
            // ########### Ignore everything else! ###############
            // ###################################################
            // ###################################################

            
            numChallenges = 100000;

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

                if (currentSolution == processedSolution)
                {
                    numCorrect++;
                }
                else
                {
                    Print("Solution " + (i + 1) + ": " + currentSolution + " your answer: " + processedSolution);
                    numFalse++;
                }
            }

            Print("Completed in: " + stopwatch.ElapsedMilliseconds + " milliseconds");
            Print("Average process in: " + (stopwatch.ElapsedMilliseconds / (double)numChallenges) + " milliseconds");
            Print("Correct Answers: " + numCorrect);
            Print("Incorrect Answers: " + numFalse);

            Console.WriteLine("Press 'Enter' to exit...");
            Console.ReadLine();
        }


        private static void PopulateChallenge(int numChallenge)
        {
            currentChallenge = new Tuple<List<int>, int>(new List<int>(), random.Next(1, (Math.Min(numChallenges, 1500) + 1)));
            for (int l = 0; l < Math.Min(numChallenges, 1500); l++)
            {
                currentChallenge.Item1.Add(random.Next(-250, 251));
            }
            currentSolution = CalculateKthMaximum(currentChallenge.Item1, currentChallenge.Item2);
        }

        private static int CalculateKthMaximum(List<int> input, int k)
        {
            List<int> tempList = new List<int>(input);
            if (tempList.Count == 0) return -1000;
            tempList.Sort();

            if (k > tempList.Count)
                return tempList[0];
            else
                return tempList[tempList.Count - k];
        }

        public static void Print(object message)
        {
            Console.WriteLine(message);
        }


    }
}
