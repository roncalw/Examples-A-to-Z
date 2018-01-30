using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Interfaces_Assigned_to_Multiple_Instances_For_Properties
    {
        public static void launchExample()
        {
            IValue1 value1 = new Image1();
            IValue1 value2 = new Article1();

            value1.Count++; // Access int property on interface.
            value2.Count++; // Increment.

            value1.Name = "Mona Lisa"; // Use setter on interface.
            value2.Name = "Resignation"; // Set.

            Console.WriteLine(value1.Name); // Use getter on interface.
            Console.WriteLine(value2.Name); // Get.
        }
    }
    interface IValue1
    {
        int Count { get; set; } // Property interface.
        string Name { get; set; } // Property interface.
    }

    class Image1 : IValue1 // Implements interface.
    {
        public int Count // Property implementation.
        {
            get;
            set;
        }

        string _name;

        public string Name // Property implementation.
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }

    class Article1 : IValue1 // Implements interface.
    {
        public int Count // Property implementation.
        {
            get;
            set;
        }

        string _name;

        public string Name // Property implementation.
        {
            get { return this._name; }
            set { this._name = value.ToUpper(); }
        }
    }

}
