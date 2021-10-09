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
            var nodeBalancing = new Dictionary<BinarySearchTreeNode<V>, int>();

            foreach(var node in traversedNodes)
            {
                
                if (nodeBalancing.TryGetValue((T)node, out int currentNodeBalancing) == false)
                    currentNodeBalancing = this.GetBalancingForNode((T)node);

                int leftNodeBalance = 0;
                if (node.LeftNode != null && nodeBalancing.TryGetValue((T)node.LeftNode, out int leftNodeBalanceTemp) == false)
                    leftNodeBalance = leftNodeBalanceTemp != 0? leftNodeBalanceTemp : this.GetBalancingForNode((T)node.LeftNode);

                int rightNodeBalance = 0;
                if (node.RightNode != null && nodeBalancing.TryGetValue((T)node.RightNode, out int rightNodeBalanceTemp) == false)
                    rightNodeBalance = rightNodeBalanceTemp != 0? rightNodeBalanceTemp : this.GetBalancingForNode((T)node.RightNode);
                
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
            }  
        }

        private int GetBalancingForNode(T node)
        {
            if ((node.LeftNode == null) && (node.RightNode == null))
                return 1;
            
            int leftNodeBalance = node.LeftNode != null? this.GetBalancingForNode((T)node.LeftNode) : 0;
            int rightNodeBalance = node.RightNode != null? this.GetBalancingForNode((T)node.RightNode) : 0;

            return rightNodeBalance - leftNodeBalance;
        }

        private void RotateLeft(T node)
        {
            T newRootNode = (T)node.RightNode.Parent;
            newRootNode.Parent = node.Parent;
            newRootNode.LeftNode = node;
        }

        private void RotateRight(T node){}
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