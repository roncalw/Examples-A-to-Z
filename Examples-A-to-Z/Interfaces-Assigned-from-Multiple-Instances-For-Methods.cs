using System;
using System.Collections.Generic;

namespace Examples_A_to_Z
{
    class Interfaces_Assigned_to_Multiple_Instances
    {
        public static void launchExample()
        {
            /*
            This program defines an interface and two classes that implement it. They both can't be assigned to it in one assignment, but through each holder in the Dictionary object, the 
            Dictionary object can hold different class instances all implementing the IValue interface.
            
            In Main, here, we create a Dictionary. 
            
            We fill it with values based on the IValue interface. 
            
            This shortens the code because even though the dictionary will have two type of objects it is as if there is only one object for the type, iValue.
            */

            // Add three objects that implement the interface.
            var dictionary = new Dictionary<string, IValue>();
            dictionary.Add("cat1.png", new Image());
            dictionary.Add("image1.png", new Image());
            dictionary.Add("home.html", new Content());

            // Look up interface objects and call implementations. Pass this variable in to the TryGetValue method where it will be assigned when the method is complete 
            //(notice the out parameter which will act on the actual variable that was passed in. Similar to ref but do not have to initialize it 1st.
            IValue value;

            /*
                TryGetValue assigns what the value is at the Key "cat1.png" which is the IValue reference to the image object instance. So value becomes the IValue reference to the image object.
                No if-statements or switch-statements are required to select the best method implementation since we are using the Interface to implement the function.
            */
            if (dictionary.TryGetValue("cat1.png", out value)) 
            {
                value.Render(); // Image.Render
            }
            if (dictionary.TryGetValue("home.html", out value))
            {
                value.Render(); // Content.Render
            }
        }
    }
    interface IValue
    {
        void Render();
    }

    class Content : IValue
    {
        public void Render()
        {
            Console.WriteLine("Render content");
        }
    }

    class Image : IValue
    {
        public void Render()
        {
            Console.WriteLine("Render image");
        }
    }
}
