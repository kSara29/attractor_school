using home_work26;

public class Program
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new MyStack<int>();
        stack.Push(5);
        stack.Push(2);
        stack.Push(7);
        stack.Pop();
        stack.Pop();
        stack.Push(1);
        stack.Push(3);
        stack.Push(9);
        stack.Pop();
        stack.Visualizer();
        Console.WriteLine("");

        MyQueue<string> queue = new MyQueue<string>();
        queue.Enqueue("Sara");
        queue.Enqueue("Laura");
        queue.Enqueue("Angelina");
        queue.Enqueue("Madina");
        queue.Dequeue();
        queue.Dequeue();
        queue.Enqueue("Assel");
        queue.Enqueue("Abai");
        queue.Dequeue();
        queue.Enqueue("Marlen");
        queue.Visualizer();
    }
}
