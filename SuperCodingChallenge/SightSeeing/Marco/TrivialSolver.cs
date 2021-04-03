using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SightSeeing.Marco
{
    public class TrivialSolver : ISightSeeing
    {
        private int testCases;
        private int N, Ts, Tf;
        private int[,] cities;

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

                cities = new int[N - 1, 3];
                for (int j = 0; j < cities.GetLength(0); j++)
                {
                    cities[j, 0] = input[i + j + 1, 0];
                    cities[j, 1] = input[i + j + 1, 1];
                    cities[j, 2] = input[i + j + 1, 2];
                }
                result[resultIndex++] = VisitCity(0, 0);
            }

            return result;
        }

        private int VisitCity(int cityId, int currentTime)
        {
            if (cityId >= cities.GetLength(0) && currentTime <= Tf)
            {
                return 0;
            }
            else if (cityId >= cities.GetLength(0) || currentTime >= Tf)
            {
                return -1;
            }

            int waitingTime = cities[cityId, 0];

            if (waitingTime - Ts - currentTime >= 0)
            {
                int solution = VisitCity(cityId + 1, currentTime + waitingTime + cities[cityId, 2]);

                return solution >= 0 ? 1 + solution : solution;
            }
            else
            {
                //Do SightSeeing here
                while (waitingTime < (currentTime + Ts))
                {
                    waitingTime += cities[cityId, 1];
                }
                waitingTime -= (currentTime + Ts);
                int timeWithSS = currentTime + Ts + waitingTime + cities[cityId, 2];

                int visitedWithSSHere = -1;
                if (timeWithSS <= Tf)
                {
                    int solution = VisitCity(cityId + 1, timeWithSS);
                    visitedWithSSHere = solution >= 0 ? 1 + solution : solution;
                }

                //Dont SightSee here
                while (waitingTime < currentTime)
                {
                    waitingTime += cities[cityId, 1];
                }
                waitingTime -= currentTime;
                int visitedWithoutSSHere = VisitCity(cityId + 1, currentTime + waitingTime + cities[cityId, 2]);

                return Math.Max(visitedWithSSHere, visitedWithoutSSHere);
            }
        }
    }
}
