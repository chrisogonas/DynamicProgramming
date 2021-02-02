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
            int[] result = TargetSum.CanSumBruteForceArray(270, new int[] { 8, 5, 3 });
            if(result is null)
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
