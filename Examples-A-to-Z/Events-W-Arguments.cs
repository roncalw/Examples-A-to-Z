using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Events_W_Arguments
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
            
            An event is nothing but an encapsulated delegate. As shown in the delegate examples, a delegate is a reference type data type and they are declared and created as follows:

                1st the delegate type is created                ==>     public delegate void SomeEvent();
                2nd the delegate is created with that type      ==>     public SomeEvent someEvent;

            The only change to creating the delegate as an event is by adding the event keyword as follows:

                                                                        public delegate void SomeEvent();
                                                                        public event SomeEvent someEvent;
            
            Thus, a delegate becomes an event simply using the event keyword.

         */
        public static void launchExample()
        {
            Number1 myNumber1 = new Number1(100000);
            myNumber1.PrintMoney1();
            myNumber1.PrintNumber1();
            myNumber1.PrintTemperature1();
        }
    }

    //The PrintHelper is the publisher and will do the notifying to any class that subscribes to it (Instantiates this class)
    //In this particular program, the notifying will happen when the subscriber calls one of the print methods in this class
    //Especially helpful for subscribers if the publisher was to notify when their method ended since it could take who knows how long.
    public class PrintHelper1
    {
        // declare delegate 
        public delegate void BeforePrint(string message);

        //declare event of type delegate
        public event BeforePrint beforePrintEvent;

        public PrintHelper1()
        {

        }

        public void PrintNumber1(int num)
        {
            //1st check if there really are any subscribers where they have assigned a method (handler) to this delegate method before going to print
            if (beforePrintEvent != null)

            //If there was a subscription, this will call the method in the class that subsribed to it (the event handler)
            //It will send the string parameter "PrintNumber" because it has to since the contract dictated by the signature of this delegate is that all
            //those that susbscribe, must have a string parameter.
            beforePrintEvent("PrintNumber");

            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public void PrintDecimal1(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("PrintDecimal");

            Console.WriteLine("Decimal: {0:G}", dec);
        }

        public void PrintMoney1(int money)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("PrintMoney");

            Console.WriteLine("Money: {0:C}", money);
        }

        public void PrintTemperature1(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("PrintTemerature");

            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }
        public void PrintHexadecimal1(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("PrintHexadecimal");

            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }
    class Number1
    {
        //Create an instance of the publisher class above so that can subscribe in the constructor below.
        private PrintHelper1 _printHelper1 = new PrintHelper1();

        public Number1(int val)
        {
            _value = val;

            //_printHelper = new PrintHelper(); (commented out and moved to declaration above vs declaring this above: "private PrintHelper _printHelper;" and then this line.

            //subscribe and create a handler
            //subscribe to the publisher's beforePrintEvent event (event delegate) (very similar to passing a method to a delegate)
            //this says that the local method, printHelper_beforePrintEvent, will be the event handler for when the publisher's beforePrintEvent is called. 
            _printHelper1.beforePrintEvent += printHelper1_beforePrintEvent;
        }

        //This is the Event Handler - What to do when the Publisher calls the beforePrintEvent - it is the beforePrintEvent handler
        void printHelper1_beforePrintEvent(string message)
        {
            Console.WriteLine("BeforePrintEvent fires from {0}", message);
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        //Call the publishers PrintMoney method which will run the beforePrintEvent
        public void PrintMoney1()
        {
            _printHelper1.PrintMoney1(_value);
        }

        public void PrintNumber1()
        {
            _printHelper1.PrintNumber1(_value);
        }

        public void PrintTemperature1()
        {
            _printHelper1.PrintTemperature1(_value);
        }
    }

}
