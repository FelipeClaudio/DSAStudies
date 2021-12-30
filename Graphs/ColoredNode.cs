public class ColoredNode<T> : Node<T>
{
    public ColoredNode(T data) : base(data) 
    {
        Color = ColorsEnum.NO_COLOR;
    }

    public ColorsEnum Color { get; set; }
}

public enum ColorsEnum{
    NO_COLOR,
    RED,
    GREEN,
    BLUE,
    VIOLET
}