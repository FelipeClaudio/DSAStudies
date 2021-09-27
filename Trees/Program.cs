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
            bool finishExecution = false;
            // do
            // {
            //     System.Console.WriteLine("Insert element value");
            //     string val = Console.ReadLine();
            //     var elementValue = Convert.ToInt32(val);
            //     binarySearchTree.InsertValue(elementValue);

            //     System.Console.WriteLine("Press escape to finish execution");
            //     finishExecution = Console.ReadKey().Key == ConsoleKey.Escape;
            // }while(finishExecution==false);
            binarySearchTree.InsertValue(2);
            binarySearchTree.InsertValue(4);
            binarySearchTree.InsertValue(3);
            binarySearchTree.InsertValue(5);
            binarySearchTree.InsertValue(1);
            
            var x = 1;
        }
    }
}
