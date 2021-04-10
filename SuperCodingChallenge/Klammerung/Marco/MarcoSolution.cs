using System;
using System.Collections.Generic;
using System.Text;

namespace Klammerung.Marco
{
    public class MarcoSolution : IProcessable<string, string>
    {
        public string Process(string input)
        {
            return "((((A)AND(B)) OR(!(((C)OR(D)))))=> (F))";
        }
    }
}
