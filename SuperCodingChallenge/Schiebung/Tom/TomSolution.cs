using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiebung
{
    class TomSolution : IProcessable<Tuple<int[,], int>, int[]>
    {
        public int[] Process(Tuple<int[,], int> input)
        {
            int rows = input.Item1.GetLength(0);
            int colums = input.Item1.GetLength(1);



            int[,] addMatrix = new int[colums, colums];

            for(int r = 0; r  < colums; r++)
            {
                for(int c = 0; c < colums; c++)
                {
                    addMatrix[r, c] = FindSum(input.Item1, new int[] { r, c });
                }
            }
            int near = addMatrix[0,0];
            int row = 0,col = 0;             
            for(int i = 0; i < colums; i++)
            {
                for (int j = 0; j < colums; j++)
                {

                    if (Math.Abs(addMatrix[i, j] - input.Item2) < near)
                    {
                        near = Math.Abs(addMatrix[i, j] - input.Item2);
                        row = i;
                        col = j;
                    }
                    if (Math.Abs(addMatrix[j, i] - input.Item2) < near)
                    {
                        near = Math.Abs(addMatrix[i, j] - input.Item2);
                        row = i;
                        col = j;
                    }
                }
            }

            //Console.WriteLine("Selected row: " + row + ", column:" + col +  " : nearest sum: " + near);
            return new int[] { row, col}; 
        }

        private int FindSum(int[,] input, int[] rc)
        {
            int rows = input.GetLength(0);
            int colums = input.GetLength(1);
            int[] sums = new int[colums];
            for (int j = 0; j < colums; j++)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    sum += input[i, (j + rc[i]) % colums];
                }
                sums[j] = sum;
                //Console.Write(j + ": " + sum + " " + rc[0] + " " + rc[1] + Environment.NewLine);
            }
            //Console.WriteLine();

            return 0;

        }
    }
}
