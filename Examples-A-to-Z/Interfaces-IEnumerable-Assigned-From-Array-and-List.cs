using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Interfaces_IEnumerable_Assigned_From_Array_and_List
    {
        public static void launchExample()
        {
            int[] values = { 1, 2, 3 };
            List<int> values2 = new List<int>() { 1, 2, 3 };

            // Pass to a method that receives IEnumerable.
            Display(values);
            Display(values2);
        }
        

        /*
        Because both the array object and the list object inherit from the IEnumerable interface we can make an instance of the IEnumerable reference the array and List<int> above.
        This way we can use just the one method here vs having to use two different methods passing int[] to one method and List<int> to the other
        */
        static void Display(IEnumerable<int> values)
        {
            foreach (int value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
}
