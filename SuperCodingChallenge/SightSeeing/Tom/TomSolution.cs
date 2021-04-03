using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SightSeeing.Tom
{
    class TomSolution : IProcessable<int[,], int[]>
    {

        private int numTasks;

        private int currentNumCities;
        private int currentVisitTime;
        private int currentArriveTime;

        private int[,] currentCityData;


        public int[] Process(int[,] input)
        {
            int currentLine = 1;
            int currentTask = 0;
            numTasks = input[0, 0];
            int[] currentSolutions = new int[numTasks];
            while (currentTask < numTasks)
            {
                currentNumCities = input[currentLine, 0];
                currentVisitTime = input[currentLine, 1];
                currentArriveTime = input[currentLine, 2];
                currentCityData = new int[currentNumCities, 3];

                int[] waitTimes = new int[currentNumCities];
                for(int cityIndex = 0; cityIndex < currentNumCities - 1; cityIndex++)
                {
                    currentCityData[cityIndex, 0] = input[currentLine + 1 + cityIndex, 0];
                    currentCityData[cityIndex, 1] = input[currentLine + 1 + cityIndex, 1];
                    currentCityData[cityIndex, 2] = input[currentLine + 1 + cityIndex, 2];

                    FillWaitTimes(cityIndex, currentCityData[cityIndex, 2], currentVisitTime, ref waitTimes);
                }

                currentSolutions[currentTask] = -1;
                for(int i = currentNumCities - 1; i >= 0; i--)
                {
                    //Console.WriteLine(i + ": " + waitTimes[i] + "!");
                    if (waitTimes[i] <= currentArriveTime)
                    {
                        currentSolutions[currentTask] = i;
                        break;
                    }
                }
                //Console.WriteLine();

                currentTask++;
                currentLine = currentLine + currentNumCities;
            }

            return currentSolutions;
        }

        private void FillWaitTimes(int cityIndex, int busTravelTime, int currentVisitTime, ref int[] waitTimes)
        {
            if (cityIndex == 0)
            {

                int nextMinBus = FindLowestBus(0, cityIndex);
                int nextTravelBus = FindLowestBus(currentVisitTime, cityIndex);
                waitTimes[0] = nextMinBus + busTravelTime;
                waitTimes[1] = nextTravelBus + busTravelTime;
                //Console.WriteLine(0 + "; " + nextMinBus);
                //Console.WriteLine(0 + "+ " + nextTravelBus);
            }
            else
            {
                for (int i = cityIndex; i >= 0; i--)
                {
                    int nextMinBus = FindLowestBus(waitTimes[i], cityIndex);
                    int nextTravelBus = FindLowestBus(waitTimes[i] + currentVisitTime, cityIndex);
                    //Console.WriteLine(i + "; " + nextMinBus);
                    //Console.WriteLine(i + "+ " + nextTravelBus);
                    if (waitTimes[i + 1] != 0)
                    {
                        waitTimes[i + 1] = Math.Min(nextTravelBus + busTravelTime, waitTimes[i + 1]);
                    }
                    else
                    {
                        waitTimes[i + 1] = nextTravelBus + busTravelTime;
                    }

                    waitTimes[i] = nextMinBus + busTravelTime;
                }
                //for(int i2 = 0; i2 <= cityIndex + 1; i2++)
                //{
                //    Console.Write(waitTimes[i2] + " ");
                //}
                //Console.WriteLine();
            }
        }

        private int FindLowestBus(int minTime, int cityIndex)
        {
            int nextTime = -1;
            int mult = 0;
            while(nextTime < minTime)
            {
                nextTime = 
                    currentCityData[cityIndex, 0] +
                    mult * currentCityData[cityIndex, 1];
                mult++;
            }
            return nextTime;
        }
    }
}
