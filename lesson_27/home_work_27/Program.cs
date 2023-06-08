using home_work_27;

public class Program
{
    static void Main(string[] args)
    {
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        MyNode<int> node1 = linkedList.Add(5);
        MyNode<int> node2 = linkedList.Add(17);
        MyNode<int> node3 = linkedList.Add(25);

        Console.WriteLine(linkedList.First.Value);
        Console.WriteLine(linkedList.Last.Value); 


        linkedList.AddAfter(node1, 15);
        linkedList.AddBefore(node1, 18);
        linkedList.RemoveLast();
        linkedList.RemoveFirst();
        linkedList.Clear();
        Console.WriteLine(linkedList.GetType());
    }
}