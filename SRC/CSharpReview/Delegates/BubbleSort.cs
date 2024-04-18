using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Delegates
{
    public class BubbleSort<T>
    {
        // public delegate bool Comapre(T a, T b);

        // public T[] Sort(T[]items, Comapre comapre)
        public T[] Sort(T[] items, Func<T,T,bool> comapre)
        {
            bool flag = true;
            T temp;
            int itemsLength = items.Length;

           // Bubble Sort Algorithm

            for (int i = 1; (i <= (itemsLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (itemsLength - 1); j++)
                {
                    if (comapre(items[j + 1],items[j]))
                    {
                        temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        flag = true;
                    }
                }
            }
            return items;
        }
    }
}
