using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiebung.Marco
{
    public interface ISchiebung
    {
        int[] Process(Tuple<int[,], int> input);
    }
}
