using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Anonymous_Method_As_Parameter
    {
        public delegate void Print(int value);

        public static void PrintHelperMethod(Print printDel, int val)
        {
            val += 10;
            printDel(val);
        }

        /*Anonymous methods can be passed to a method that accepts the delegate as a parameter.
        In the following example, PrintHelperMethod() takes the first parameters of the Print delegate*/
        public static void launchExample()
        {
            PrintHelperMethod(delegate (int val) { Console.WriteLine("Anonymous method: {0}", val); }, 100);
        }
    }
}
