using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperCodingChallenge
{
    class MySolution : Processable<Tuple<List<int>, int>, int>
    {
        public int Process(Tuple<List<int>, int> input)
        {
            return CalculateKMaximum(input.Item1, input.Item2);
        }

        private int CalculateKMaximum(List<int> inputList, int k)
        {
            inputList.Sort();
            return inputList[inputList.Count - k];
        }
    }
}
