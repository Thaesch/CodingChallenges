using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SightSeeing.Marco
{
    public class MatrixSolution : ISightSeeing
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
             
                cities = new int[N, 3];
                for (int j = 1; j < cities.GetLength(0); j++)
                {
                    cities[j, 0] = input[i + j, 0];
                    cities[j, 1] = input[i + j, 1];
                    cities[j, 2] = input[i + j, 2];
                }

                int[,] dp = new int[N + 1, N + 1];
                dp[1, 0] = 0;
                for(int j = 2;j <= N; j++)
                {
                    for(int k = 0; k < j; k++)
                    {
                        int min = Tf + 1;
                        if(k > 0)
                        {
                            min = Math.Min(ceil(dp[j - 1, k - 1] + Ts, cities[j - 1, 0], cities[j - 1, 1]) + cities[j - 1, 2], min);
                        }
                        if (k < j - 1)
                        {
                            min = Math.Min(ceil(dp[j - 1, k], cities[j - 1, 0], cities[j - 1, 1]) + cities[j - 1, 2], min);
                        }
                        dp[j, k] = min;
                    }
                }
                int sightSeeing = -1;
                for(int j=N-1;j>= 0; j--)
                {
                    if(dp[N,j] <= Tf)
                    {
                        sightSeeing = j;
                        break;
                    }
                }
                result[resultIndex] = sightSeeing;
                resultIndex++;
            }
            return result;
        }

        private int ceil(int x, int a, int b)
        {
            // a+b*n
            if (x <= a)
            {
                return a;
            }
            int y = x - a;
            if (y % b == 0)
            {
                return x;
            }
            int result = a + y / b * b + b;
            return result;
        }
    }
}
