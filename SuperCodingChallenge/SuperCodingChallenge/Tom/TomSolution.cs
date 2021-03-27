using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperCodingChallenge
{
    class TomSolution : IProcessable<Tuple<List<int>, int>, int>
    {
        public int Process(Tuple<List<int>, int> input)
        {
            return CalculateKMaximum(input.Item1, input.Item2);
        }

        private int CalculateKMaximum(List<int> inputList, int k)
        {
            if (inputList.Count == 0) return -1000;
            if (k > inputList.Count) return inputList[0];

            int minimum = inputList[0];
            int maximum = minimum;
            for (int i = 0; i< inputList.Count; i++)
            {
                if (inputList[i] < minimum)
                    minimum = inputList[i];
                if (inputList[i] > maximum)
                    maximum = inputList[i];
            }

            int[] countingSort = new int[maximum - minimum + 1];
            int[] lookup = new int[maximum - minimum + 1];

            for (int i = 0; i < inputList.Count; i++)
            {
                countingSort[inputList[i] - minimum] = inputList[i];
                lookup[inputList[i] - minimum]++;
            }
            int counter = 0;
            for(int index = 1; index <= countingSort.Length; index++)
            {
                counter += lookup[countingSort.Length - index];
                if(counter >= k)
                {
                    return countingSort[countingSort.Length - index];
                }
            }
            return countingSort[0];
        }



    }
}
