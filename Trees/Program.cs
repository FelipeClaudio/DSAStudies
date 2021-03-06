using System;
using System.Collections.Generic;
using System.Linq;

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
            for (int i = 1; i <= 10; i++)
            {
                avlTree.InsertValue(i);
            }

            avlTree.Clear();

            for (int i = 10; i > 0; i--)
            {
                avlTree.InsertValue(i);
            }

            var heapTree = new HeapTree<int>(HeapTree<int>.HeapTypeEnum.MIN);
            
            heapTree.InsertValue(15);
            heapTree.InsertValue(7);
            heapTree.InsertValue(1);
            heapTree.InsertValue(9);
            heapTree.InsertValue(20);
            heapTree.InsertValue(3);
            heapTree.InsertValue(2);
            heapTree.InsertValue(14);
            heapTree.InsertValue(5);
            heapTree.InsertValue(12);

            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine(heapTree.GetRootNode());
            }

            var random = new Random();
            List<int> randomList = Enumerable.Range(0, 10).Select(x => random.Next(1, 200)).ToList();
            var sortedList = HeapTree<int>.Sort(randomList, HeapTree<int>.HeapTypeEnum.MIN);
            sortedList.ForEach(elem => System.Console.WriteLine(elem));
        }
    }
}
