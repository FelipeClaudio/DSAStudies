using System;

namespace SortingAlgorithms
{
    public class QuickSort : ISortingStrategy
    {
        public int[] Sort(int[] array)
        {
            int [] newArray = new int[array.Length];
            Array.Copy(array, newArray, array.Length);     

            Sort(newArray, 0, newArray.Length - 1);

            newArray.Print(this.GetType().Name);
            return newArray;
        }

        private int[] Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                // int partitionIndex = Partition(array, low, high);
                int partitionIndex = Partition(array, low, high);
                Sort(array, low, partitionIndex - 1);
                Sort(array, partitionIndex + 1, high);
            }
            return array;
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivotPosition = low;
            int pivotValue = array[low];

            while(low < high)
            {
                while(array[low] <= pivotValue) low++;
                while(array[high] > pivotValue) high--;

                if (low < high)
                    array.Swap(low, high);
            }

            array.Swap(pivotPosition, high);
            return high;
        }
    }
}