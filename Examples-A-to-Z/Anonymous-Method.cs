using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Anonymous_Method
    {
        /*An anonymous method is a method without a name. 
        Creating anonymous methods is essentially a way to pass a code block as a delegate parameter vs having to create a method.
        Anonymous methods in C# can be defined using the delegate keyword and can be assigned to a variable of delegate type.
        */

        public delegate void Print(int value);

        public static void launchExample()
        {   
            //Just showing that 
            int i = 10;

            // Instantiate the delegate type using an anonymous method.
            Print print = delegate (int val) 
            {
                val += i;

                Console.WriteLine("Inside Anonymous method. Value: {0}", val);
            };

            print(100);

            //Versus using a named method to do the same thing.

            //Use either or for assigning a named method
            //print = new Print(Anonymous_Method.DoWork); 
            print = Anonymous_Method.DoWork;

            print(50);
        }

        // The method associated with the named delegate.
        static void DoWork(int j)
        {
            Console.WriteLine("Showing from a manually ceate named method. Value: {0}", j);
        }
    }
}
