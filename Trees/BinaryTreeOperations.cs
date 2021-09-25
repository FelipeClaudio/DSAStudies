using System.Collections.Generic;

namespace Trees
{
    public class BinaryTreeOperations
    {
        public void TraversalInPreOrder<T>(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> traversedNodes)       
        {
            traversedNodes.Add(node);
            if (node.LeftNode != null)
                this.TraversalInPreOrder(node.LeftNode, traversedNodes);
            
            if (node.RightNode != null)
                this.TraversalInPreOrder(node.RightNode, traversedNodes);
        }

        public void TraversalInOrder<T>(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> traversedNodes)       
        {
            if (node.LeftNode != null)
                this.TraversalInOrder(node.LeftNode, traversedNodes);
            
            traversedNodes.Add(node);
            if (node.RightNode != null)
                this.TraversalInOrder(node.RightNode, traversedNodes);
        }

        public void TraversalInPostOrder<T>(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> traversedNodes)       
        {
            if (node.LeftNode != null)
                this.TraversalInPostOrder(node.LeftNode, traversedNodes);
  
            if (node.RightNode != null)
                this.TraversalInPostOrder(node.RightNode, traversedNodes);

            traversedNodes.Add(node);
        }

        public int GetHeight<T>(Node<T> node)
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

        public int GetMaxHeight<T>(BinaryTreeNode<T> node)
        {
            int maxHeight = 0;
            var traversedNodes = new List<BinaryTreeNode<T>>();
            this.TraversalInOrder(node, traversedNodes);
            foreach (var currentNode in traversedNodes)
            {
                int currentNodeHeight = this.GetHeight(currentNode);

                if (currentNodeHeight > maxHeight)
                    maxHeight = currentNodeHeight;
            }

            return maxHeight;
        }
    }
}