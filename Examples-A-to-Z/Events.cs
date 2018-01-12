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
            
            An event is nothing but an encapsulated delegate. As shown in the delegate examples, a delegate is a reference type data type and they are declared and created as follows:

                1st the type is created
                2nd the delegate is created with that type

                public delegate void someEvent();
                public someEvent someEvent;

            The only change to creating the delegate as an event is by adding the event keyword as follows:

                public delegate void someEvent();
                public event someEvent someEvent;
            
            Thus, a delegate becomes an event simply using the event keyword.



         */
    }
}
