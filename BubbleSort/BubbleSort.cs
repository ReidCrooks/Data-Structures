using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class BubbleSort
    {
        static void Sort(ref int[] list)
        {
            bool swapped;
            for (int j = 0; j < list.Length; j++)
            {
                swapped = false;
                for (int i = 0; i < list.Length - j - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        int placeHolder = list[i + 1];
                        list[i + 1] = list[i];
                        list[i] = placeHolder;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}