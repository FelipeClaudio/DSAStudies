using System;
using System.Collections.Generic;

namespace Trees
{
    public class Program
    {
        static void Main(string[] args)
        {
            var initializer = new TreeInitializer();
            var basicTree = initializer.GetBasicTreePopulated();
            var binaryTree = initializer.GetBinaryTreePopulated();
            var traversedNodes = new List<BinaryTreeNode<int>>();

            System.Console.WriteLine("Traversal in pre-order.");
            binaryTree.Traversal(traversedNodes, BinaryTreeOperations.TraversalTypeEnum.PRE_ORDER);
            traversedNodes.ForEach(node => System.Console.WriteLine(node.Data));
            traversedNodes.Clear();

            System.Console.WriteLine("Traversal in order.");
            binaryTree.Traversal(traversedNodes, BinaryTreeOperations.TraversalTypeEnum.IN_ORDER);
            traversedNodes.ForEach(node => System.Console.WriteLine(node.Data));
            traversedNodes.Clear();

            System.Console.WriteLine("Traversal in post-order.");
            binaryTree.Traversal(traversedNodes, BinaryTreeOperations.TraversalTypeEnum.POST_ORDER);
            traversedNodes.ForEach(node => System.Console.WriteLine(node.Data));
            traversedNodes.Clear();

            int maxHeight = binaryTree.GetMaxHeight();
            System.Console.WriteLine($"Tree's max height is {maxHeight}");

            var binarySearchTree = new BinarySearchTree<BinarySearchTreeNode<int>, int>();
            binarySearchTree.InsertValue(2);
            binarySearchTree.InsertValue(4);
            binarySearchTree.InsertValue(3);
            binarySearchTree.InsertValue(5);
            binarySearchTree.InsertValue(10);
            binarySearchTree.InsertValue(8);
            binarySearchTree.InsertValue(9);
            binarySearchTree.InsertValue(1);
            binarySearchTree.RemoveValue(1);
            binarySearchTree.RemoveValue(4);
            binarySearchTree.RemoveValue(5);
            binarySearchTree.RemoveValue(3);
            binarySearchTree.RemoveValue(8);
            binarySearchTree.RemoveValue(10);
            binarySearchTree.RemoveValue(9);
            binarySearchTree.InsertValue(4);
            binarySearchTree.InsertValue(3);
            binarySearchTree.InsertValue(5);
            binarySearchTree.InsertValue(1);
            binarySearchTree.InsertValue(10);
            binarySearchTree.InsertValue(8);
            binarySearchTree.InsertValue(9);
        }
    }
}
