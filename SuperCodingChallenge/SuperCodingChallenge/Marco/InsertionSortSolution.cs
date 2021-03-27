using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCodingChallenge.Marco
{
    public class InsertionSortSolution : IKthMaxSolution
    {
        private int[] numbers;

        public int Solve(List<int> list, int k)
        {
            numbers = list.ToArray();
            if(k >= numbers.Length)
            {          
                return FindMin();
            }
            else
            {
                Sort(k);
                return numbers[k - 1];
            }
        }

        private int FindMin()
        {
            int min = int.MaxValue;
            for(int i = 0; i < numbers.Length; i++)
            {
                if(min > numbers[i])
                {
                    min = numbers[i];
                }
            }
            return min;
        }

        private void Sort(int k)
        {
            for(int i = 0; i <= k; i++)
            {
                int maxId = i;
                for(int j = i+1; j < numbers.Length; j++)
                {
                    if(numbers[j] > numbers[maxId])
                    {
                        maxId = j;
                    }
                }
                Swap(i, maxId);
            }
        }
        private void Swap(int i, int j)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}
