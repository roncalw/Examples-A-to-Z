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
            Stack<string> s = new Stack<string>();

            //The sample class will be used to subscribe to the publisher in the next line, where it assigns a method as the event handler for the even in the publisher)
            SampleClass o = new SampleClass();

            //subscribe to the publisher (s is the publisher, o.HandleStackChange is the event handler)
            s.stackEvent += o.HandleStackChange;

            s.DoWork();
        }
    }

    class SampleClass
    {
        //This will be the method that is called by the Stack class when the Stack class runs the method that calls the Event method that is in the Stack class
        //This method is called because we subscribed to the publisher above (assigned this method to the event above)
        //So it is the publisher calling this method passing in its instance information along with any arguments concerning the event.
        public void HandleStackChange<T>(Stack<T> stack, StackEventArgs args)
        {
            Console.WriteLine("I see you are done with your work, and that the last line you wrote was {0} and that you finished at {1}", args.LastLineNumReached, args.TimeComplete);
        }
    }

    public class Stack<T>
    {
        public delegate void StackEventHandler<T, U>(T sender, U eventArgs);
        public event StackEventHandler<Stack<T>, StackEventArgs> stackEvent;

        //This shortcut does not work, because the sender's type is "object" not Stack<T> as immediately above here in the longer version.
        //public EventHandler<StackEventArgs> stackEvent;

        public void DoWork()
        {
            int i = 0;
            
            while (i < 100)
                {
                    Console.WriteLine("Doing work for line: {0}",i);
                    i++;
                }

            StackEventArgs EventArgs = new StackEventArgs();

            EventArgs.LastLineNumReached = i;
            EventArgs.TimeComplete = DateTime.Now;

            OnStackChanged(EventArgs);
        }

        public void OnStackChanged(StackEventArgs a)
        {
            stackEvent(this, a); //This is just an example, in the real world a copy of stackEvent should be called not this original (see EventArg..Thread-Safety example file)
        }
    }

    public class StackEventArgs : System.EventArgs
    {
        public int LastLineNumReached {get; set;}

        public DateTime TimeComplete { get; set; }
    }
}
