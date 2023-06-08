namespace home_work26;

public class MyQueue<T>: BaseClass<T>
{
    private T[] queue;
    private int head;
    private int tail;
    private int capacity = 1;

    public MyQueue()
    {
        queue = new T[capacity];
        head = 0;
        tail = 0;
    }

    // добавление в начало
    public void Enqueue(T element)
    {
        if(tail == capacity)
        {
            capacity += 1;
            T[] new_queue = new T[capacity];
            Array.Copy(queue, new_queue, queue.Length);
            queue = new_queue;
            queue[tail] = element;
            tail ++;
        }
        else
        {
            queue[tail] = element;
            tail ++;
        }
    }

    public T Dequeue()
    {
        try
        {
            T current_head = queue[head];
            T[] new_queue_less = new T[queue.Length - 1];
            Array.Copy(queue, 1, new_queue_less, 0, new_queue_less.Length);
            queue = new_queue_less;
            tail --;
            capacity --;
            return current_head;  
        }
        catch
        {
            Console.Write("Очередь пуста");
            return default(T);
        }
    }

    public override void Visualizer(){
        Console.Write("\nТекущая очередь: ");
        foreach(T item in queue)
        {
            Console.Write($"{item}  ");
        }
        Console.WriteLine("\n");
    }
}