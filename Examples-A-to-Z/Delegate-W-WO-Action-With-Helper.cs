/*
To do without Action<T> Delegate: 
	- Uncomment the DisplayMessage delegate declaration
	- Replace the 1st parameter in MessageHelper, Action<string> delegateFunc, with DisplayMessage delegateFunc
Benefit of Action<T> Delegate
	- Do not have to declare the delegate
	- The parmaeter name that is used in the delegate declatarion can be anything as it is never used, just the type is used. 
		Eg. In the following we only care about string, value can be anyword or letter. delegate void DisplayMessage(string value)
	- Using Action<T> is like saying that that the variable to the right in a declaration will be a delegate to point to other methods with the same single parameter type.
Cons of Action<T>
	- Can only have one single parameter
	- Cannot have a return type.
*/
using System;

namespace Examples_A_to_Z
{
    class Delegate_W_WO_Action_With_Helper
    {
        public static void launchExample()
        {
            string myString = "Test Message";

            if (myString.Length < 5)
                MessageHelper(Message_1, myString);
            else
                MessageHelper(Message_2, myString);
        }

        //Replace the 1st parameter, Action<string> delegateFunc, with DisplayMessage delegateFunc if do not want to use Action and DisplayMessage delegate was declared above 
        public static void MessageHelper(Action<string> delegateFunc, string localMessage)
        {
            delegateFunc(localMessage);
        }

        private static void Message_1(string message)
        {
            Console.WriteLine("This message is used when there are just a few characters: " + message);
        }

        private static void Message_2(string message)
        {
            Console.WriteLine("This message is used when there are more than just a few characters: " + message);
        }
    }
}
