using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klammerung
{
    class ChallengeProcessor<T,V>
    {

        private IProcessable<T, V> toProcess;

        public ChallengeProcessor(IProcessable<T, V> toProcess)
        {
            this.toProcess = toProcess;
        }


        public V Process(T input)
        {
            return toProcess.Process(input);
        }


    }
}
