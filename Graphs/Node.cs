public class Node<T>
{
    public int Id { get; set; }
    public T Data { get; set; }
    public List<Node<T>> Neighbors = new List<Node<T>>();

    public Node(T data)
    {
        this.Data = data;
    }
}