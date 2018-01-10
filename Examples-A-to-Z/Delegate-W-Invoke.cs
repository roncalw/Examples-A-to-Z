using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Delegate_W_Invoke
    {
        public delegate void SomeMethodPointer();

        public static void launchExample()
        {
            SomeMethodPointer obj1;
            obj1 = SomeMethod;

            //or do not need to declare the delegate above Action is a delegate that returns void and accepts no parameters
            Action obj2;
            obj2 = SomeMethod;

            //or

            SomeMethodPointer obj3 = new SomeMethodPointer(SomeMethod);
            
            obj1.Invoke();
            obj2.Invoke();
            obj3.Invoke();

        }
        public static void SomeMethod()
        {
            Console.WriteLine("Some Method");
        }
    }
}
