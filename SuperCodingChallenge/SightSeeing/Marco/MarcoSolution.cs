using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SightSeeing.Marco
{
    class MarcoSolution : IProcessable<int[,], int[]>
    {
        public int[] Process(int[,] input)
        {
            ISightSeeing solver = new TrivialSolver();

            return solver.Process(input);
        }
    }
}
