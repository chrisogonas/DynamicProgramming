using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    /// <summary>
    /// User can only travel downwards or right, and user has to move from top-left cell to bottom-right cell
    /// </summary>
    class GridTraveler
    {
        /// <summary>
        /// Grid Traveler before memoization
        /// </summary>
        /// <param name="rows">Grid rows</param>
        /// <param name="cols">Grid columns</param>
        /// <returns>Number of ways to travel the grid</returns>
        public static long CountWaysBefore(int rows, int cols)
        {
            // base cases
            if(rows == 1 && cols == 1) { return 1; } // grid of one cell
            if(rows == 0 || cols == 0) { return 0; } // invalid grid

            // either stay in the same column, and move downwards 1 row i.e. rows - 1, or
            // stay in the same row, and move right 1 cell i.e. cols + 1
            return CountWaysBefore(rows - 1, cols) + CountWaysBefore(rows, cols - 1);
        }

        /// <summary>
        /// Grid Traveler after memoization        
        /// </summary>
        /// <param name="rows">Grid rows</param>
        /// <param name="cols">Grid columns</param>
        /// <param name="memo">Dictionary of values already computed for previous sub-problems</param>
        /// <returns>Number of ways to travel the grid</returns>
        public static long CountWaysAfter(int rows, int cols, Dictionary<string,long> memo)
        {
            string key = string.Concat(rows.ToString(), ",", cols.ToString()); // unique key of item in the memo

            // if item in memo, just return it
            if(memo.ContainsKey(key)) { return memo[key]; }

            // base cases
            if (rows == 1 && cols == 1) { return 1; } // grid of one cell
            if (rows == 0 || cols == 0) { return 0; } // invalid grid

            // either stay in the same column, and move downwards 1 row i.e. rows - 1, or
            // stay in the same row, and move right 1 cell i.e. cols + 1
            memo.Add(key, CountWaysAfter(rows - 1, cols, memo) + CountWaysAfter(rows, cols - 1, memo));

            return memo[key];

        }

    }
}
