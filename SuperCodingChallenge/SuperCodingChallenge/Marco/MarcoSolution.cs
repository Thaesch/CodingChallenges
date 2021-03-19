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

        public int Process(Tuple<List<int>, int> input)
        {
            if(input.Item1.Count == 0)
            {
                return -1000;
            }

            k = input.Item2;
            numbers = input.Item1.ToArray();



            return 0;
        }
    }
}
