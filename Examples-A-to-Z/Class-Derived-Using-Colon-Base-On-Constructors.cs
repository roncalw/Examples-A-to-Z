using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Base_Used_On_Derived_Class_Constructors
    {
        //The base keyword requires that the derived constructor below call the base constructor 1st (debug to see it)

        public static void launchExample()
        {
            // Create a new instance of class A, which is the base class.
            // ... Then create an instance of B.
            // ... B executes the base constructor.
            A a = new A(0);
            B b = new B(1);
        }
    }
    public class A // This is the base class.
    {
        public A(int value)
        {
            // Executes some code in the constructor.
            Console.WriteLine("Base constructor A(): Value={0}", value);
        }
    }

    public class B : A // This class derives from the previous class.
    {
        //The base keyword requires this derived constructor to call the base constructor 1st
        public B(int value) : base(value)
        {
            // The base constructor is called first.
            // ... Then this code is executed.
            Console.WriteLine("Derived constructor B(): Value={0}", value);
        }
    }
}
