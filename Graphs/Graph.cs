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

    public Edge<T> this[Node<T> from, Node<T> to]
    {
        get
        {
            if (from == null || to == null)
                return null;

            return this._edges.FirstOrDefault(edge => edge.From.Id == from.Id && edge.To.Id == to.Id);
        }
    }

    public Node<T> AddNode(T data)
    {
        var node = new Node<T>(data);
        this._nodes.Add(node);
        return node;
    }

    public void AddEdge(Node<T> from, Node<T> to, int weight = 1)
    {
        if (this._isDirected == false && this._isWeighted == false)
            this._edges.Add(new Edge<T>(to, from, weight));

        this._edges.Add(new Edge<T>(from, to, weight));
        this.UpdateIds();
    }

    private void UpdateIds()
    {
        int i = 1;
        this._nodes.ForEach(node => node.Id = i++);
    }
}