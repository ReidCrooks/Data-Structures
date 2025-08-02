﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class DynamicArrayAPI<AType>
    {
        private AType[] dynamicArray;
        private int current_size;
        private int num_elements;
        public DynamicArrayAPI()
        {
            dynamicArray = new AType[0];
            current_size = 0;
            num_elements = 0;
        }
        public void Add(AType item, int pos)
        {

            if (pos < 0)
            {
                Console.WriteLine("position cannot be negative");
                return;
            }
            try
            {
                if (current_size == num_elements)
                {
                    SizeUp();
                }
                if (pos < num_elements && dynamicArray[pos] != null)
                {
                    ShiftUp(pos);
                }
                dynamicArray[pos] = item;
                num_elements++;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public AType Remove(int pos)
        {
            if (pos < 0)
            {
                Console.WriteLine("position cannot be negative");
                return default;
            }

            try
            {
                AType item = dynamicArray[pos];
                dynamicArray[pos] = default;
                ShiftDown(pos);
                num_elements--;
                return item;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return default;
            }
        }

        public AType Get(int pos)
        {
            if (pos < 0)
            {
                Console.WriteLine("position cannot be negative");
                return default;
            }
            try
            {
                return dynamicArray[pos];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return default;
            }
        }

        public AType Set(AType val, int pos)
        {
            if (pos < 0)
            {
                Console.WriteLine("position cannot be negative");
                return default;
            }
            try
            {
                AType old = dynamicArray[pos];
                dynamicArray[pos] = val;
                return old;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return default;
            }
        }

        public int Size()
        {
            return num_elements;
        }

        public void SizeUp()
        {
            int newSize;
            if (current_size == 0)
            {
                newSize = 1;
            }
            else
            {
                newSize = current_size * 2;
            }
            AType[] newArray = new AType[newSize];

            for (int i = 0; i < num_elements; i++)
            {
                newArray[i] = dynamicArray[i];
            }
            current_size = newSize;
            dynamicArray = newArray;
        }

        public void ShiftUp(int pos)
        {
            for (int i = num_elements - 1; i >= pos; i--)
            {
                dynamicArray[i + 1] = dynamicArray[i];
            }
        }

        public void ShiftDown(int pos)
        {
            for (int i = pos; i < num_elements; i++)
            {
                dynamicArray[i] = dynamicArray[i + 1];
            }
        }

        public void AddEnd(AType item)
        {
            if (current_size == num_elements)
            {
                SizeUp();
            }
            dynamicArray[num_elements] = item;
            num_elements++;
        }

        public void AddBeginning(AType item)
        {
            Add(item, 0);
        }

        public void printArray()
        {
            Console.Write("[");
            foreach (AType item in dynamicArray)
            {
                Console.Write(item + ", ");
            }
            Console.Write("]");
        }

    }
}
