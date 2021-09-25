using System;

namespace SortingAlgorithms
{
    public class QuickSort3 : ISortingStrategy
    {
        private readonly Random _random;

        public QuickSort3()
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
           int pivot = this.Partition(array, low, high);
           if (low < pivot - 1)
                this.Sort(array, low, pivot - 1);

           if (pivot < high)
                this.Sort(array, pivot, high);
        }

        private int Partition(int[] array, int low, int high)
        {
            int l = low, h = high;
            int pivotValue = array[(low + high) / 2];

            while (l < h)
            {
                while(array[l] < pivotValue) l++;
                while(array[h] > pivotValue) h--;

                if (l < h)
                {
                    array.Swap(l, h);
                    l++;
                    h--;
                }

                if (l == h)
                    l++;
            }

            return l;
        }
    }
}