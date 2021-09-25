using System;

namespace SortingAlgorithms
{
    public class QuickSort2 : ISortingStrategy
    {
        private readonly Random _random;

        public QuickSort2()
        {
            this._random = new Random();
        }
        public int[] Sort(int[] array)
        {
            int [] newArray = new int[array.Length];
            Array.Copy(array, newArray, array.Length);

            this.Sort(newArray, 0, newArray.Length - 1);

            newArray.Print(this.GetType().Name);

            return newArray;
        }

        private void Sort(int[] array, int low, int high)
        {
            int index = this.Partition(array, low, high);
            if (low < index - 1)
                Sort(array, low, index - 1);

            if (high > index)
                Sort(array, index, high);
        }

        private int Partition(int[] array, int low, int high)
        {
            int l = low, h = high;
            // int pivot = array[(low + high) / 2];
            int pivot = array[this._random.Next(low, high)];

            while (l < h)
            {
                while (array[l] < pivot) l++;
                while (array[h] > pivot) h--;

                if (l < h)
                {
                    array.Swap(l, h);
                    l++;
                    h--;
                }

                // This condition only exists to avoid unnecessary swap when l == h
                /* Example:
                    array[8] = 13, array[9] = 15
                    low = 8, high = 9, pivot = 8

                   Will lead to a infinity loop.
                */ 
                if (l == h)
                {
                    l++;
                }
            }

            return l;
        }
    }
}