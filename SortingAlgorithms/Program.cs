using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] unsortedArray = new int [] {3, 4, 1, 7, 2, 1, 8, 15, 13, 56, 2};
            unsortedArray.Print("Unsorted array");

            int[] sortedArray = new int[unsortedArray.Length];
            Array.Copy(unsortedArray, sortedArray, unsortedArray.Length);
            Array.Sort(sortedArray);
            sortedArray.Print("C# sorted array");

            var sorters = new List<ISortingStrategy>
            {
                new SelectionSort(), 
                new InsertionSort(),
                new BubbleSort(),
                new QuickSort(),
                new QuickSort2(),
                new QuickSort3(),
                new MergeSort(),
                new MergeSort2()
            };
            sorters.ForEach(s => s.Sort(unsortedArray));
        }
    }
}