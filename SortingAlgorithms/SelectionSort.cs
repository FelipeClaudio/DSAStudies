using System;

namespace SortingAlgorithms
{
    public class SelectionSort : ISortingStrategy
    {
        public int[] Sort(int[] array)
        {
            int [] newArray = new int[array.Length];
            Array.Copy(array, newArray, array.Length);     

            for (int i = 0; i < (newArray.Length - 1); i++)
            {
                int minIndex = i;
                int minValue = newArray[i];
                for (int j = i + 1; j < newArray.Length; j++)
                {
                    if (minValue > newArray[j])
                    {
                        minIndex = j;
                        minValue = newArray[j];
                    }
                } 
                newArray.Swap(i, minIndex);
            }

            newArray.Print(this.GetType().Name);
            return newArray;
        }
    }
}