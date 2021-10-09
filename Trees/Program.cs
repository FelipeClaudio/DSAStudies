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
            initializer.PopulateBinarySearchTree(binarySearchTree);

            var avlTree = new AVLTree<BinarySearchTreeNode<int>, int>();
            avlTree.InsertValue(1);
            avlTree.InsertValue(2);
            avlTree.InsertValue(3);
            // avlTree.InsertValue(3);
            // avlTree.InsertValue(2);
            // avlTree.InsertValue(1);
        }
    }
}
