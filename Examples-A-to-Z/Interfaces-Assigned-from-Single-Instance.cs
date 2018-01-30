using System;

namespace Examples_A_to_Z
{
    class Interfaces
    {
        /*
        Interfaces make programs more compact and easier to maintain. This extra complexity leads to greater simplicity.
        
        This program defines an interface named IPerl, which requires a Read method. 
        
        This program also defines a class named Test which implements IPerl—therefore, it must implement the Read method.       
         
        */

        /*
        In the Main method, we create a Test instance and store it in an IPerl reference. We invoke the Read method from the interface.
        When a class implements an interface, it can be used through a reference to that interface.
        */
        public static void launchExample()
        {
            IPerl perl = new Test(); // Create an instance of Test that the Interface Iperl will now have a reference to.

            perl.Read(); // Call method on interface.
        }
    }

    interface IPerl
    {
        void Read();
    }

    class Test : IPerl
    {
        public void Read()
        {
            Console.WriteLine("Read");
        }
    }
}
