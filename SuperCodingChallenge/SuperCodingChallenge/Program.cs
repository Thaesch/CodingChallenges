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

        static Tuple<List<int>, int>[] currentChallenge;
        static int[] currentSolutions;
        static int[] processedSolutions;
        static int numChallenges;
        static Random random;

        static void Main(string[] args)
        {
            ChallengeProcessor<Tuple<List<int>, int>, int> processor = new ChallengeProcessor<Tuple<List<int>, int>, int>(
            ///ToDo: Set your own Solution Here:
                new TomSolution()
                // Uncomment all other solutions
                );


            // ###################################################
            // ###################################################
            // ########### Ignore everything else! ###############
            // ###################################################
            // ###################################################

            
            numChallenges = 100000;

            currentChallenge = new Tuple<List<int>, int>[numChallenges];
            currentSolutions = new int[numChallenges];
            processedSolutions = new int[numChallenges];

            random = new Random(6001);
            PopulateChallenge();


            int numCorrect = 0;
            int numFalse = 0;


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numChallenges; i++)
            {
                processedSolutions[i] = processor.Process(currentChallenge[i]);
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
            Print("Average process in: " + (stopwatch.ElapsedMilliseconds / (double)numChallenges) + " milliseconds");
            Print("Correct Answers: " + numCorrect);
            Print("Incorrect Answers: " + numFalse);

            Console.WriteLine("Press 'Enter' to exit...");
            Console.ReadLine();
        }


        private static void PopulateChallenge()
        {
            for (int i = 0; i < numChallenges; i++)
            {

                currentChallenge[i] = new Tuple<List<int>, int>(new List<int>(), random.Next(1, (Math.Min(numChallenges, 1500) + 1)));
                for (int l = 0; l < Math.Min(numChallenges, 1500); l++)
                {
                    currentChallenge[i].Item1.Add(random.Next(-250,251));
                }
                currentSolutions[i] = CalculateKthMaximum(currentChallenge[i].Item1, currentChallenge[i].Item2);
            }
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
