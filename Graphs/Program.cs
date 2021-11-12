// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var graph = new Graph<string>(false, false);
Node<string> n1 = graph.AddNode("first");
Node<string> n2 = graph.AddNode("second");

graph.AddEdge(n1, n2, 3);

var edge = graph[n1, n2];

var x = 1;