using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Delegate_As_Callback
    {
        public static void launchExample()
        {
            MyClass obj = new MyClass();

            obj.LongRunningTask(Callback);
        }

        static void Callback(int i)
        {
            Console.WriteLine(i);
        }
    }

    public class MyClass
    {
        public void LongRunningTask(Action<int> obj)
        {
            for (int i = 0; i < 10000;  i++)
            {
                //Call the method that was passed to this method (callback); when debugging would leave here to go to above method for each loop, 10,000 times
                obj(i);
            }
        }
        //           OR
        /*
        public delegate void Callback(int i);
        public void LongRunningTask(Callback obj)
        {
            for (int i = 0; i < 10000; i++)
            {
                //Do something
                obj(i);
            }
        }
        */
    }
}
