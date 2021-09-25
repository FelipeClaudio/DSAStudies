using System;

namespace SortingAlgorithms
{
    public class MergeSort : ISortingStrategy
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
            int rightArraySize = right - middle;
            int[] leftArray = new int[leftArraySize];
            int[] rightArray = new int[rightArraySize];
            
            for(int i = 0; i < leftArraySize; i++)
                leftArray[i] = array[i + left];

            for(int i = 0; i < rightArraySize; i++)
                rightArray[i] = array[i + middle + 1];

            int leftIndex = 0, rightIndex = 0;
            int finalArrayIndex = left;
            while(leftIndex < leftArraySize && rightIndex < rightArraySize)
            {
                if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    array[finalArrayIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[finalArrayIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
                finalArrayIndex++;
            }

            while(leftIndex < leftArraySize)
            {
                array[finalArrayIndex] = leftArray[leftIndex];
                leftIndex++;
                finalArrayIndex++;
            }
            while(rightIndex < rightArraySize)
            {
                array[finalArrayIndex] = rightArray[rightIndex];
                rightIndex++;
                finalArrayIndex++;
            }
        }
    }
}