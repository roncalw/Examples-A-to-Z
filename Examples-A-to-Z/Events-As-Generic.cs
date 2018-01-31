using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Events_As_Generic
    {
        /*
        Generic delegates are especially useful in defining events based on the typical design pattern because the sender argument can be strongly typed 
        and no longer has to be cast to and from Object.
        */
        public static void launchExample()
        {
            Stack<double> s = new Stack<double>();

            SampleClass o = new SampleClass();

            s.stackEvent += o.HandleStackChange;
        }
    }

    class Stack<T>
    {
        public class StackEventArgs : System.EventArgs { }


        public delegate void StackEventHandler<T, U>(T sender, U eventArgs);

        public event StackEventHandler<Stack<T>, StackEventArgs> stackEvent;

        protected virtual void OnStackChanged(StackEventArgs a)
        {
            stackEvent(this, a); //This is just an example, in the real world a copy of stackEvent should be called not this original (see EventArg..Thread-Safety example file)
        }
    }

    class SampleClass
    {
        public void HandleStackChange<T>(Stack<T> stack, Stack<T>.StackEventArgs args) { }
    }
}
