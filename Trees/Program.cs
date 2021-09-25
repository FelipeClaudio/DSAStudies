using System;
using System.Collections.Generic;

namespace Trees
{
    public class Program
    {
        static void Main(string[] args)
        {
            var initializer = new TreeInitializer();
            var binaryTreeOperations = new BinaryTreeOperations();
            var basicTree = initializer.GetBasicTreePopulated();
            var binaryTree = initializer.GetBinaryTreePopulated();
            var traversedNodes = new List<BinaryTreeNode<int>>();

            System.Console.WriteLine("Traversal in pre-order.");
            binaryTreeOperations.TraversalInPreOrder(binaryTree.Root, traversedNodes);
            traversedNodes.ForEach(node => System.Console.WriteLine(node.Data));
            traversedNodes.Clear();

            System.Console.WriteLine("Traversal in order.");
            binaryTreeOperations.TraversalInOrder(binaryTree.Root, traversedNodes);
            traversedNodes.ForEach(node => System.Console.WriteLine(node.Data));
            traversedNodes.Clear();

            System.Console.WriteLine("Traversal in post-order.");
            binaryTreeOperations.TraversalInPostOrder(binaryTree.Root, traversedNodes);
            traversedNodes.ForEach(node => System.Console.WriteLine(node.Data));
            traversedNodes.Clear();

            int maxHeight = binaryTreeOperations.GetMaxHeight(binaryTree.Root);
            System.Console.WriteLine($"Tree's max height is {maxHeight}");
        }
    }
}
