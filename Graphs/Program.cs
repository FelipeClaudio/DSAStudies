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