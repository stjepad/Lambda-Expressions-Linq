using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Concatenating Collections
            int[] ints = new int[] { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 5, 6, 7, 8, 8, 4, 3 };
            int[] ints2 = new int[] { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5 };
            int[] ints3 = new int[] { 1, 2, 2, 2, 2, 2, 2 };

            // concatenating collections
            int[] concatenated = ints2.Concat(ints3).ToArray();

        }
    }
}
