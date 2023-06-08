namespace home_work_27;

public class MyLinkedList<T> where T: IComparable
{
    List<MyNode<T>> nodes = new List<MyNode<T>>();
    public MyNode<T> First;
    public MyNode<T> Last; 



    public MyNode<T> Add(T element)
    {
        MyNode<T> newNode = new MyNode<T>{ Value = element};
        if( First == null )
        {
            First = newNode;
            Last = newNode;
        }
        else 
        {
            Last.Next = newNode;
            newNode.Previous = Last;
            Last = newNode;
        }

        nodes.Add(newNode);
        
        return newNode;
    }

    public MyNode<T> Add(MyNode<T> node)
    {
        if( First == null )
        {
            First = node;
            Last = node;
        }
        else 
        {
            Last.Next = node;
            node.Previous = Last;
            Last = node;
        }

        nodes.Add(node);
        
        return node;
    }

    public MyNode<T> AddFirst(T element)
    {
        MyNode<T> newNode = new MyNode<T>{ Value = element};

        newNode.Next = First;
        First.Previous = newNode;
        First = newNode;

        nodes.Insert(0, newNode);
        return newNode;
    }
    

    public MyNode<T> AddAfter(MyNode<T> node, T element)
    {
        MyNode<T> newNode = new MyNode<T>{ Value = element};
        int insertedIndex = nodes.BinarySearch(node);

        if(node.Next == null)
        {
            newNode.Next = null;
            newNode.Previous = node;
            node.Next = newNode;
        }
        else
        {
            newNode.Next = node.Next;
            newNode.Previous = node;
            node.Next.Previous = newNode;
            node.Next = newNode;
        }

        nodes.Insert(insertedIndex + 1, newNode);
        return newNode;
    }

    public MyNode<T> AddBefore(MyNode<T> node, T element)
    {
        MyNode<T> newNode = new MyNode<T>{ Value = element};
        int insertedIndex = nodes.BinarySearch(node);

        if(node.Previous == null)
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous = newNode;
            First = newNode;
        }

        else
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
        }

        nodes.Insert(insertedIndex, newNode);
        return newNode;
    }

    public void Clear()
    {
        nodes.Clear();

        MyNode<T> currentNode = First;
        while(currentNode != null)
        {
            MyNode<T> nextNode = currentNode.Next;
            currentNode.Previous = null;
            currentNode.Next = null;
            currentNode = nextNode;

        }
        First = null;
        Last = null;
    }

    public void RemoveLast()
    {
        if(First == Last)
        {
            First = null;
            Last = null;
        }
        else
        {
            Last = Last.Previous;
            Last.Next = null;
        }

        nodes.RemoveAt(nodes.Count - 1);
    }

    public void RemoveFirst()
    {
        if(First == Last)
        {
            First = null;
            Last = null;
        }
        else
        {
            First = First.Next;
            First.Previous = null;
        }

        nodes.RemoveAt(0);
    }

    public new Type GetType()
    {
        return typeof(MyLinkedList<T>);
    }
}