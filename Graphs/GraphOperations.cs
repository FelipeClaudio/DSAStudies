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
        bool[] visitedNodes = new bool[nodes.Count];
        var result = new List<Node<T>> { nodes[0] };
        BFS(nodes[0], visitedNodes, result);
        return result;
    }

    private static void BFS<T>(Node<T> currentNode, bool[] visitedNodes, List<Node<T>> result)
    {
        visitedNodes[currentNode.Id - 1] = true;
        var notVisitedNeighbors = new List<Node<T>>();
        foreach (Node<T> node in currentNode.Neighbors)
        {
            if (visitedNodes[node.Id - 1] == false && result.Any(r => r.Id == node.Id) == false)
            {
                result.Add(node);
                notVisitedNeighbors.Add(node);
            }
        }

        notVisitedNeighbors.ForEach(node => BFS(node, visitedNodes, result));
    }
}