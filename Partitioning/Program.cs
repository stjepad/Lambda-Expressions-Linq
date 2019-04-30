using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partitioning
{
    class Program
    {
        static void Main()
        {
            // Partitioning Operations - Taking specific parts of a collection
            int[] ints = new int[] { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 5, 6, 7, 8, 8, 4, 3 };

            //skip method
            // whatever number you enter it will skip the first of that many in the array from the beginning
            int[] ints2 = ints.Skip(10).ToArray();

            // Take method
            // takes a given amount of elements and shows only those
            int[] ints3 = ints.Take(5).ToArray();

            //Skip while
            // it will all numbers that are matching this filter
            int[] intsSkipWhile = ints.SkipWhile(i => i < 5).ToArray();

            //take while
            // take all elements until we meet what was set in the filter
            int[] intsTakeWhile = ints.TakeWhile(i => i < 8).ToArray();

         }
    }
}
