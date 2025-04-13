using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        var reader = new StreamReader(Console.OpenStandardInput());
        var writer = new StringBuilder();

        int n = int.Parse(reader.ReadLine());
        var heap = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int x = int.Parse(reader.ReadLine());

            if (x == 0)
            {
                if (heap.Count == 0)
                {
                    writer.AppendLine("0");
                }
                else
                {
                    writer.AppendLine(Pop(heap).ToString());
                }
            }
            else
            {
                Push(heap, x);
            }
        }

        Console.Write(writer);
    }

    static void Push(List<int> heap, int value)
    {
        heap.Add(value);
        int c = heap.Count - 1;
        while (c > 0)
        {
            int p = (c - 1) / 2;
            if (Compare(heap[c], heap[p]) >= 0)
                break;
            Swap(heap, c, p);
            c = p;
        }
    }

    static int Pop(List<int> heap)
    {
        int ret = heap[0];
        int last = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        if (heap.Count == 0)
            return ret;

        heap[0] = last;
        int p = 0;
        while (true)
        {
            int left = p * 2 + 1;
            int right = p * 2 + 2;
            int smallest = p;

            if (left < heap.Count && Compare(heap[left], heap[smallest]) < 0)
                smallest = left;
            if (right < heap.Count && Compare(heap[right], heap[smallest]) < 0)
                smallest = right;

            if (smallest == p)
                break;

            Swap(heap, p, smallest);
            p = smallest;
        }
        return ret;
    }

    static int Compare(int a, int b)
    {
        int absA = Math.Abs(a);
        int absB = Math.Abs(b);

        if (absA != absB)
            return absA.CompareTo(absB);
        else
            return a.CompareTo(b);
    }

    static void Swap(List<int> heap, int i, int j)
    {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}
