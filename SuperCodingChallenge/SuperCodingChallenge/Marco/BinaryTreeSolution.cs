using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCodingChallenge.Marco
{
    public class BinaryTreeSolution : IKthMaxSolution
    {
        private int[] binaryTree;

        public int Solve(List<int> list, int k)
        {
            binaryTree = list.ToArray();
            BuildBinaryTree();

            return FindKthMin(k);
        }

        private void BuildBinaryTree()
        {
            bool changed;
            do
            {
                changed = false;
                for (int i = 0; i < binaryTree.Length; i++)
                {
                    int leftId = i * 2 + 1;
                    int rightId = i * 2 + 2;

                    if (binaryTree[i] < binaryTree[leftId])
                    {
                        Swap(leftId, i);
                        changed = true;
                    }
                    if (binaryTree[i] > binaryTree[rightId])
                    {
                        Swap(rightId, i);
                        changed = true;
                    }
                }
            } while (changed);
        }

        private int FindKthMin(int k)
        {
            //Stack<int> solution = new Stack<int>();

            int currentIndex = 0;
            while((currentIndex * 2 + 2) < binaryTree.Length)
            {
                currentIndex += currentIndex * 2 + 2;
            }
            
            for(int i = 0; i < k; i++)
            {
                
            }

            return binaryTree[currentIndex];
        }
        private void Swap(int i, int j)
        {
            int temp = binaryTree[i];
            binaryTree[i] = binaryTree[j];
            binaryTree[j] = temp;
        }
    }
}
