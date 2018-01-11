using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Action_W_Method_Anonym_Lambda
    {
        /*An Action type delegate is the same as Func delegate except that the Action delegate doesn't return a value. 
         In other words, an Action delegate can be used with a method that has a void return type.
         
         Action delegate is same as func delegate except that it does not return anything. Return type must be void.
         Action delegate can have 1 to 16 input parameters.
         Action delegate can be used with anonymous methods or lambda expressions    
         */
        public static void launchExample()
        {
                                                                            /*Named Method*/
            Action<int> printActionDel1 = ConsolePrint;

            printActionDel1(10);

            //Or

            Action<int> printActionDel2 = new Action<int>(ConsolePrint);

            printActionDel2(66);

                                                                            /*Anonymous Method*/
            Action<int,int> printActionDel3 = delegate (int i, int j)
            {
                Console.WriteLine("From Anonymous method. Val1: {0} and Val2: {1}", i);
            };

            printActionDel3(99,42);

                                                                            /*Lambda Expression*/
            Action<int> printActionDel = i => Console.WriteLine("From Lambda Expression. Val: {0}", i);

            printActionDel(416);

        }

        public static void ConsolePrint(int i)
        {
            Console.WriteLine(i);
        }
    }
}
