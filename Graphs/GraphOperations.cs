public static class GraphOperations
{
    public enum TraversalTypeEnum
    {
        DFS,
        BFS
    }

    public enum SpanningTreeAlgorithm
    {
        KRUSKAL,
        PRIM
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
                throw new ArgumentOutOfRangeException(nameof(traversalTypeEnum));
        }
    }

    private static List<Node<T>> DFS<T>(Graph<T> graph)
    {
        List<Node<T>> nodes = graph.Nodes;
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
        List<Node<T>> nodes = graph.Nodes;
        // BFSRecursive(nodes[0], visitedNodes, result);
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

    public static List<Edge<T>> GetMinimunSpanningTree<T>(this Graph<T> graph, SpanningTreeAlgorithm spanningTreeAlgorithm)
    {
        switch (spanningTreeAlgorithm)
        {
            case SpanningTreeAlgorithm.KRUSKAL:
                return Kruskal(graph);
            case SpanningTreeAlgorithm.PRIM:
                return Prim(graph);
            default:
                throw new ArgumentOutOfRangeException(nameof(spanningTreeAlgorithm));
        }
    }

    // This algorithm takes the minimal cost edge, even thought it is not
    // connect to any of the edges in the subset.
    private static List<Edge<T>> Kruskal<T>(Graph<T> graph)
    {
        // Each node will be a single subset in the begining.
        // In the end, all nodes will be merged in a single subset.
        var subsets = new List<List<int>>();
        foreach (Node<T> node in graph.Nodes)
            subsets.Add(new List<int>{node.Id});

        var minimumEdges = new Queue<Edge<T>>();
        graph.Edges.OrderBy(e => e.Weight).ToList().ForEach(e => minimumEdges.Enqueue(e));

        var selectedEdges = new List<Edge<T>>();
        while(selectedEdges.Count < graph.Nodes.Count - 1)
        {
            Edge<T> minimumEdge = minimumEdges.Dequeue();
            var fromNodeSubset = subsets.Single(subset => subset.Contains(minimumEdge.From.Id));
            var toNodeSubset = subsets.Single(subset => subset.Contains(minimumEdge.To.Id));
            if (fromNodeSubset != toNodeSubset)
            {
                Union(subsets, minimumEdge.From, minimumEdge.To);
                selectedEdges.Add(minimumEdge);
            }
        }

        return selectedEdges;
    }

    private static void Union<T>(List<List<int>> subsets, Node<T> nodeA, Node<T> nodeB)
    {
        List<int> subsetOfNodeA = subsets.Single(subset => subset.Contains(nodeA.Id));
        List<int> subsetOfNodeB = subsets.Single(subset => subset.Contains(nodeB.Id));
        subsetOfNodeA.AddRange(subsetOfNodeB);
        
        // Older node must be removed in order to keep node id in only one list.
        subsets.Remove(subsetOfNodeB);
    }

    // This algorithm takes the edge with the lowest weight that is already
    // connected to any node in subset.
    private static List<Edge<T>> Prim<T>(Graph<T> graph)
    {
        // Each node will be a single subset in the begining.
        // In the end, all nodes will be merged in a single subset.
        var subsets = new List<List<int>>();
        foreach (Node<T> node in graph.Nodes)
            subsets.Add(new List<int>{node.Id});

        List<Edge<T>> originalEdges = new List<Edge<T>>(graph.Edges);
        Node<T> initialNode = graph.Nodes[0];
        var minimumEdges = new List<Edge<T>>();
        graph.Edges.Where(edge => edge.From == initialNode)
                .OrderBy(edge => edge.Weight)
                .ToList()
                .ForEach(edge => minimumEdges = UpdateMinimumEdges(minimumEdges, originalEdges, edge));

        var selectedEdges = new List<Edge<T>>();
        while(selectedEdges.Count < graph.Nodes.Count - 1)
        {
            Edge<T> minimumLocalEdge = minimumEdges[0];  

            var fromNodeSubset = subsets.Single(subset => subset.Contains(minimumLocalEdge.From.Id));
            var toNodeSubset = subsets.Single(subset => subset.Contains(minimumLocalEdge.To.Id));
            if (fromNodeSubset != toNodeSubset)
            {
                Union(subsets, minimumLocalEdge.From, minimumLocalEdge.To);
                selectedEdges.Add(minimumLocalEdge);
                minimumEdges = UpdateMinimumEdges(minimumEdges, originalEdges, minimumLocalEdge);
            }

            minimumEdges.Remove(minimumLocalEdge);
        }

        return selectedEdges;
    }

    private static List<Edge<T>> UpdateMinimumEdges<T>(List<Edge<T>> minimumEdges, List<Edge<T>> originalEdges, Edge<T> newEdge)
    {
        IEnumerable<Edge<T>> connectedEdges = originalEdges.Where(edge => (edge.To == newEdge.To || edge.From == newEdge.To
            || edge.To == newEdge.From || edge.From == newEdge.From));

        minimumEdges.AddRange(connectedEdges);
        return minimumEdges.OrderBy(edge => edge.Weight).ToList();
    }

    public static void ColorNodes<T>(this ColoredGraph<T> coloredGraph)
    {
        var colorEnumList = Enum.GetValues<ColorsEnum>()
            .Where(color => color != ColorsEnum.NO_COLOR)
            .ToList();
        foreach (var node in coloredGraph.Nodes)
        {
            foreach (var color in colorEnumList)
            {
               if (node.Neighbors.Any(n => ((ColoredNode<T>) n).Color == (ColorsEnum) color) == false)
               {
                ((ColoredNode<T>) node).Color = (ColorsEnum) color;
                    break;
               }
            }
        }
    }

    public static List<int> GetShortestPathDjikstra<T>(this Graph<T> graph, Node<T> source, Node<T> target)
    {
        // Initialize distances array with max values.
        // Only the source node is initialized with 0.
        List<int> distances = new(graph.Nodes.Count);
        distances.AddRange(graph.Nodes.Select(node => Int32.MaxValue));
        distances[source.Id - 1] = 0;

        List<Node<T>> traversedNodes = new(graph.Nodes.Count);
        traversedNodes.Add(source);

        // It stores informations about all available neighbors 
        // that are connected to previously traversed nodes.
        PriorityQueue<Node<T>, int> availableNeighbors = new();

        var currentNode = source;
        while (traversedNodes.Count != graph.Nodes.Count)
        {
            var availableEdges = graph.Edges.Where(e => e.From.Id == currentNode.Id).ToList();
            
            // Edges related to previously traversed nodes must be removed.
            var edgesToRemove = (from edge in availableEdges
                join node in traversedNodes on edge.To.Id equals node.Id
                select edge).ToList();
            edgesToRemove?.ForEach(edge => availableEdges.Remove(edge));
            
            foreach (var edge in availableEdges)
            {
                availableNeighbors.Enqueue(edge.To, edge.Weight);

                // Changes distance if new calculated distance is less than current one.
                if (edge.Weight + distances[currentNode.Id -1] < distances[edge.To.Id -1])
                    distances[edge.To.Id - 1] = edge.Weight + distances[currentNode.Id -1];
            }

            // Only selects not traversed nodes.
            do{
                currentNode = availableNeighbors.Dequeue();
            }
            while(traversedNodes.Any(node => node.Id == currentNode.Id)); 

            traversedNodes.Add(currentNode);
        }

        return distances;
    }
}