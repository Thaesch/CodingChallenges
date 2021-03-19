using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCodingChallenge
{
    class ChallengeProcessor<T,V>
    {

        private Processable<T, V> toProcess;

        public ChallengeProcessor(Processable<T, V> toProcess)
        {
            this.toProcess = toProcess;
        }


        public V Process(T input)
        {
            return toProcess.Process(input);
        }


    }
}
