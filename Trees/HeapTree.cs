using System.Collections.Generic;
using System;

public class HeapTree<T>
    where T : IComparable
{

    public enum HeapTypeEnum
    {
        MIN,
        MAX
    }

    private List<T> Data { get; set; }
    
    public HeapTypeEnum HeapType { get; private set; }

    private int currentIndex = -1;

    public T GetRootNode()
    {
        T rootData = this.Data[0];

        if (this.Data.Count > 2)
        {
            int newRootIndex = -1;
            newRootIndex = this.LeftElementComesFirstInOrder(1, 2) ? 1 : 2;
            this.Swap(0, newRootIndex);
        }
        else if (this.Data.Count == 2)
            this.Swap(0, 1);
        
        this.Data.Remove(rootData);
        return rootData;
    }

    public void InsertValue(T value)
    {
        this.Data.Add(value);
        this.currentIndex++;

        int pivotIndex = currentIndex/2;
        int newElementIndex = currentIndex;
        while (pivotIndex >= 0 && this.LeftElementComesFirstInOrder(newElementIndex, pivotIndex))
        {
            this.Swap(newElementIndex, pivotIndex);
            newElementIndex = pivotIndex;
            pivotIndex = newElementIndex/2;
        }
    }

    private bool LeftElementComesFirstInOrder(int leftIndex, int rightIndex)
    {
        if (this.HeapType == HeapTypeEnum.MIN)
            return this.Data[leftIndex].CompareTo(this.Data[rightIndex]) < 0;

        return this.Data[leftIndex].CompareTo(this.Data[rightIndex]) > 0;
    }

    private void Swap(int oldIndex, int newIndex)
    {
        T temp = this.Data[oldIndex];
        this.Data[oldIndex] = this.Data[newIndex];
        this.Data[newIndex] = temp;
    }

    public HeapTree(HeapTypeEnum heapType)
    {
        this.HeapType = heapType;
        this.Data = new List<T>();
    }
}