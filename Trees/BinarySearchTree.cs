using System.Collections.Generic;
using System;

namespace Trees
{
    public class BinarySearchTree<T, V> : Tree<T>
        where T : BinarySearchTreeNode<V>
        where V : IComparable
    {
        public BinarySearchTreeNode<V> GetElementNodeByValue(V value)
        {
            var currentNode = this.Root;

            while (currentNode != null)
            {
                int comparisionResult = currentNode.Data.CompareTo(value);
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
            if (this.GetElementNodeByValue(elementValue) != null)
                throw new ArgumentException($"Node with value: {elementValue} already exists!");
            
            var newNode = new BinarySearchTreeNode<V>
            {
                Data = elementValue
            };
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

                newNode.Parent = previousNode;
            }
        }

        // TODO: Refazer
        public void RemoveValue(V value)
        {
            if (this.Root == null)
                throw new ArgumentException($"Tree is already empty!");

            T existingNode = (T)this.GetElementNodeByValue(value);
            if (existingNode == null)
                throw new ArgumentException($"Node with value {value} doesn't exist.");

            if (existingNode.Parent == null)
                throw new ArgumentException($"Can't remove root node.");

            T parentNode = (T)existingNode.Parent;
            T currentNode = existingNode;
            // Existing node is a leaf
            if (existingNode.LeftNode == null && existingNode.RightNode == null)
            {
                if (parentNode.LeftNode?.Data.CompareTo(currentNode.Data) == 0)
                    parentNode.LeftNode = null;
                else
                    parentNode.RightNode = null;
                return;
            }
            else if (currentNode.RightNode == null)
            {
                currentNode = (T)existingNode.LeftNode;
                currentNode.Parent = existingNode.Parent;
            }
            else if (currentNode.LeftNode == null)
            {
                currentNode = (T)existingNode.RightNode;
                currentNode.Parent = existingNode.Parent;
            }
            else
            {
                currentNode = (T)existingNode.LeftNode;
                while(currentNode.RightNode != null)
                    currentNode = (T)currentNode.RightNode;

                if (currentNode.LeftNode != null)
                    ((T)currentNode.Parent).RightNode = currentNode.LeftNode;
                
                currentNode.Parent = existingNode.Parent;
                if (currentNode.Data.CompareTo(existingNode.LeftNode.Data) != 0)
                    currentNode.LeftNode = existingNode.LeftNode;
                if (currentNode.Data.CompareTo(existingNode.RightNode.Data) != 0)
                    currentNode.RightNode = existingNode.RightNode;
            }
            this.ReplaceNode(existingNode, currentNode);
        }

        public void ReplaceNode(T existingNode, T currentNode)
        {
            T parent = (T)existingNode.Parent;
            if (parent == null)
                return;

            if (existingNode.RightNode != null && existingNode.RightNode?.Data.CompareTo(currentNode.Data) != 0)
                existingNode.RightNode.Parent = currentNode;

            if (existingNode.LeftNode != null && existingNode.LeftNode?.Data.CompareTo(currentNode.Data) != 0)
                existingNode.LeftNode.Parent = currentNode;

            if (parent.LeftNode?.Data.CompareTo(existingNode.Data) == 0)
                parent.LeftNode = currentNode;
            else
                parent.RightNode = currentNode;
        }
    }
}