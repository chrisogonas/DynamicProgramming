using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DynamicProgramming
{
    /// <summary>
    /// This is a Longest Increasing Subsequence (LIS) problem 
    /// Reference: https://www.geeksforgeeks.org/box-stacking-problem-dp-22/
    /// You are given a set of n types of rectangular 3-D boxes, where the i^th box has height h(i), width w(i) and 
    /// length l(i) (all real numbers). You want to create a stack of boxes which is as tall as possible, but you can only 
    /// stack a box on top of another box if the dimensions of the 2-D base of the lower box are each strictly larger 
    /// than those of the 2-D base of the higher box. Of course, you can rotate a box so that any side functions as its base. 
    /// It is also allowable to use multiple instances of the same type of box.
    /// =============================
    /// The Box Stacking problem is a variation of LIS problem. We need to build a maximum height stack. 
    /// Following are the key points to note in the problem statement:
    /// 1) A box can be placed on top of another box only if both width and length of the upper placed box are smaller than width and length of the lower box respectively.
    /// 2) We can rotate boxes such that width is smaller than length. For example, if there is a box with dimensions {1x2x3}
    /// where 1 is height, 2×3 is base, then there can be three possibilities, {1x2x3}, {2x1x3} and {3x1x2}
    /// 3) We can use multiple instances of boxes. What it means is, we can have two different rotations of a box as part of our maximum height stack.
    /// ==========Approach=============
    /// 1) Generate all 3 rotations of all boxes. The size of rotation array becomes 3 times the size of the original array. 
    /// For simplicity, we consider width as always smaller than or equal to length.
    /// 2) Sort the above generated 3n boxes in decreasing order of base area.
    /// 3) After sorting the boxes, the problem is same as LIS with following optimal substructure property.
    /// MSH(i) = Maximum possible Stack Height with box i at top of stack: MSH(i) = {Max(MSH(j)) + height(i)} where j<i and width(j) > width(i) 
    /// and length(j) > length(i). If there is no such j then MSH(i) = height(i)
    /// 4) To get overall maximum height, we return max(MSH(i)) where 0 < i < n
    /// </summary>
    class BoxStacking
    {
        public int[] BoxStacks { get; set; }
        public int[] BoxIndexLocations { get; set; }

        /// <summary>
        /// Compute the highest box stack
        /// </summary>
        /// <param name="boxes">Array of boxes to stack</param>
        /// <returns>Highest stack</returns>
        public static int GetHighestBoxStack(Box[] boxes)
        {
            Box[] allBoxes = new Box[boxes.Length * 3];
            for (int i = 0; i < boxes.Length; i++)
            {
                Box box = boxes[i];
                // box 1
                allBoxes[3 * i] = new Box { Height = box.Height, Width = Math.Min(box.Width, box.Length), Length = Math.Max(box.Width, box.Length) };

                // box 2
                allBoxes[3 * i + 1] = new Box { Height = box.Width, Width = Math.Min(box.Height, box.Length), Length = Math.Max(box.Height, box.Length) };

                // box 3
                allBoxes[3 * i + 2] = new Box { Height = box.Length, Width = Math.Min(box.Height, box.Width), Length = Math.Max(box.Height, box.Width) };

            }

            // compute base areas
            Console.WriteLine("Box Dimensions - before sorting");
            for (int i = 0; i < allBoxes.Length; i++)
            {
                allBoxes[i].BaseArea = allBoxes[i].Length * allBoxes[i].Width;

                // line below purely for debug purposes; can be deleted
                Console.WriteLine($"{allBoxes[i].Length}, {allBoxes[i].Width}, {allBoxes[i].Height}, {allBoxes[i].BaseArea}");
            }
            Console.WriteLine();

            // order by base area (must be DESCENDING order)
            List<Box> boxesSortedByBaseArea = allBoxes.OrderByDescending(x => x.BaseArea).ToList();

            // Initialize msh values for all indexes  
            // msh[i] --> Maximum possible Stack Height with box i on top
            int[] msh = new int[allBoxes.Length];
            Console.WriteLine("Box Dimensions - after sorting by base area");
            for (int i = 0; i < allBoxes.Length; i++)
            {
                msh[i] = boxesSortedByBaseArea[i].Height;

                // line below purely for debug purposes; can be deleted
                Console.WriteLine($"{boxesSortedByBaseArea[i].Length}, {boxesSortedByBaseArea[i].Width}, {boxesSortedByBaseArea[i].Height}, {boxesSortedByBaseArea[i].BaseArea}");
            }

            for (int i = 0; i < boxesSortedByBaseArea.Count; i++)
            {
                msh[i] = 0;
                Box box = boxesSortedByBaseArea[i];
                int val = 0;
                for (int j = 0; j < i; j++)
                {
                    Box previousBox = boxesSortedByBaseArea[j];
                    if (box.Length < previousBox.Length && box.Width < previousBox.Width)
                    {
                        val = Math.Max(val, msh[j]);
                    }
                }
                msh[i] = val + box.Height;

            }

            // getting max of all MSH values
            int max = -1;
            for (int i = 0; i < msh.Length; i++)
            {
                max = Math.Max(max, msh[i]);
            }

            return max;
        }
    }

    class Box
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int BaseArea { get; set; }

        public Box()
        {
            //
        }

        public Box(int Length, int Width, int Height)
        {
            this.Length = Length;
            this.Width = Width;
            this.Height = Height;
        }

    }
}
