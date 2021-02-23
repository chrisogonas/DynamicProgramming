using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    /// <summary>
    /// Given a string, find minimum cuts needed to partition it such that each partition is a palindrome. 
    /// For example, minimum cuts required in BABABCBADCD are 2.. i.e. BAB | ABCBA | DCD
    /// We can break the problem into a set of related subproblems which partition the given string in 
    /// such a way that yields the lowest total cuts.
    /// </summary>
    class PalindromePartition
    {
        /// <summary>
        /// Find minimum cuts needed to partition it such that each partition is a palindrome.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Number of partitions/cuts</returns>
        public static int GetMinimumPalinCuts(string input)
        {
            bool[,] palinTable = new bool[input.Length, input.Length];
            //int tmpRow = 0;
            int n = input.Length;
            
            // initialize base cases
            for (int i = 0; i < input.Length; i++)
            {
                palinTable[i, i] = false;
            }

            //Finding palindromes of two characters.
            for (int i = 0; i < n - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    palinTable[i,i + 1] = true;
                }
            }

            //Finding palindromes of length 3 to n
            for (int curr_len = 3; curr_len <= n; curr_len++)
            {
                for (int i = 0; i < n - curr_len + 1; i++)
                {
                    int j = i + curr_len - 1;
                    if (input[i] == input[j] //1. The first and last characters should match 
                        && palinTable[i + 1,j - 1]) //2. Rest of the substring should be a palindrome
                    {
                        palinTable[i,j] = true;
                    }
                }
            }

            //for (int i = 0; i < input.Length-1; i++)
            //{
            //    //tmpRow = 0;
            //    //for (int j = i; j < input.Length; j++)
            //    //{
            //    // base cases
            //    //if (i == i+1)
            //    //{
            //    //    palinTable[i, i+1] = false;
            //    //}

            //    if (input[i] == input[i + 1]) // characters match i.e. palindrome; set value to zero
            //    {
            //        palinTable[i, i + 1] = true;
            //    }
            //    else // characters don't match; set value to minimum of subproblems + 1
            //    {
            //        palinTable[i, i + 1] = false; // 1 + Math.Min(palinTable[i + 1, i], palinTable[i, i - 1]);
            //    }
            //    //tmpRow++;

            //    // Optional loop to view matrix
            //    PrintMatrix(palinTable);
            //    //}
            //}

            int[] cuts = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                int temp = int.MaxValue;
                if (palinTable[0, i])
                    cuts[i] = 0;
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if ((palinTable[j + 1, i]) && temp > cuts[j] + 1)
                        {
                            temp = cuts[j] + 1;
                        }
                    }
                    cuts[i] = temp;
                }
            }

            return cuts[input.Length - 1]; // palinTable[0, input.Length - 1];
        }

        private static void PrintMatrix(bool[,] matrix)
        {
            Console.WriteLine("New Table");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = "";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += matrix[i, j] + " ";
                }
                Console.WriteLine(line);
            }
        }
    }
}
