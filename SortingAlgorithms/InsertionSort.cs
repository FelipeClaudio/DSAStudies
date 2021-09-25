using System;

namespace SortingAlgorithms
{
    public class InsertionSort : ISortingStrategy
    {
        public int[] Sort(int[] array)
        {
            int [] newArray = new int[array.Length];
            Array.Copy(array, newArray, array.Length);

            for (int i = 1; i < newArray.Length; i++)
            {
                int j = i;
                while (j > 0 && newArray[j] < newArray[j - 1])
                {
                    newArray.Swap(j, j -1);
                    j--;
                }
            }

            newArray.Print(this.GetType().Name);
            return newArray;
        }
    }
}