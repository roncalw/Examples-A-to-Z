using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Predicate_W_Method_Annym_Lambda
    {
        /*A predicate is also a delegate like Func and Action delegates. It represents a method that contains 
         a set of criteria and checks whether the passed parameter meets those criteria or not. 
         A predicate delegate methods must take one input parameter and it then returns a boolean value - true or false.
         
         Predicate delegate takes one input parameter and returns a boolean.
         Predicate delegate must contains some criateria to check whether supplied parameter meets those criateria or not.    
         */
        public static void launchExample()
        {
                                                                   /*Named Method*/
            Predicate<string> isUpper1 = IsUpperCase;

            //isUpper1 is now a predicate delegate pointing to the IsUpperCase method below and will check whether or not this passed parameter meets the criteria in the method.
            bool result1 = isUpper1("hello world!!");

            Console.WriteLine(result1);

                                                                    /*Anonymous Method*/
            Predicate<string> isUpper2 = delegate (string s) { return s.Equals(s.ToUpper()); };

            //isUpper2 is now a predicate delegate pointing to the anonymous method assigned to it and will check whether or not this passed parameter meets the criteria in the method.
            bool result2 = isUpper2("HELLO!!");

            Console.WriteLine(result2);

                                                                    /*Lambda Expression*/
            Predicate<string> isUpper3 = s => s.Equals(s.ToUpper());

            //isUpper2 is now a predicate delegate pointing to the anonymous method assigned to it and will check whether or not this passed parameter meets the criteria in the method.
            bool result3 = isUpper3("hello world!!");

            Console.WriteLine(result3);

        }

        public static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }
    }
}
