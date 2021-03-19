using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCodingChallenge
{
    interface IProcessable<T, V>
    {
        V Process(T input);
    }
}
