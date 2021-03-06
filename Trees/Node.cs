using System.Collections.Generic;

namespace Trees
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }
    }
}