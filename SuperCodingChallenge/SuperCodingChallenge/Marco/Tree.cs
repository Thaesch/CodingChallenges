using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCodingChallenge.Marco
{
    public class Tree
    {
        public int[] Heap { get; }

        private int lastIndex;

        public Tree(int[] numbers)
        {
            Heap = numbers;
            lastIndex = Heap.Length - 1;
            for(int i=Heap.Length-1;i>= 0; i--)
            {
                Heapify(i);
            }
        }

        public int ExtractMax()
        {
            if(lastIndex == 0)
            {
                return int.MinValue;
            }
            int value = Heap[0];
            Heap[0] = Heap[lastIndex];
            Heap[lastIndex--] = int.MinValue;
            Heapify(0);
            return value;
        }
        private void Heapify(int startIndex)
        {
            int left = GetLeftIndex(startIndex);
            int right = GetRightIndex(startIndex);
            int value = Heap[startIndex];

            int changeWith = startIndex;
            if(left < Heap.Length && Heap[left] > value)
            {
                changeWith = left;
            }
            if(right < Heap.Length && Heap[right] > Heap[changeWith])
            {
                changeWith = right;
            }
            if(changeWith != startIndex)
            {
                Heap[startIndex] = Heap[changeWith];
                Heap[changeWith] = value;
                Heapify(changeWith);
            }          
        }


        private int GetLeftIndex(int index)
        {
            return index * 2 + 1;
        }
        private int GetRightIndex(int index)
        {
            return index * 2 + 2;
        }
    }
}
