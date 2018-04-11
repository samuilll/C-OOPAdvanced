using _04BubbleSort;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tester
{
    public class BubbleSortTests
    {
        [Test]
        public void NumbersArrangeProperly()
        {
            Sorter sorter = new Sorter();

            int[] numbersToSort = new int[] { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            sorter.BubbleSort(numbersToSort);

            CollectionAssert.AreEqual(expected, numbersToSort);
        }
    }
}
