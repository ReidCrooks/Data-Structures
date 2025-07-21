using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class StackAPI<SType>
    {
        LinkedListAPI<SType> list;


        public StackAPI()
        {
            list = new LinkedListAPI<SType>();
        }


        public void Push(SType item)
        {
            list.AddHead(item);
        }

        public SType? Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return list.RemoveHead();
        }

        public SType? Peek()
        {
            if (IsEmpty())
            {
                return default;
            }
            return list.Get(0);
        }

        public int Size()
        {
            return list.Size();
        }

        public bool IsEmpty()
        {
            if (list.Size() == 0)
            {
                return true;
            }
            return false;
        }

        public void printArray()
        {
            list.printList();
        }

    }
}