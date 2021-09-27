using System.Collections.Generic;
using System;

namespace Trees
{
    public static class BinaryTreeOperations
    {
        public enum TraversalTypeEnum
        {
            IN_ORDER,
            PRE_ORDER,
            POST_ORDER
        }

        public static void Traversal<T>(this Tree<BinaryTreeNode<T>> tree, List<BinaryTreeNode<T>> traversedNodes, TraversalTypeEnum traversalType)
        {
            switch (traversalType)
            {
                case TraversalTypeEnum.IN_ORDER:
                    tree.Root.TraversalInOrder(traversedNodes);
                    break;
                case TraversalTypeEnum.PRE_ORDER:
                    tree.Root.TraversalInPreOrder(traversedNodes);
                    break;
                case TraversalTypeEnum.POST_ORDER:  
                    tree.Root.TraversalInPostOrder(traversedNodes);
                    break;  
                default:
                    throw new ArgumentException($"Unsupported traversal order {traversalType}");
            }
        }

        private static void TraversalInPreOrder<T>(this BinaryTreeNode<T> node, List<BinaryTreeNode<T>> traversedNodes)       
        {
            traversedNodes.Add(node);
            if (node.LeftNode != null)
                BinaryTreeOperations.TraversalInPreOrder(node.LeftNode, traversedNodes);
            
            if (node.RightNode != null)
                BinaryTreeOperations.TraversalInPreOrder(node.RightNode, traversedNodes);
        }

        private static void TraversalInOrder<T>(this BinaryTreeNode<T> node, List<BinaryTreeNode<T>> traversedNodes)       
        {
            if (node.LeftNode != null)
                BinaryTreeOperations.TraversalInOrder(node.LeftNode, traversedNodes);
            
            traversedNodes.Add(node);
            if (node.RightNode != null)
                BinaryTreeOperations.TraversalInOrder(node.RightNode, traversedNodes);
        }

        private static void TraversalInPostOrder<T>(this BinaryTreeNode<T> node, List<BinaryTreeNode<T>> traversedNodes)       
        {
            if (node.LeftNode != null)
                BinaryTreeOperations.TraversalInPostOrder(node.LeftNode, traversedNodes);
  
            if (node.RightNode != null)
                BinaryTreeOperations.TraversalInPostOrder(node.RightNode, traversedNodes);

            traversedNodes.Add(node);
        }

        public static int GetHeight<T>(this Node<T> node)
        {
            int height = 1;
            var current = node;
            while (current.Parent != null)
            {
                height++;
                current = current.Parent;
            }

            return height;
        }

        public static int GetMaxHeight<T>(this Tree<BinaryTreeNode<T>> tree)
        {
            int maxHeight = 0; 
            var traversedNodes = new List<BinaryTreeNode<T>>();
            tree.Traversal(traversedNodes, BinaryTreeOperations.TraversalTypeEnum.IN_ORDER);
            foreach (var currentNode in traversedNodes)
            {
                int currentNodeHeight = BinaryTreeOperations.GetHeight(currentNode);

                if (currentNodeHeight > maxHeight)
                    maxHeight = currentNodeHeight;
            }

            return maxHeight;
        }
    }
}