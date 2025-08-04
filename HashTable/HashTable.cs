namespace DataStructures;

public class HashTable<HType>
{
    private LinkedListAPI<HType>[] bins;

    public HashTable() : this(100) { }
    public HashTable(int numBins)
    {
        bins = new LinkedListAPI<HType>[numBins];
        for (int i = 0; i < bins.Length; i++)
        {
            bins[i] = new LinkedListAPI<HType>();
        }
    }

    public void Add(HType item)
    {
        int index = Math.Abs(item.GetHashCode()) % bins.Length;
        bins[index].AddAt(item, index);
    }

    public HType? Remove(HType item)
    {
        HType newItem = default;

        if (Has(item))
        {
            int bin = GetBin(item);
            LinkedListAPI<HType> list = bins[bin];
            for (int i = 0; i < list.Size(); i++)
            {
                if (list.Get(i).Equals(item))
                {
                    newItem = list.Get(i);
                    list.RemoveAt(i);
                    break;
                }
            }

        }
        return newItem;
    }

    public bool Has(HType item)
    {
        int bin = GetBin(item);
        LinkedListAPI<HType> list = bins[bin];

        for (int i = 0; i < list.Size(); i++)
        {
            if (list.Get(i).Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    private int GetBin(HType item)
    {
        return Math.Abs(item.GetHashCode()) % bins.Length;
    }

}

