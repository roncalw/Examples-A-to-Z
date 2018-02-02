using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class EventArgsExample
    {
        public static void launchExample()
        {
            Counter c = new Counter(new Random().Next(10));

            //The c.ThresholdReached is a delegate, so we are assigning the local method here, c_ThresholdReached, to be called from here, when the publisher runs the delegate.
            c.ThresholdReached += c_ThresholdReached;

            //The publisher, Counter, will call this method that is assigned here once the event happens by adding 1 starting at 0 up to a random number up to 10
            //The publisher used a shortcut method of creating the delegate (see the comment there below)
            //Also, the publisher copied the delegate for thread safety sakes so it is the copy of the delegate that runs not the original delegate.

            Console.WriteLine(c.threshold); //assigned via the publisher's constructor initiated from above: Counter c = new Counter(new Random().Next(10))
            Console.WriteLine("press 'a' key to increase total");

            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

    class Counter
    {
        public int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;

                OnThresholdReached(args);
            }
        }

        //Call the delegate ThresholdReached (created below) when called above in the Add function (which calls this when the private field total gets to be 
        //greater than the int value that was passed into this class in the consructor.
        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            /*Thread Safety - Copy the event delegate (creating a multicast Delegate) to a temporary local variable before raising it to avoid the following issue:
                Assume we have thread A which is about to raise the event, and it checks and clears the null check and is about to raise the event.  
                However, before it can do that thread B unsubscribes to the event, which sets the delegate to null.  Now, when thread A attempts to raise the event, 
                this causes the NullReferenceException that we were hoping to avoid!
            */
                    //Syntax to use when fomrally declaring the event delegate below
                    //ThresholdReachedEventHandler handler = ThresholdReached;

                    //Syntax to use when not formally declaring the event delegate type but using the shortcut instead

                    EventHandler <ThresholdReachedEventArgs> handler = ThresholdReached;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        //Do not need to declare the delegate type since this is shortcut: (see the commented line just below this if not using this shortcut) 
        //This shortcut says that the signature returns void and that sender object (publisher) is passed to subscriber's event handler and that the 
        //EventArgs or a custom implemenation of it as here, is passed in as the EventArgs. T is used just for the EventArgs.

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached; //looks like this: ThresholdReached(object sender, ThresholdReachedEventArgs whatever)


        //If not using the shortcut method must use the following line instead
        //Declare the delegate type
        //public delegate void ThresholdReached(object sender, ThresholdReachedEventArgs whatever); 
        //Declare the delegate
        //public event ThresholdReached thresholdReached;


    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

}
