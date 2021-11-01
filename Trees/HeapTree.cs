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

    private int lastInsertionIndex = -1;

    public T GetRootNode()
    {
        T oldRootData = this.Data[0];
        this.Swap(0, lastInsertionIndex);
        lastInsertionIndex--;

        int pivotIndex = 0;
        int childIndex = 1;
        bool continueToLeaf = true;
        while ((childIndex <= lastInsertionIndex) && (continueToLeaf == true))
        {
            int newParentIndex = childIndex;
            if (childIndex + 1 < lastInsertionIndex)
                newParentIndex = this.LeftElementComesFirstInOrder(childIndex, childIndex + 1)? childIndex : childIndex +1;
            
            if (this.LeftElementComesFirstInOrder(pivotIndex, newParentIndex) == false)
                this.Swap(pivotIndex, newParentIndex);
            else
                continueToLeaf = false;

            pivotIndex = newParentIndex;
            childIndex *= 2;
        }

        return oldRootData;
    }

    public void InsertValue(T value)
    {
        if (this.Data.Contains(value))
            return;

        this.Data.Add(value);
        this.lastInsertionIndex++;

        int pivotIndex = lastInsertionIndex/2;
        int newElementIndex = lastInsertionIndex;
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

    public static List<T> Sort(List<T> values, HeapTypeEnum heapType)
    {
        var heapTree = new HeapTree<T>(heapType);
        var sortedList = new List<T>();
        values.ForEach(val => heapTree.InsertValue(val));
        values.ForEach(val => sortedList.Add(heapTree.GetRootNode()));

        return sortedList;
    }
}