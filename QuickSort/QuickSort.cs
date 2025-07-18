using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
class QuickSort
{
    static void Sort(ref int[] list)
    {
        QuickSortHelper(list, 0, list.Length - 1);
    }
    static void QuickSortHelper(int[] list, int start, int end)
    {
        //Return if array is empty or 1 value
        if (end <= start)
        {
            return;
        }

        int pivot = list[end];
        int j = start;
        int i = j - 1;
        int temp = 0;
        //Puts values less than pivot to left side
        while (j < end)
        {
            if (list[j] < pivot)
            {
                i++;
                temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
            j++;
        }
        i++;
        temp = list[i];
        list[i] = list[j];
        list[j] = temp;
        pivot = list[i];

        //Recursively sorts left and right side of array
        QuickSortHelper(list, start, i - 1);
        QuickSortHelper(list, i + 1, end);

    }
}