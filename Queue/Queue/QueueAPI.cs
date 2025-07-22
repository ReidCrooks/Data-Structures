﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class QueueAPI<QType>
    {

        private LinkedListAPI<QType> list;
        public QueueAPI()
        {
            list = new LinkedListAPI<QType>();
        }

        public void Enqueue(QType item)
        {
            list.AddTail(item);
        }

        public QType? DeQueue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return list.RemoveHead();
        }

        public QType? Peek()
        {
            return list.Get(0);
        }

        public int Size()
        {
            return list.Size();
        }

        public bool IsEmpty()
        {
            if (Size() == 0)
            {
                return true;
            }
            return false;
        }

        public QType PeekAhead(int num)
        {
            return list.Get(num);
        }

        public void printArray()
        {
            list.printList();
        }
    }
}