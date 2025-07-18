using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SinglyLinkedList
{
    internal class LinkedListAPI<LType>
    {
        private Node<LType>? head;
        private int num_elements;
        public LinkedListAPI()
        {
            head = null;
            num_elements = 0;
        }

        //Add value to specific index in list
        public void AddAt(LType val, int pos)
        {
            //Adds header if there's no elements in the list or position is 0
            if (pos == 0 || num_elements == 0)
            {
                AddHead(val);
                return;
            }
            if (pos < 0 || pos > num_elements)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            //Logic for node existing in index
            else
            {
                Node<LType>? current = head;
                for (int i = 0; i < pos - 1; i++)
                {
                    current = current!.Next;
                }
                if (current != null)
                {

                    Node<LType> newNode = new Node<LType>(val, current.Next);
                    current.Next = newNode;
                    num_elements++;
                }
                else
                {
                    AddTail(val);
                }
            }
        }

        public LType RemoveAt(int pos)
        {
            if (pos < 0 || pos >= num_elements)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            if (pos == 0)
            {
                return RemoveHead();
            }
            else
            {
                Node<LType>? current = head;
                for (int i = 0; i < pos - 1; i++)
                {
                    current = current!.Next;
                }
                if (current != null)
                {
                    Node<LType>? removedNode = current.Next;
                    current.Next = removedNode!.Next;
                    num_elements--;
                    return removedNode.Data;
                }
                else
                {
                    return RemoveTail();
                }
            }
        }

        public LType Get(int pos)
        {
            if (pos < 0 || pos >= num_elements)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            //Iterates to specified position
            Node<LType>? current = head;
            for (int i = 0; i < pos; i++)
            {
                current = current!.Next;
            }
            return current!.Data;
        }

        public LType Set(LType val, int pos)
        {
            if (pos < 0 || pos >= num_elements)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            if (pos == 0)
            {
                LType oldValue = Get(0);
                RemoveHead();
                AddHead(val);
                return oldValue;
            }
            Node<LType>? current = head;
            Node<LType>? prev = null;
            for (int i = 0; i < pos; i++)
            {
                prev = current;
                current = current!.Next;
            }

            LType currentData = current!.Data;
            current.Data = val;
            prev.Next = current;
            return currentData;

        }

        public int Size()
        {
            return num_elements;
        }
        //Add node to head of list
        public void AddHead(LType item)
        {
            if (num_elements == 0)
            {
                Node<LType>? newNode = new Node<LType>(item, null);
                head = newNode;
                num_elements++;
            }
            else
            {
                Node<LType>? newNode = new Node<LType>(item, head);
                head = newNode;
                num_elements++;
            }

        }
        //Add node to tail of list
        public void AddTail(LType item)
        {
            if (head == null)
            {
                head = new Node<LType>(item, null);
            }
            else
            {
                Node<LType> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current!.Next = new Node<LType>(item, null);
            }
            num_elements++;
        }
        public LType RemoveHead()
        {
            if (head == null)
            {
                return default;
            }
            else
            {

                Node<LType>? removedHead = head;
                head = head.Next;
                num_elements--;
                return removedHead.Data;
            }
        }

        public LType RemoveTail()
        {
            //No nodes in list
            if (head == null)
            {
                return default;
            }

            if (head.Next == null)
            {
                // Only one node in the list
                LType data = head.Data;
                head = null;
                num_elements--;
                return data;
            }
            else
            {
                Node<LType> current = head;
                Node<LType>? prev = null;
                while (current.Next != null)
                {
                    prev = current;
                    current = current.Next;
                }
                Node<LType>? nodeRemovedTail = current;
                current = null;
                prev!.Next = null;
                num_elements--;
                return nodeRemovedTail.Data;
            }
        }
        public void printList()
        {
            Node<LType>? node = head;
            while (node != null)
            {
                Console.Write(" " + node.Data + " ");
                node = node.Next;
            }
            Console.Write("null");
            Console.WriteLine();
        }

    }
}
