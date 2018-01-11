using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Func_W_Method_Anonym_Lambda
    {
        /*Func is a generic delegate included in the System namespace. It has zero or more input parameters and one out parameter. 
        The last parameter is considered as an out parameter.
        A Func delegate type can include 0 to 16 input parameters of different types. However, it must include one out parameter for result.*/

                                                                        /*Named Method*/
        public static void launchExample()
        {
            Func<int, int, int> add = Sum1;

            int result = add(10, 15);

            Console.WriteLine(result);

                                                                        /*Anonymous Method*/


            Func<int> getRandomNumber1 = delegate ()
            {
                Random rnd = new Random();
                return rnd.Next(1, 100);
            };

            Console.WriteLine(getRandomNumber1());

                                                                        /*Lambda*/

            Func<int> getRandomNumber2 = () => new Random().Next(1, 1000);

            Console.WriteLine(getRandomNumber2());


            Func<int, int, int> Sum2 = (x, y) => x + y;

            Console.WriteLine(Sum2(10, 20));


        }
        public static int Sum1(int x, int y)
        {
            return x + y;
        }

    }
}
