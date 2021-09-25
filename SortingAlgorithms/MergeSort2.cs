using System;

namespace SortingAlgorithms
{
    public class MergeSort2 : ISortingStrategy
    {
        public int[] Sort(int[] array)
        {
            int [] newArray = new int[array.Length];
            Array.Copy(array, newArray, array.Length);

            this.Sort(newArray, 0, array.Length - 1);

            newArray.Print(this.GetType().Name);

            return newArray;
        }

        private void Sort(int[] array, int left, int right)
        {
            int middle = (left + right) / 2;
            if (left < right)
            {
                this.Sort(array, left, middle);
                this.Sort(array, middle + 1, right);
                this.Merge(array, left, right, middle);
            }
        }

        private void Merge(int[] array, int left, int right, int middle)
        {
            int leftArraySize = middle - left + 1;
            int[] leftArray = new int[leftArraySize];
            int rightArraySize = right - middle;
            int[] rightArray = new int[rightArraySize];

            for (int i = 0; i < leftArraySize; i++)
                leftArray[i] = array[left + i];

            for (int i = 0; i < rightArraySize; i++)
                rightArray[i] = array[middle + i  + 1];

            int finalArrayIndex = left;
            int l = 0, r = 0;
            while (l < leftArraySize && r < rightArraySize)
            {
                if (leftArray[l] < rightArray[r])
                {
                    array[finalArrayIndex] = leftArray[l];
                    l++;
                }                
                else
                {
                    array[finalArrayIndex] = rightArray[r];
                    r++;
                }                  

                finalArrayIndex++;
            }

            while(l < leftArraySize)
            {
                array[finalArrayIndex] = leftArray[l];
                l++;
                finalArrayIndex++;
            }
            while(r < rightArraySize)
            {
                array[finalArrayIndex] = rightArray[r];
                r++;
                finalArrayIndex++;
            }
        }
    }
}