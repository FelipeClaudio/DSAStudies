// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var graph = new Graph<string>(true, true);
Node<string> n1 = graph.AddNode("first");
Node<string> n2 = graph.AddNode("second");
Node<string> n3 = graph.AddNode("third");
Node<string> n4 = graph.AddNode("fourth");
Node<string> n5 = graph.AddNode("fifth");

graph.AddEdge(n1, n2, 3);
graph.AddEdge(n2, n3, 5);
graph.AddEdge(n3, n1, 1);
graph.AddEdge(n4, n1, 6);
graph.AddEdge(n4, n5, 1);
graph.AddEdge(n5, n3, 2);

var edge = graph[n4, n1];

graph.RemoveNode(n1);
graph.RemoveEdge(n4, n5);