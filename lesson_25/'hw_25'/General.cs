namespace hw_25;
using System;

public class General<T> where T : IComparable
{
    public T[] SortArray(T[] array)
    {
        T[] sortedArray = new T[array.Length];
        Array.Copy(array, sortedArray, array.Length);
        Array.Sort(sortedArray);
        PrintArray(sortedArray, 1);
        return sortedArray;
    }

    public T[] ReverseArray(T[] array)
    {
        T[] reversedArray = new T[array.Length];
        Array.Copy(array, reversedArray, array.Length);
        Array.Reverse(reversedArray);
        PrintArray(reversedArray, 2);
        return reversedArray;
    }

    private void PrintArray(T[] array, int s)
    {
        if(s == 1) Console.WriteLine("Sorted array:");
        else Console.WriteLine("Reversed array:");
        
        foreach(T i in array)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine("\n");
    }
}
