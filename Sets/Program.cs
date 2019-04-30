using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets
{
    class Program
    {
        static void Main()
        {
            string st1 = "I am a cat";
            string st2 = "I am a dog";
            List<int> ints = new List<int>() { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 6, 7, 8, 8, 4, 3 };
            List<int> ints2 = new List<int>() { 3, 2, 3, 5, 8, 43, 5, 67, 1, 2, 3, 7, 7, 7, 6, 5, 2, 1, 1, 1, 1, 1 };

            //-------------------------------------------------------------------------

            //distict method
            //shows you all the unique elements
            var distict = st1.Distinct();
            var distict2 = st2.Distinct();

            // Intersect method
            // shows unique elements that are shared between two collections
            var intersect = st1.Intersect(st2);

            // Union method
            // performing disticts on both collections , with one method
            var union = st1.Union(st2);

            // except
            // elements that are in one , but not other. basically not shared
            var except = st1.Except(st2);
        }
    }
}
