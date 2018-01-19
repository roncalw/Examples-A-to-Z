﻿using System;
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
            
            An event is nothing but an encapsulated delegate. As shown in the delegate examples, a delegate is a reference type data type and they are declared and created as follows:

                1st the delegate type is created
                2nd the delegate is created with that type

                public delegate void someEvent();
                public someEvent someEvent;

            The only change to creating the delegate as an event is by adding the event keyword as follows:

                public delegate void someEvent();
                public event someEvent someEvent;
            
            Thus, a delegate becomes an event simply using the event keyword.

         */
        public static void launchExample()
        {
            Number myNumber = new Number(100000);
            myNumber.PrintMoney();
            myNumber.PrintNumber();
        }
    }

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
            //call delegate method before going to print
            if (beforePrintEvent != null)
                beforePrintEvent(); //This will call the method that is the event handler in the class that subscribes to this class.

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
        //Create an instance of the publisher class above so that can subscribe in the constructor.
        private PrintHelper _printHelper = new PrintHelper();

        public Number(int val)
        {
            _value = val;

            //_printHelper = new PrintHelper(); (commented out and moved to declaration above vs declaring this above: "private PrintHelper _printHelper;" and then this line.

            //subscribe and create a handler
            //subscribe to the publisher's beforePrintEvent event (event delegate) (very similar to passing a method to a delegate)
            //this says that the local method, printHelper_beforePrintEvent, will be the event handler for when the publisher's beforePrintEvent is called. 
            _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
        }

        //beforePrintevent handler
        void printHelper_beforePrintEvent()
        {
            Console.WriteLine("BeforPrintEventHandler: PrintHelper is going to print a value");
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

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
