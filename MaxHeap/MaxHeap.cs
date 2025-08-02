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
        
    }

    public int Parent(int pos)
    {
        return pos / 2;
    }

    public int getRoot()
    {
        return heap.Get(1);
    }

    static void Main(string[] args)
    {
        MaxHeap heap = new MaxHeap();
        Console.WriteLine("MaxHeap initialized successfully.");

        heap.Add(1);
        heap.Add(4);
        heap.Add(2);
        Console.WriteLine(heap.getRoot());
    }

}
