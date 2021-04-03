//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SightSeeing.Marco
//{
//    public class TestSolution : ISightSeeing
//    {
//        private int testCases;
//        private int N, Ts, Tf;
//        private int[,] cities;

//        public int[] Process(int[,] input)
//        {
//            testCases = input[0, 0];

//            int[] result = new int[testCases];
//            int resultIndex = 0;
//            for (int i = 1; i < input.GetLength(0); i += N)
//            {
//                N = input[i, 0];
//                Ts = input[i, 1];
//                Tf = input[i, 2];

//                cities = new int[N-1, 3];
//                for (int j = 0; j < cities.GetLength(0); j++)
//                {
//                    cities[j, 0] = input[i + j + 1, 0];
//                    cities[j, 1] = input[i + j + 1, 1];
//                    cities[j, 2] = input[i + j + 1, 2];
//                }
//                result[resultIndex++] = ProcessTestCase();
//            }
//            return result;
//        }

//        private int ProcessTestCase()
//        {
//            //int[,] visitMap = new int[N, N];

//            int counter = 0;
//            for(int i = 0; i < N; i++)
//            {
                
//            }
//        }

//        private int CalculateNextBusTime(int currentTime, int a, int b)
//        {
//            //a*x + b
//            if (currentTime <= b)
//            {
//                return b;
//            }
//            int timeDiff = currentTime - b;
//            if (timeDiff % a == 0)
//            {
//                return currentTime;
//            }
//            // Next Bus Start
//            return timeDiff / a * a + a + b;
//        }
//    }
//}
