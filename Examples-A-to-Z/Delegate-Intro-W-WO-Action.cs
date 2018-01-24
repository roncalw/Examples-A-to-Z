/*
To do without Action<T> Delegate: 
	- Uncomment the delegate declaration and messageTarget variable declaration of that delegate type and then 
	- Comment out the messageTarget variable declaration of Action<T> Delegate type.
Benefit of Action<T> Delegate
	- Do not have to declare the delegate
	- The parmaeter name that is used in the delegate declatarion can be anything as it is never used, just the type is used. 
		Eg. In the following we only care about string, value can be anyword or letter. delegate void DisplayMessage(string value)
	- Using Action<T> is like saying that that the variable to the right in a declaration will be a delegate to point to other methods with the same single parameter type.
Cons of Action<T>
	- Cannot have a return type.
*/
using System;
/*A delegate will run functions that are assigned to it, if there are numerous functions assigned to a delegate 
when the delegate runs itself it will call all those other functions actually stepping into their process.*/

//To create a delegate, do it in two ways: formally or via a shortcut
//Formally uses two steps where the shorcut uses just one
/*
With formal declaration 
 
 * 1) Create the type of the delegate, the complete signature, what it returns along with what the parameter types should be and give the type a type name
        Eg. delegate void DisplayMessage(string message); 
            - The name "DisplayMessage" is now the name of the type of delegate when declaring a variable of this type in the next step
            - The actual paramaeter variable name means nothing and is not ever used

 * 2) Decclare the variable of this delegate type. 
        Eg. DisplayMessage messageTarget; 
            - messageTarget is now a delegate that can invoke any method with the exact same signature.

With shortcut declaration
 * 1) Declare the variable of the .NET built-in delegate type
        Eg. Action<string> messageTarget;
            - There is no need for a prior step
            - Action means that that there can only be one parameter and that the return type is void
            - can use Func instead if need to return something or pass in more than one parameter.
            - With Func and Action, there is no need to come up with the name of the delegate type nor use variable names that are never used

 To use the delegate type simply run it by:
    * making sure it is run exactly like the signature. 
    * making sure it has been assigned a method to run (note, the process will actually move to where the method is actually located)
        - Assigning the method to the delegate is called subscribing to this delegate (who is the publisher) 
        - Once the "subscribe" is complete (the method was assigned) the method will not be called until the delegate runs (this is called a callback)
        - When the delegate runs it will run all of the methods that have subscribed to it (note, the process will actually move to where the method is actually located)
        - The subscription could have been done from another class even, to see that look at the Delegate-As-Callback example.
  
*/

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
