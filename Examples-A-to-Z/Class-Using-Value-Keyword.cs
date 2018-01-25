using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Class_Using_Value_Keyword
    {
        /*In the classes below we can use the special keyword "value." This way we do not need to specify the type. 
        The type is determined by the enclosing property type.*/
        public static void launchExample()
        {
            Programmer program = new Programmer();

            // Use PropertyInt.
            program.PropertyInt = 5;                    //This will run the console.write that is in the setter for PropertyInt
            Console.WriteLine(program.PropertyInt);     //This will also run the console.write but from here outputting 1

            // Use PropertyString.
            program.PropertyString = "test";
            Console.WriteLine(program.PropertyString);
        }
    }

    public class Programmer
    {
        public int PropertyInt
        {
            get
            {
                return 1;
            }
            set
            {
                Console.WriteLine(value);
            }
        }

        public string _backing;

        public string PropertyString
        {
            get
            {
                return this._backing;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                this._backing = value;
            }
        }
    }
    }
