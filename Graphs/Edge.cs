public class Edge<T>
{
    public Node<T> From { get; set; }
    public Node<T> To { get; set; }
    public int Weight { get; set; }

    public Edge(Node<T> from, Node<T> to, int weight)
    {
        this.From = from;
        this.To = to;
        this.Weight = weight;
    }
}