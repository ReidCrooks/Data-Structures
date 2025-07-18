using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                for (int i = 0; i < pos; i++)
                {
                    current = current.Next;
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
                    num_elements++;
                }
            }
        }

        public LType RemoveAt(int pos)
        {
            return default;
        }

        public LType Get(int pos)
        {
            return default;
        }

        public LType Set(int pos)
        {
            return default;
        }

        public int Size()
        {
            return default;
        }

        public void AddHead(LType item)
        {
            if (num_elements == 0)
            {
                Node<LType> newNode = new Node<LType>(item, null);
                head = newNode;
            }
            else
            {
                Node<LType> newNode = new Node<LType>(item, head);
            }
            num_elements++;

        }

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
                current.Next = new Node<LType>(item, null);
            }
        }

        public void printList()
        {
            Node<LType> node = head;
            while (node != null)
            {
                Console.Write(" " + node.Data + " ");
                node = node.Next;
            }
            Console.Write("null");
            Console.WriteLine();
        }

    }
    class Project
    {
        static void Main(string[] args)
        {
            LinkedListAPI<int> list = new LinkedListAPI<int>();
            list.AddAt(1, 0);
            list.printList();
            list.AddAt(2, 1);
            list.printList();
            list.AddAt(3, 2);
            list.printList();
            list.AddTail(4);
            list.printList();
            list.AddAt(5, 1);
            list.printList();

    }
   }
}