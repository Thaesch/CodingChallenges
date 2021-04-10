using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiebung.Marco
{
    public class MarcoSolution : IProcessable<Tuple<int[,], int>, int[]>
    {
        public int[] Process(Tuple<int[,], int> input)
        {
            ISchiebung solver = new TrivialSolver();

            return solver.Process(input);
        }
    }
}
