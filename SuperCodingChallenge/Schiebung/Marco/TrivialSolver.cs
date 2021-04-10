using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiebung.Marco
{
    public class TrivialSolver : ISchiebung
    {
        private int[,] matrix;
        private int width, height;
        private int k;

        public int[] Process(Tuple<int[,], int> input)
        {
            matrix = input.Item1;
            k = input.Item2;

            height = matrix.GetLength(0);
            width = matrix.GetLength(1);

            int[] dimShifts = new int[height];
            int[] minShift = new int[height];
            int min = int.MaxValue;
            for(int i = 0; i < Math.Pow(width, height); i++)
            {
                BuildNextShift(dimShifts, i);

                int[,] shifted = ShiftRows(ref dimShifts);
                int sum = ColumnSum(ref shifted);

                if (sum < min)
                {
                    Array.Copy(dimShifts, minShift, dimShifts.Length);
                    min = sum;
                }
                else if (sum == min && dimShifts.Sum() < minShift.Sum())
                {
                    Array.Copy(dimShifts, minShift, dimShifts.Length);
                    min = sum;
                }
            }

            return minShift;
        }
        private void BuildNextShift(int[] dimShifts, int i)
        {
            for (int dim = 0; dim < dimShifts.Length; dim++)
            {
                dimShifts[dim] = i % width;
                i = (i-dimShifts[dim])/width;
            }
        }

        private int ColumnSum(ref int[,] matrix)
        {
            int[] sum = new int[width];
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    sum[j] += matrix[i, j];
                }
            }
            int minDiff = int.MaxValue;
            for(int i=0;i< sum.Length; i++)
            {
                int diff = Math.Abs(sum[i] - k);
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }
            return minDiff;
        }

        private int[,] ShiftRows(ref int[] rows)
        {
            int[,] shifted = new int[height, width];
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    shifted[i, j] = matrix[i, (j + rows[i]) % width];
                }
            }
            return shifted;
        }
    }
}
