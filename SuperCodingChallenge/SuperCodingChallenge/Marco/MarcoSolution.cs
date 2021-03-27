using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCodingChallenge.Marco
{
    public class MarcoSolution : IProcessable<Tuple<List<int>, int>, int>
    {
        private int k;
        private int[] numbers;

        bool treeSolution = false;

        public int Process(Tuple<List<int>, int> input)
        {
            if (input.Item1.Count == 0)
            {
                return -1000;
            }

            int result = 0;
            if (treeSolution)
            {
                k = input.Item2;
                numbers = input.Item1.ToArray();

                Tree numbersHeap = new Tree(numbers);
                for(int i = k-1; i >= 0; i--)
                {
                    int number = numbersHeap.ExtractMax();
                    if(number == int.MinValue)
                    {
                        break;
                    }
                    result = number;
                }
            }
            else
            {
                IKthMaxSolution solver = new InsertionSortSolution();
                result = solver.Solve(input.Item1, input.Item2);
            }


            return result;
        }
    }
}
