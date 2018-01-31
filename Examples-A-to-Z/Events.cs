using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Events
    {
        /*
            Events in C# follow real like examples of events ... For example, Microsoft launches events for developers, to make them aware about the features of new or existing products. 
            Microsoft notifies the developers about the event by email or other advertisement options. So in this case, 
                Microsoft is a publisher who launches (raises) an event and 
                notifies the developers about it and 
                developers are the subscribers of the event and 
                attend (handle) the event.

            Events in C# follow a similar concept. An event has a 
                publisher, 
                notification,
                subscriber and a 
                handler. 
            Generally, UI controls use events extensively. For example, the button control in a Windows form has multiple events such as click, mouseover, etc. 
            A custom class can also have an event to notify other subscriber classes about something that has happened or is going to happen. 
            
            An event is nothing but an encapsulated delegate. As shown in the delegate examples (in the delegate files of this project), a delegate is a reference type data type 
            and they are declared and created as follows:

                1st the delegate type is created                ==>     public delegate void SomeEvent();
                2nd the delegate is created with that type      ==>     public SomeEvent someEvent;

            The only change to creating the delegate as an event is by adding the event keyword as follows:

                                                                        public delegate void SomeEvent();
                                                                        public event SomeEvent someEvent;
            
            Thus, a delegate becomes an event simply using the event keyword.

         */
        public static void launchExample()
        {
            Number myNumber = new Number(100000);
            myNumber.PrintMoney();
            myNumber.PrintNumber();
        }
    }

    //The PrintHelper is the publisher and will do the notifying to any class that subscribes to it (Instantiates this class)
    //In this particular program, the notifying will happen when the subscriber calls one of the print methods in this class
    //Especially helpful for subscribers if the publisher was to notify when their method ended since it could take who knows how long.
    public class PrintHelper
    {
        // declare delegate 
        public delegate void BeforePrint();

        //declare event of type delegate
        public event BeforePrint beforePrintEvent;

        public PrintHelper()
        {

        }

        public void PrintNumber(int num)
        {
            //1st check if there really are any subscribers where they have assigned a method (handler) to this delegate method before going to print
            if (beforePrintEvent != null)

            //If there was a subscription, this will call the method in the class that subsribed to it (the event handler)
            beforePrintEvent(); 

            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public void PrintDecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Decimal: {0:G}", dec);
        }

        public void PrintMoney(int money)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Money: {0:C}", money);
        }

        public void PrintTemperature(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }
        public void PrintHexadecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }
    class Number
    {
        //Create an instance of the publisher class above so that can subscribe to it in the constructor below.
        private PrintHelper _printHelper = new PrintHelper();

        private int _value;

        public Number(int val)
        {
            _value = val;

            //_printHelper = new PrintHelper(); (commented out and moved to declaration above vs declaring this above: "private PrintHelper _printHelper;" and then this line.

            //subscribe and create a handler
            //subscribe to the publisher's beforePrintEvent event (event delegate) (very similar to passing a method to a delegate)
            //this says that the local method, printHelper_beforePrintEvent, will be the event handler for when the publisher's beforePrintEvent is called. 
            _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
        }

        //This is the Event Handler - What to do when the Publisher calls the beforePrintEvent - it is the beforePrintEvent handler
        void printHelper_beforePrintEvent()
        {
            Console.WriteLine("BeforPrintEventHandler: PrintHelper is going to print a value");
        }


        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        //Call the publishers PrintMoney method which will run the beforePrintEvent
        public void PrintMoney()
        {
            _printHelper.PrintMoney(_value);
        }

        public void PrintNumber()
        {
            _printHelper.PrintNumber(_value);
        }
    }

}
