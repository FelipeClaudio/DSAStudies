using System.Collections.Generic;

namespace Trees
{
    public class TreeInitializer
    {
        public Tree<BinaryTreeNode<int>> GetBinaryTreePopulated()
        {
            var tree = new Tree<BinaryTreeNode<int>>
            {
                Root = new BinaryTreeNode<int>()
                {
                    Data = 1
                }
            };

            tree.Root.LeftNode = new BinaryTreeNode<int>()
            {
                Data = 9,
                LeftNode = new BinaryTreeNode<int>()
                {
                    Data = 5,

                },
                RightNode = new BinaryTreeNode<int>()
                {
                    Data = 6,
                    LeftNode = new BinaryTreeNode<int>
                    {
                        Data = 3
                    }
                }
            };

            tree.Root.RightNode = new BinaryTreeNode<int>()
            {
                Data = 4,
                RightNode = new BinaryTreeNode<int>() 
                {
                    Data = 2,
                    LeftNode = new BinaryTreeNode<int>
                    {
                        Data = 7,
                        RightNode = new BinaryTreeNode<int>
                        {
                            Data = 8
                        }
                    }
                }
            };

            AdjustReferencesInBinaryTree(tree.Root);

            return tree;
        }

        private void AdjustReferencesInBinaryTree(BinaryTreeNode<int> parentNode)
        {
            if (parentNode?.LeftNode != null)
            {
                parentNode.LeftNode.Parent = parentNode;
                this.AdjustReferencesInBinaryTree(parentNode.LeftNode);
            }
            if (parentNode?.RightNode != null)
            {
                parentNode.RightNode.Parent = parentNode;
                this.AdjustReferencesInBinaryTree(parentNode.RightNode);
            }
        }

        public Tree<Node<int>> GetBasicTreePopulated()
        {
            var tree = new Tree<Node<int>>
            {
                Root = new Node<int>
                {
                    Data = 2,
                    Parent = null
                }
            };

            var children = new List<Node<int>>
            {
                new Node<int>
                {
                    Data = 1,
                    Parent = tree.Root
                },
                new Node<int>
                {
                    Data = 3,
                    Parent = tree.Root
                },
                new Node<int>
                {
                    Data = 4,
                    Parent = tree.Root
                },
            };

            var grandchildren = new List<Node<int>>
            {
                new Node<int>
                {
                    Data = 5,
                    Parent = children[1]
                }
            };
            children[1].Children = grandchildren;

            tree.Root.Children = children;

            return tree;
        }
    }
}