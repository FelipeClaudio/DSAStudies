using System.Collections.Generic;
using System;

namespace Trees
{
    public class AVLTree<T, V> : BinarySearchTree<T, V>
        where T : BinarySearchTreeNode<V>
        where V : IComparable
    {
        public override void InsertValue(V value)
        {
            base.InsertValue(value);
            this.BalanceTree();
        }

        public override void RemoveValue(V value)
        {
        }

        private void BalanceTree()
        {
            if (this.Root == null)
                return;

            var traversedNodes = new List<BinarySearchTreeNode<V>>();
            this.TraversalInOrder((T)this.Root, traversedNodes);
            var nodeBalancing = new Dictionary<V, int>();

            foreach(var node in traversedNodes)
            {
                if (nodeBalancing.TryGetValue(node.Data, out int currentNodeBalancing) == false)
                    currentNodeBalancing = this.GetBalancingForNode((T)node, nodeBalancing);

                int leftNodeBalance = 0;
                if (node.LeftNode != null)
                {
                    bool isBalancingAlreadyCalculated = nodeBalancing.TryGetValue(node.LeftNode.Data, out int balancing);
                    leftNodeBalance = isBalancingAlreadyCalculated? balancing : this.GetBalancingForNode((T)node.LeftNode, nodeBalancing);
                }

                int rightNodeBalance = 0;
                if (node.RightNode != null)
                {
                    bool isBalancingAlreadyCalculated = nodeBalancing.TryGetValue(node.RightNode.Data, out int balancing);
                    rightNodeBalance = isBalancingAlreadyCalculated? balancing : this.GetBalancingForNode((T)node.RightNode, nodeBalancing);
                }

                if (Math.Abs(currentNodeBalancing) <= 1)
                    continue;

                if (currentNodeBalancing > 1)
                {
                    if (rightNodeBalance < 0)
                        this.RotateLeftRight((T)node);
                    else
                        this.RotateLeft((T)node);
                }
                else
                {
                    if (leftNodeBalance > 0)
                        this.RotateRightLeft((T)node);
                    else
                        this.RotateRight((T)node);
                }
                nodeBalancing.Clear();
            }  
        }

        private int GetBalancingForNode(T node, Dictionary<V, int> balancedNodes)
        {
            if ((node.LeftNode == null) && (node.RightNode == null))
            {
                balancedNodes.Add(node.Data, 0);
                return 0;
            }
            
            int leftNodeBalance = 0, rightNodeBalance = 0;
            if (node.LeftNode != null)
            {
                if (balancedNodes.TryGetValue(node.LeftNode.Data, out int nodeBalancing))
                    leftNodeBalance = nodeBalancing - 1;
                else
                {
                    leftNodeBalance = this.GetBalancingForNode((T)node.LeftNode, balancedNodes);
                    leftNodeBalance--;
                    balancedNodes.TryAdd(node.Data, leftNodeBalance);
                }
            }
            if (node.RightNode != null)
            {
                if (balancedNodes.TryGetValue(node.RightNode.Data, out int nodeBalancing))
                    rightNodeBalance = nodeBalancing + 1;
                else
                {
                    rightNodeBalance = this.GetBalancingForNode((T)node.RightNode, balancedNodes);
                    rightNodeBalance++;
                    balancedNodes.TryAdd(node.Data, rightNodeBalance);
                }
            }

            return rightNodeBalance + leftNodeBalance;
        }

        private void RotateLeft(T node)
        {
            T newRootNode = (T)node.RightNode;
            if (node == this.Root)
                this.Root = newRootNode;

            if (newRootNode.LeftNode != null)
                newRootNode.LeftNode.RightNode = node;
            else
                newRootNode.LeftNode = node;

            node.LeftNode = null;
            node.RightNode = null;
        }

        private void RotateRight(T node)
        {
            T newRootNode = (T)node.LeftNode;
            if (node == this.Root)
                this.Root = newRootNode;

            if (newRootNode.RightNode != null)
                newRootNode.RightNode.RightNode = node;
            else
                newRootNode.RightNode = node;

            node.LeftNode = null;
            node.RightNode = null;
        }

        private void RotateRightLeft(T node){}
        private void RotateLeftRight(T node){}

        private void TraversalInOrder(BinarySearchTreeNode<V> node, List<BinarySearchTreeNode<V>> traversedNodes)
        {   
            if (node.LeftNode != null)
                this.TraversalInOrder((T)node.LeftNode, traversedNodes);
            
            traversedNodes.Add(node);
            if (node.RightNode != null)
                this.TraversalInOrder((T)node.RightNode, traversedNodes);
        }
    }
}