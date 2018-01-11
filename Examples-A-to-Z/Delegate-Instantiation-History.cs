using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Delegate_Instantiation_History
    {
        delegate void TestDelegate(string s);
        static void M(string s)
        {
            Console.WriteLine(s);
        }

        public static void launchExample()
        {
            // Original delegate syntax required initialization with a named method.
            TestDelegate testDelA = new TestDelegate(M);

            // C# 2.0: A delegate can be initialized with inline code, called an "anonymous method." 
            //This way takes a string as an input parameter.
            TestDelegate testDelB = delegate (string s) { Console.WriteLine(s); };

            // C# 3.0. A delegate can be initialized with a lambda expression. 
            //The lambda also takes a string as an input parameter (x). 
            //The type of x is inferred by the compiler. (The compiler can see that it takes a string
            //because that is how the delegate was declared.
            TestDelegate testDelC = (x) => { Console.WriteLine(x); };

            // Invoke the delegates.
            testDelA("Hello. My name is M and I write lines.");
            testDelB("That's nothing. I'm anonymous and ");
            testDelC("I'm a famous author.");

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }
}
