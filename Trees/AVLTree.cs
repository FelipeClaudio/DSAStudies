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
            base.RemoveValue(value);
            this.BalanceTree();
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
                        this.RotateRightLeft((T)node);
                    else
                        this.RotateLeft((T)node);
                }
                else
                {
                    if (leftNodeBalance > 0)
                        this.RotateLeftRight((T)node);
                    else
                        this.RotateRight((T)node);
                }
                nodeBalancing.Clear();
            }  
        }

        private int GetBalancingForNode(T node, Dictionary<V, int> balancedNodes)
        {         
            int leftNodeLevel = node.LeftNode != null? 
                this.GetMaxNodeLevelFromLeafToRoot((T)node.LeftNode) : 0;         
            int rightNodeLevel = node.RightNode != null? 
                this.GetMaxNodeLevelFromLeafToRoot((T)node.RightNode) : 0;

            int nodeBalancing = rightNodeLevel - leftNodeLevel;
            balancedNodes.TryAdd(node.Data, nodeBalancing);
            return nodeBalancing;
        }

        private int GetMaxNodeLevelFromLeafToRoot(T node)
        {
            if (node == null)
                return 0;

            if (node.LeftNode == null && node.RightNode == null)
                return 1;
            
            return 1 + Math.Max(
                this.GetMaxNodeLevelFromLeafToRoot((T)node.LeftNode),
                this.GetMaxNodeLevelFromLeafToRoot((T)node.RightNode));
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

            this.SetParentReferenceAfterRotating(node, newRootNode);
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

            this.SetParentReferenceAfterRotating(node, newRootNode);
            node.LeftNode = null;
            node.RightNode = null;
        }

        private void SetParentReferenceAfterRotating(T node, T newRootNode)
        {
            if (node.Parent != null)
            {
                T parentNode = (T)node.Parent;
                newRootNode.Parent = parentNode;  
                if (node == parentNode.RightNode)
                    parentNode.RightNode = newRootNode;
                else
                    parentNode.LeftNode = newRootNode;
            }
        }

        private void RotateRightLeft(T node)
        {
            this.RotateRight((T)node.RightNode);
            this.RotateLeft(node);
        }
        private void RotateLeftRight(T node)
        {
            this.RotateLeft((T)node.LeftNode);
            this.RotateRight(node);
        }

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