using System.Collections.Generic;

namespace Trees
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode<T> LeftNode { get => (BinaryTreeNode<T>) Children[0]; set => Children[0] = value; }
        public BinaryTreeNode<T> RightNode { get => (BinaryTreeNode<T>) Children[1]; set => Children[1] = value; }

        public BinaryTreeNode()
        {
            this.Children = new List<Node<T>> {null, null};
        }
    }
}