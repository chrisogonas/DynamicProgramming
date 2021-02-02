using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    /// <summary>
    /// Write a function CanSum(targetSum, numbers) that takes in a targetSum and an array of numbers as an arguments. 
    /// The function should return a boolean indicating whether or not it is possible to generate the targetSum using 
    /// numbers from the array. You may use an element of the array as many times as needed. 
    /// Assume that all input integers are non-negative.
    /// </summary>
    class TargetSum
    {
        /// <summary>
        /// Brute force approach
        /// </summary>
        /// <param name="target">Target sum</param>
        /// <param name="numbers">array of integers</param>
        /// <returns>Boolean answer</returns>
        public static bool CanSumBruteForce(int target, int[] numbers)
        {
            // handle base cases
            if (target == 0) { return true; } // this path contains parts that add up to target
            if (target < 0) { return false; } // no valid parts in this path add up to target

            foreach (var item in numbers)
            {
                int targetSum = target - item;
                if (CanSumBruteForce(targetSum, numbers) == true)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Return array of integers that add up to target
        /// </summary>
        /// <param name="target">Target sum</param>
        /// <param name="numbers">Array of numbers</param>
        /// <returns>Array of numbers or null if none</returns>
        public static int[] CanSumBruteForceArray(int target, int[] numbers)
        {
            // handle base cases
            if (target == 0) { return new int[]{ }; } // this path contains parts that add up to target
            if (target < 0) { return null; } // no valid parts in this path add up to target

            foreach (var number in numbers)
            {
                int targetSum = target - number;
                int[] remainderArray = CanSumBruteForceArray(targetSum, numbers);

                if ( remainderArray != null)
                {
                    int[] result = new int[remainderArray.Length + 1]; // create room for the new number
                    remainderArray.CopyTo(result, 0); // move arrays to new bigger array
                    result[remainderArray.Length] = number; // place new number into the last index of the new array

                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Dynamic programming - memoization
        /// </summary>
        /// <param name="target">Target sum</param>
        /// <param name="numbers">array of integers</param>
        /// <param name="memo">Memo of subproblems solutions</param>
        /// <returns></returns>
        public static bool CanSumMemoization(int target, int[] numbers, Dictionary<int, bool> memo)
        {
            if (memo.ContainsKey(target)) { return memo[target]; }

            // handle base cases
            if (target == 0) { return true; } // this path contains parts that add up to target
            if (target < 0) { return false; } // no valid parts in this path add up to target

            foreach (var item in numbers)
            {
                int targetSum = target - item;
                if (CanSumMemoization(targetSum, numbers, memo) == true)
                {
                    memo.Add(target, true);
                    return true;
                }
            }

            memo.Add(target, false);
            return false;
        }
    }
}
