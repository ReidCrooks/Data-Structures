using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    public class Node<T> : IEquatable<object>
    {
        private T data;
        private Node<T>? lChild;
        private Node<T>? rChild;
        private Node<T> parent;
        public Node(T val, Node<T>? parent, Node<T>? lChild, Node<T>? rChild)
        {
            data = default;
        }

        public Node(T val, Node<T>? parent, Node<T>? lChild, Node<T>? rChild)
        {
            data = val;
            this.parent = parent;
            this.lChild = lChild;
            this.rChild = rChild;

        }

        /**
         * Shorthand to create a Getter and Setter method for Data
         */
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node<T>? Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public Node<T>? LChild
        {
            get { return lChild; }
            set { lChild = value; }
        }

        public Node<T>? RChild
        {
            get {return rChild; }
            set { rChild = value; }
        }
        /*
         * override of the .Equals method to properly allow comparisons between Nodes
         */
        public override bool Equals(object? obj)
        {
            //Check for null input, different objects, and null data
            if (obj == null || obj.GetType() != this.GetType() || this.data == null)
            {
                return false;
            }
            else
            {
                return data.Equals(((Node<T>)obj).Data);
            }
        }
        /*
         * We're not making our own hash code, so leave as is :)
         */
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}