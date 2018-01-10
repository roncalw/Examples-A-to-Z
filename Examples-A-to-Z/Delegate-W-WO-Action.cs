/*
To do without Action<T> Delegate: 
	- Uncomment the delegate declaration and messageTarget variable declaration of that delegate type and then 
	- Comment out the messageTarget variable declaration of Action<T> Delegate type.
Benefit of Action<T> Deleagate
	- Do not have to declare the delegate
	- The parmaeter name that is used in the delegate declatarion can be anything as it is never used, just the type is used. 
		Eg. In the following we only care about string, value can be anyword or letter. delegate void DisplayMessage(string value)
	- Using Action<T> is like saying that that the variable to the right in a declaration will be a delegate to point to other methods with the same single parameter type.
Cons of Action<T>
	- Can only have one single parameter
	- Cannot have a return type.
*/
using System;

//delegate void DisplayMessage(string message);

namespace Examples_A_to_Z
{
    class Delegate_W_WO_Action
    {
        public static void launchExample()
        {
            string myString = "Test Message";

            //DisplayMessage messageTarget; 

            Action<string> messageTarget;

            if (myString.Length < 5)
                messageTarget = Message_1;
            else
                messageTarget = Message_2;

            messageTarget(myString);
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
