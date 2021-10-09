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
                int comparisionResult = value.CompareTo(currentNode.Data);
                if (comparisionResult == 0)
                    return currentNode;
                else if (comparisionResult < 0)
                    currentNode = (T)currentNode.LeftNode;
                else 
                    currentNode = (T)currentNode.RightNode;
            }

            return currentNode;
        }

        public virtual void InsertValue(V value)
        {
            if (this.GetElementNodeByValue(value) != null)
                throw new ArgumentException($"Node with value: {value} already exists!");
            
            var newNode = new BinarySearchTreeNode<V>
            {
                Data = value
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
                    comparisionResult = value.CompareTo(currentNode.Data);
                    if (comparisionResult < 0)
                        currentNode = (T)currentNode.LeftNode;
                    else 
                        currentNode = (T)currentNode.RightNode; 
                }

                if (comparisionResult < 0)
                    previousNode.LeftNode = newNode;          
                else
                    previousNode.RightNode = newNode;

                newNode.Parent = previousNode;
            }
        }

        public virtual void RemoveValue(V value)
        {
            if (this.Root == null)
                throw new ArgumentException($"Tree is already empty!");

            T existingNode = (T)this.GetElementNodeByValue(value);
            if (existingNode == null)
                throw new ArgumentException($"Node with value {value} doesn't exist.");

            if (existingNode.Parent == null)
            {
                BinaryTreeNode<V> node = null; 
                if (existingNode.LeftNode != null)
                {
                    node = existingNode.LeftNode; 
                    while(node.RightNode != null)
                        node = node.RightNode;
                }
                else if (existingNode.RightNode != null)
                {
                    node = existingNode.RightNode;
                    while(node.LeftNode != null)
                        node = node.LeftNode;
                }
                else
                    this.Root = null;
                
                this.Root = (T) node;
                this.ReplaceNode(this.Root, (T)node);
                return;
            }

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
            // Right branch doesn't exist
            else if (currentNode.RightNode == null)
            {
                currentNode = (T)existingNode.LeftNode;
                currentNode.Parent = existingNode.Parent;
            }
            // Left branch doesn't exist
            else if (currentNode.LeftNode == null)
            {
                currentNode = (T)existingNode.RightNode;
                currentNode.Parent = existingNode.Parent;
            }
            // Both branches exist
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

        private void ReplaceNode(T existingNode, T currentNode)
        {
            if (existingNode.RightNode != null && existingNode.RightNode?.Data.CompareTo(currentNode.Data) != 0)
                existingNode.RightNode.Parent = currentNode;

            if (existingNode.LeftNode != null && existingNode.LeftNode?.Data.CompareTo(currentNode.Data) != 0)
                existingNode.LeftNode.Parent = currentNode;

            T parent = (T)existingNode.Parent;
            if (parent == null)
                return;

            if (parent.LeftNode?.Data.CompareTo(existingNode.Data) == 0)
                parent.LeftNode = currentNode;
            else
                parent.RightNode = currentNode;
        }
    }
}