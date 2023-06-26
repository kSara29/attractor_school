namespace home_work_27;

public class MyNode<T>:IComparable<MyNode<T>>, IEquatable<MyNode<T>>
{
    public T Value { get; set; }
    public MyNode<T> Next { get; set; }
    public MyNode<T> Previous { get; set; }

    public int CompareTo(MyNode<T> other)
    {
        if (other == null)
            return 1;

        return Comparer<T>.Default.Compare(Value, other.Value);
    }

    public bool Equals(MyNode<T> other)
    {
        if (other == null)
            return false;

        return EqualityComparer<T>.Default.Equals(Value, other.Value);
    }

     public void Dispose()
    {
        Dispose();
        GC.SuppressFinalize(this);
    }

    ~MyNode()
    {
        Dispose();
    }
}