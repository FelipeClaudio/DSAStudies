public class Node<T>
{
    public int Id { get; set; }
    public T Data { get; set; }

    public Node(T data)
    {
        this.Data = data;
    }
}