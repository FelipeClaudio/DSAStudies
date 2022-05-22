public class ColoredGraph<T> : Graph<T>
{
    public ColoredGraph(bool isWeighted, bool isDirected) : base(isWeighted, isDirected) {}

    public ColoredNode<T> AddColoredNode(T data)
    {
        var node = new ColoredNode<T>(data);
        int? lastNodeId = this.Nodes.LastOrDefault()?.Id;
        node.Id = lastNodeId + 1 ?? 1; 
        this.Nodes.Add(node);
        return node;
    }
}