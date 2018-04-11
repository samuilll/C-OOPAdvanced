using System;
using System.Collections.Generic;
using System.Text;

namespace _04BubbleSort
{
  public  class Sorter
    {
        public void BubbleSort(int[] numbers)
        {

            bool swapped = true;

            while (swapped)
            {
                swapped = false;

                for (int i = 0; i < numbers.Length-1; i++)
                {
                    if (numbers[i]>numbers[i+1])
                    {
                        var temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swapped = true;
                    }
                }

            }
        }
    }
}
