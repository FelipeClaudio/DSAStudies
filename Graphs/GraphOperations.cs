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
            default:
                return (List<Node<T>>) null;
        }
    }

    private static List<Node<T>> DFS<T>(Graph<T> graph)
    {
        List<Node<T>> nodes = graph.GetNodes();
        bool[] visitedNodes = new bool[nodes.Count];
        var result = new List<Node<T>>();
        
        return DFS(nodes[0], visitedNodes, result);
    }

    private static List<Node<T>> DFS<T>(Node<T> currentNode, bool[] visitedNodes, List<Node<T>> result)
    {
        visitedNodes[currentNode.Id - 1] = true;
        result.Add(currentNode);
        foreach(Node<T> node in currentNode.Neighboors)
        {
            if (visitedNodes[node.Id - 1] == false)
                DFS(node, visitedNodes, result);
        }

        return result;
    }
}