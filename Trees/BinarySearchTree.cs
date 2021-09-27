using System.Collections.Generic;
using System;

namespace Trees
{
    public class BinarySearchTree<T, V> : Tree<T>
        where T : BinarySearchTreeNode<V>
        where V : IComparable
    {
        public BinarySearchTreeNode<V> GetElementNode(T element)
        {
            var currentNode = this.Root;

            while (currentNode != null)
            {
                int comparisionResult = currentNode.Data.CompareTo(element.Data);
                if (comparisionResult == 0)
                    return currentNode;
                else if (comparisionResult > 0)
                    currentNode = (T)currentNode.LeftNode;
                else 
                    currentNode = (T)currentNode.RightNode;
            }

            return currentNode;
        }

        public void InsertValue(V elementValue)
        {
            var newNode = new BinarySearchTreeNode<V>
            {
                Data = elementValue
            };
            if (this.GetElementNode((T)newNode) != null)
                throw new ArgumentException($"Node with value: {elementValue} already exists!");
                
            if (this.Root == null)
                this.Root = (T) newNode;
            else
            {
                var previousNode = this.Root;
                var currentNode = this.Root;
                int comparisionResult = 0;
                while(currentNode != null)
                {
                    previousNode = currentNode;
                    comparisionResult = currentNode.Data.CompareTo(elementValue);
                    if (comparisionResult > 0)
                        currentNode = (T)currentNode.LeftNode;
                    else 
                        currentNode = (T)currentNode.RightNode; 
                }

                if (comparisionResult > 0)
                    previousNode.LeftNode = newNode;          
                else
                    previousNode.RightNode = newNode;
            }
        }
    }
}