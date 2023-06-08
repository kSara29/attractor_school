namespace home_work26;

public class MyStack<T>: BaseClass<T>
{
    private T[] stack;
    private int tail;
    private int capacity = 1;

    public MyStack()
    {
        stack = new T[capacity];
        tail = 0;
    }

    public void Push(T element)
    {
        if(tail == capacity)
        {
            capacity += 1;
            T[] new_stack = new T[capacity];
            Array.Copy(stack, new_stack, stack.Length);
            stack = new_stack;
            stack[tail] = element;
            tail ++;
        }
        else
        {
            stack[tail] = element;
            tail++;
        }
    }

    public T Pop()
    {
        try
        {
            T pre_tail = stack[tail-1];
            tail --;
            capacity --;
            Array.Resize(ref stack, stack.Length - 1);
            return pre_tail;
        }
        catch
        {
            Console.Write("Стек пуст");
            return default(T);
        }
    }

    public override void Visualizer()
    {
        Console.Write("\nТекущий стек: ");
        foreach(T item in stack)
        { 
            Console.Write($"{item}  ");
        }
    }
}