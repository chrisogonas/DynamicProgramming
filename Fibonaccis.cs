using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class Fibonaccis
    {
        /// <summary>
        /// Get Fibonacci number at a certain position
        /// </summary>
        /// <param name="position">position of number</param>
        /// <param name="memo">Dictionary of previously computed values of sub-problems</param>
        /// <returns>Fibonacci number at the given position</returns>
        public static long Fib(int position, Dictionary<int, long> memo)
        {
            if (memo.ContainsKey(position)) { return memo[position]; }
            if (position <= 1) { return position; }
            memo.Add(position, Fib(position - 1, memo) + Fib(position - 2, memo));

            return memo[position];
        }
    }
}
