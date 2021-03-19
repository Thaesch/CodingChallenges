using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperCodingChallenge
{
    class TomSolution : Processable<Tuple<List<int>, int>, int>
    {
        public int Process(Tuple<List<int>, int> input)
        {
            return CalculateKMaximum(input.Item1, input.Item2);
        }

        private int CalculateKMaximum(List<int> inputList, int k)
        {
            if (k > inputList.Count) return 0;
            inputList.Sort();
            return inputList[inputList.Count - k];
        }
    }
}
