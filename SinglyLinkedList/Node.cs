using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    public class Node<T> : IEquatable<object>
    {
        private T data;
        private Node<T>? next;
        public Node(T val, Node<T> nxt)
        {
            data = val;
            next = nxt;

        }

        public Node<T>? Next
        {
            get { return next; }
            set { next = value; }
        }
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType() || this.Data == null)
            {
                return false;
            }
            else
            {
                return Data.Equals(((Node<T>)obj).Data);
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
