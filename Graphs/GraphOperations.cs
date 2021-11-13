public static class GraphOperations
{
    public enum TraversalTypeEnum
    {
        DFS,
        BFS
    }

    public static List<Node<T>> Traverse<T>(this Graph<T> graph, TraversalTypeEnum traversalTypeEnum)
    {
        switch (traversalTypeEnum)
        {
            case TraversalTypeEnum.DFS:
                return DFS(graph);
            case TraversalTypeEnum.BFS:
                return BFS(graph);
            default:
                return (List<Node<T>>) null;
        }
    }

    private static List<Node<T>> DFS<T>(Graph<T> graph)
    {
        List<Node<T>> nodes = graph.GetNodes();
        bool[] visitedNodes = new bool[nodes.Count];
        var result = new List<Node<T>>();
        DFS(nodes[0], visitedNodes, result);
        return result;
    }

    private static void DFS<T>(Node<T> currentNode, bool[] visitedNodes, List<Node<T>> result)
    {
        visitedNodes[currentNode.Id - 1] = true;
        result.Add(currentNode);
        foreach(Node<T> node in currentNode.Neighbors)
        {
            if (visitedNodes[node.Id - 1] == false)
                DFS(node, visitedNodes, result);
        }
    }

    private static List<Node<T>> BFS<T>(Graph<T> graph)
    {
        List<Node<T>> nodes = graph.GetNodes();
        // BFS(nodes[0], visitedNodes, result);
        return BFS<T>(nodes);
    }

    private static List<Node<T>> BFS<T>(List<Node<T>> nodes)
    {
        bool[] visitedNodes = new bool[nodes.Count];
        visitedNodes[0] = true;
        var result = new List<Node<T>>();
        var queue = new Queue<Node<T>>();
        queue.Enqueue(nodes[0]);

        while(queue.Count > 0)
        {
            Node<T> currentNode = queue.Dequeue();        
            result.Add(currentNode);
            
            foreach (Node<T> node in currentNode.Neighbors)
            {
                if (visitedNodes[node.Id - 1] == false)
                {
                    queue.Enqueue(node);
                    visitedNodes[node.Id - 1] = true;
                }
            }
        }

        return result;
    }

    private static void BFSRecursive<T>(Node<T> currentNode, bool[] visitedNodes, List<Node<T>> result)
    {
        var notVisitedNeighbors = new List<Node<T>>();
        foreach (Node<T> node in currentNode.Neighbors)
        {
            if (visitedNodes[node.Id - 1] == false)
            {
                result.Add(node);
                visitedNodes[node.Id - 1] = true;
                notVisitedNeighbors.Add(node);
            }
        }

        notVisitedNeighbors.ForEach(node => BFSRecursive(node, visitedNodes, result));
    }
}