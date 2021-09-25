using System;

namespace SortingAlgorithms
{
    public class BubbleSort : ISortingStrategy
    {
        public int[] Sort(int[] array)
        {
            int [] newArray = new int[array.Length];
            Array.Copy(array, newArray, array.Length);     

            for (int i = 0; i < newArray.Length; i++)
            {
                for (int j = 0; j < newArray.Length - 1; j++)
                {
                    if (newArray[j + 1] < newArray[j])
                        newArray.Swap(j, j + 1);
                }
            }

            newArray.Print(this.GetType().Name);
            return newArray;
        }
    }
}