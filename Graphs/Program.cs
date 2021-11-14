var graph = new Graph<string>(isWeighted: true, isDirected: true);
Node<string> n1 = graph.AddNode("first");
Node<string> n2 = graph.AddNode("second");
Node<string> n3 = graph.AddNode("third");
Node<string> n4 = graph.AddNode("fourth");
Node<string> n5 = graph.AddNode("fifth");
Node<string> n6 = graph.AddNode("sixth");
Node<string> n7 = graph.AddNode("seventh");
Node<string> n8 = graph.AddNode("eighth");

graph.AddEdge(n1, n2, 9);
graph.AddEdge(n1, n3, 5);
graph.AddEdge(n2, n1, 3);
graph.AddEdge(n3, n4, 12);
graph.AddEdge(n2, n4, 18);
graph.AddEdge(n4, n2, 2);
graph.AddEdge(n5, n4, 9);
graph.AddEdge(n4, n8, 8);
graph.AddEdge(n5, n8, 3);
graph.AddEdge(n8, n5, 3);
graph.AddEdge(n5, n6, 2);
graph.AddEdge(n5, n7, 5);
graph.AddEdge(n7, n5, 4);
graph.AddEdge(n7, n8, 6);
graph.AddEdge(n6, n7, 1);

System.Console.WriteLine("DFS:");
List<Node<string>> dfsTraversalResult = graph.Traverse(GraphOperations.TraversalTypeEnum.DFS);
dfsTraversalResult.ForEach(t => System.Console.WriteLine(t.Data));

System.Console.WriteLine("BFS:");
List<Node<string>> bfsTraversalResult = graph.Traverse(GraphOperations.TraversalTypeEnum.BFS);
bfsTraversalResult.ForEach(t => System.Console.WriteLine(t.Data));

var edge = graph[n4, n1];

graph.RemoveNode(n1);
graph.RemoveEdge(n4, n5);

var spanningTreeGraph = new Graph<string>(isWeighted: true, isDirected: false);
Node<string> nt1 = spanningTreeGraph.AddNode("first");
Node<string> nt2 = spanningTreeGraph.AddNode("second");
Node<string> nt3 = spanningTreeGraph.AddNode("third");
Node<string> nt4 = spanningTreeGraph.AddNode("fourth");
Node<string> nt5 = spanningTreeGraph.AddNode("fifth");
Node<string> nt6 = spanningTreeGraph.AddNode("sixth");
Node<string> nt7 = spanningTreeGraph.AddNode("seventh");
Node<string> nt8 = spanningTreeGraph.AddNode("eighth");

spanningTreeGraph.AddEdge(nt1, nt2, 3);
spanningTreeGraph.AddEdge(nt1, nt3, 5);
spanningTreeGraph.AddEdge(nt2, nt4, 4);
spanningTreeGraph.AddEdge(nt3, nt4, 2);
spanningTreeGraph.AddEdge(nt4, nt5, 9);
spanningTreeGraph.AddEdge(nt4, nt8, 8);
spanningTreeGraph.AddEdge(nt5, nt8, 1);
spanningTreeGraph.AddEdge(nt5, nt7, 5);
spanningTreeGraph.AddEdge(nt7, nt8, 20);
spanningTreeGraph.AddEdge(nt5, nt6, 4);
spanningTreeGraph.AddEdge(nt6, nt7, 6);

System.Console.WriteLine("Krukal's");
List<Edge<string>> kruskalEdges = spanningTreeGraph.GetMinimunSpanningTree(GraphOperations.SpanningTreeAlgorithm.KRUSKAL);
kruskalEdges.ForEach(edge => System.Console.WriteLine($"({edge.To.Id}, {edge.From.Id}) => {edge.Weight}"));