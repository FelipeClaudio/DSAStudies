public class Graph<T>
{
    private bool _isWeighted;
    private bool _isDirected;
    public readonly List<Node<T>> Nodes = new List<Node<T>>();
    public readonly List<Edge<T>> Edges = new List<Edge<T>>();

    public Graph(bool isWeighted, bool isDirected)
    {
        this._isWeighted = isWeighted;
        this._isDirected = isDirected;
    }

    public Node<T> this[int Id] => this.Nodes.FirstOrDefault(node => node.Id == Id);

    public Edge<T> this[Node<T> from, Node<T> to] => this.Edges.FirstOrDefault(edge => edge.From.Id == from.Id && edge.To.Id == to.Id);

    public Node<T> AddNode(T data)
    {
        var node = new Node<T>(data);
        int? lastNodeId = this.Nodes.LastOrDefault()?.Id;
        node.Id = lastNodeId + 1 ?? 1; 
        this.Nodes.Add(node);
        return node;
    }

    public void AddEdge(Node<T> from, Node<T> to, int? weight = null)
    {
        if (this[from, to] == null)
        {
            if (this._isWeighted == true && weight.HasValue)
                this.Edges.Add(new Edge<T>(from, to, weight.Value));
            else
                this.Edges.Add(new Edge<T>(from, to, 1));
            
            from.Neighbors.Add(to);

            // The path starting at "to" and finish at "from" is also added
            // if it doesn't already exist in an undirected and unweighted
            if (this._isDirected == false && this._isWeighted == false && this[to, from] == null)
                this.Edges.Add(new Edge<T>(to, from, 1));            
        }
    }

    public void RemoveEdge(Node<T> from, Node<T> to)
    {
        Edge<T> edge = this[from, to];
        if (edge != null)
            this.Edges.Remove(edge);
    }

    public void RemoveNode(Node<T> node)
    {
        this.Nodes.Remove(node);
        IEnumerable<Edge<T>> edgesContainingNode = this.Edges.Where(edge => edge.From == node || edge.To == node);
        this.Edges.RemoveAll(edge => edgesContainingNode.Contains(edge));
    }
}