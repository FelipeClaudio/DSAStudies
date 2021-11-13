public class Graph<T>
{
    private bool _isWeighted;
    private bool _isDirected;
    private readonly List<Node<T>> _nodes = new List<Node<T>>();
    private readonly List<Edge<T>> _edges = new List<Edge<T>>();

    public Graph(bool isWeighted, bool isDirected)
    {
        this._isWeighted = isWeighted;
        this._isDirected = isDirected;
    }

    public Node<T> this[int Id] => this._nodes.FirstOrDefault(node => node.Id == Id);

    public Edge<T> this[Node<T> from, Node<T> to] => this._edges.FirstOrDefault(edge => edge.From.Id == from.Id && edge.To.Id == to.Id);

    public Node<T> AddNode(T data)
    {
        var node = new Node<T>(data);
        int? lastNodeId = this._nodes.LastOrDefault()?.Id;
        node.Id = lastNodeId + 1 ?? 1; 
        this._nodes.Add(node);
        return node;
    }

    public void AddEdge(Node<T> from, Node<T> to, int? weight = null)
    {
        if (this[from, to] == null)
        {
            if (this._isWeighted == true && weight.HasValue)
                this._edges.Add(new Edge<T>(from, to, weight.Value));
            else
                this._edges.Add(new Edge<T>(from, to, 1));
            
            from.Neighbors.Add(to);

            // The path starting at "to" and finish at "from" is also added
            // if it doesn't already exist in an undirected and unweighted
            if (this._isDirected == false && this._isWeighted == false && this[to, from] == null)
                this._edges.Add(new Edge<T>(to, from, 1));            
        }
    }

    public void RemoveEdge(Node<T> from, Node<T> to)
    {
        Edge<T> edge = this[from, to];
        if (edge != null)
            this._edges.Remove(edge);
    }

    public void RemoveNode(Node<T> node)
    {
        this._nodes.Remove(node);
        IEnumerable<Edge<T>> edgesContainingNode = this._edges.Where(edge => edge.From == node || edge.To == node);
        this._edges.RemoveAll(edge => edgesContainingNode.Contains(edge));
    }

    public List<Node<T>> GetNodes() => this._nodes;
}