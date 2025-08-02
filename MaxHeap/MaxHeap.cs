using System.ComponentModel;
using System.Drawing;
using DataStructures;

public class MaxHeap
{
    private DynamicArrayAPI<int> heap;

    public MaxHeap()
    {
        heap = new DynamicArrayAPI<int>();
        heap.AddEnd(0);
    }

    public void Add(int item)
    {
        heap.AddEnd(item);
        int pos = heap.Size() - 1;
        while (pos > 1 && heap.Get(pos) > heap.Get(Parent(pos)))
        {
            int parent = Parent(pos);
            int temp = heap.Get(parent);

            heap.Set(heap.Get(pos), parent);
            heap.Set(temp, pos);

            pos = Parent(pos);
        }
    }

    public int Next()
    {
        int first = getRoot();
        heap.Set(heap.Get(heap.Size() - 1), 1);
        heap.Remove(heap.Size() - 1);
        HeapifyDown(1);
        return first;
    }

    public int Parent(int pos)
    {
        return pos / 2;
    }

    public void HeapifyDown(int pos)
    {
        while (Left(pos) < heap.Size())
        {
            //Finds larger child of parent
            int largerPos;
            if (heap.Get(Left(pos)) > heap.Get(Right(pos)))
            {
                largerPos = Left(pos);
            }
            else
            {
                largerPos = Right(pos);
            }
            //Swaps parent and child if parent < child
            if (heap.Get(pos) < heap.Get(largerPos))
            {
                int temp = heap.Get(largerPos);
                heap.Set(heap.Get(pos), largerPos);
                heap.Set(temp, pos);
                pos = largerPos;
            }
            else
            {
                break;
            }

        }
    }
    public int Left(int pos)
    {
        return pos * 2;
    }

    public int Right(int pos)
    {
        return 2 * pos + 1;
    }

    public int getRoot()
    {
        return heap.Get(1);
    }

    static void Main(string[] args)
    {
        MaxHeap heap = new MaxHeap();
        heap.Add(3);
        heap.Add(9);
        heap.Add(5);
        heap.Add(6);
        heap.Add(2);

        // Should return 9
        Console.WriteLine(heap.Next());

        // Should return 6 (next largest)
        Console.WriteLine(heap.getRoot());

    }

}
