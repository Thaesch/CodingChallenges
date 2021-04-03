using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SightSeeing.Marco
{
    class RecursiveSolution : ISightSeeing
    {
        private int testCases;
        private int N, Ts, Tf;
        private int[,] cities;

        private int[] nextBusStart;

        public int[] Process(int[,] input)
        {
            testCases = input[0, 0];

            int[] result = new int[testCases];
            int resultIndex = 0;
            for (int i = 1; i < input.GetLength(0); i += N)
            {
                N = input[i, 0];
                Ts = input[i, 1];
                Tf = input[i, 2];
                nextBusStart = new int[N - 1];

                cities = new int[N - 1, 3];
                for (int j = 0; j < cities.GetLength(0); j++)
                {
                    cities[j, 0] = input[i + j + 1, 0];
                    nextBusStart[j] = cities[j, 0];
                    cities[j, 1] = input[i + j + 1, 1];
                    cities[j, 2] = input[i + j + 1, 2];
                }

                result[resultIndex++] = VisitCity(0,0);
            }

            return result;
        }

        private int VisitCity(int city, int time)
        {
            if (city >= cities.GetLength(0) && time <= Tf)
            {
                return 0;
            }
            else if (city >= cities.GetLength(0) || time >= Tf)
            {
                return -1;
            }

            int waitingTime = cities[city, 0];

            if (waitingTime - Ts - time >= 0)
            {
                int solution = VisitCity(city + 1, time + waitingTime + cities[city, 2]);

                return solution >= 0 ? 1 + solution : solution;
            }
            else
            {
                //Do SightSeeing here               
                int timeWithSS = CalculateNextBusTime(time + Ts,cities[city,1], cities[city, 0]) + cities[city, 2];

                int visitedWithSSHere = -1;
                if (timeWithSS <= Tf)
                {
                    int solution = VisitCity(city + 1, timeWithSS);
                    visitedWithSSHere = solution >= 0 ? 1 + solution : solution;
                }

                //Dont SightSee here
                int timeNoSS = CalculateNextBusTime(time,cities[city,1], cities[city, 0]) + cities[city, 2];
                int visitedWithoutSSHere = VisitCity(city + 1, timeNoSS);

                return Math.Max(visitedWithSSHere, visitedWithoutSSHere);
            }
        }
        private int CalculateNextBusTime(int currentTime, int a, int b)
        {
            //a*x + b
            if(currentTime <= b)
            {
                return b;
            }
            int timeDiff = currentTime - b;
            if(timeDiff % a == 0)
            {
                return currentTime;
            }
            // Next Bus Start
            return timeDiff / a * a + a + b;
        }
    }
}
