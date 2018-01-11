using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Lambda_Expression_No_Parameters
    {
        delegate void Print();

        public static void launchExample()
        {
            Print print = () => Console.WriteLine("This is parameter less lambda expression");

            print();

        }
    }
}
