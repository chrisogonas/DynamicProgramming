using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            // FIbonacci numbers by memoization
            //Console.Write($"{Fibonaccis.Fib(1000, new Dictionary<int, long>())}, ");

            // Grid Traveler
            //long temp = GridTraveler.CountWaysBefore(20, 20);
            //Console.WriteLine($"Grid Traveler: {temp}");

            //long temp = GridTraveler.CountWaysAfter(50, 50, new Dictionary<string, long>());
            //Console.WriteLine($"Grid Traveler: {temp}");

            // Target sum
            //bool temp = TargetSum.CanSumBruteForce(800000, new int[] { 4, 5});
            //bool temp = TargetSum.CanSumMemoization(2, new int[] { 4, 5, 3 }, new Dictionary<int, bool>());
            //Console.WriteLine(temp);
            //int[] result = TargetSum.CanSumBruteForceArray(300, new int[] { 9, 150, 3 });
            //int[] result = TargetSum.CanSumBruteForceShortestArray(300, new int[] { 9, 150, 3 });
            int[] result = TargetSum.CanSumMemoizationShortestArray(300, new int[] { 9, 150, 3 }, new Dictionary<int, int[]>());
            //int[] result = TargetSum.CanSumMemoizationArray(300099, new int[] { 98, 153, 33 }, new Dictionary<int, int[]>());

            if (result is null)
            {
                Console.WriteLine("None!");
            } else
            {
                Console.WriteLine(String.Join(",", result));
            }

            Console.WriteLine();
        }


    }
}
