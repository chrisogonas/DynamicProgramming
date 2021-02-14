using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    /// <summary>
    /// Given a set of integers and a target integer for sum, find out if the set has a subset that sums up to the target
    /// </summary>
    class SubsetSum
    {
        /*
         * Approach - Dynamic Programming
         * 0. Sort array/set in ascending order
         * 1. Setup a table of target (columns) and set intergers (rows)
         * 2. For each row, taking into account the previous sub-task solutions/observations, evaluate each cell
         * 3. The value of a cell is computed as follows:
         *    cell_value = value excluding new row value OR value including new row value
         *    NOTE:
         *      a.) value excluding new row value = value[row-1][col] and
         *      b.) value including new row value is computed as floows:
         *          i.)   If col - row < 0, value = value[row-1][col]
         *          ii.)  If col - row == 0, value = True
         *          iii.) if col - row < 0, value = value[row-1][col] OR value = value[row-1][col - row]
         * 4. return value = value[rows][cols]
         */

        /// <summary>
        /// Find out if set contains subset that sums up to target
        /// </summary>
        /// <param name="set">set of numbers</param>
        /// <param name="target">target sum</param>
        /// <returns>True if exists, false if otherwise</returns>
        public static bool SumHasSubset(int[] set, int target)
        {
            bool[,] matrix = new bool[set.Length + 1, target + 1]; // +1 for additional 1st row/col

            // Sort array - array must be sorted ascending
            Array.Sort(set);

            // initialize first row
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[0, i] = (i - 0 == 0);
            }

            // fill in rest of the rows
            for (int i = 1; i < matrix.GetLength(0); i++) // begin from row 1 since row 0 is already populated from above
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j - set[i - 1] < 0) // NOTE that set[i-1] refers to array element since there is additional row 0 in the matrix
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                    else if (j - set[i - 1] == 0)
                    {
                        matrix[i, j] = true;
                    }
                    else if (j - set[i-1] > 0)
                    {
                        matrix[i, j] = matrix[i - 1, j - set[i - 1]];
                    }
                }
            }

            return matrix[set.Length, target]; // return value of the last cell
        }
    }
}
