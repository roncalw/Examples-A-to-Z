using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class List_Arrays
    {
        public static void launchExample()
        {
            List<string> sList = new List<string>();

            sList.Add("Pat");
            sList.Add("Terry");
            sList.Add("Lou");

            //This sort method will only work on objects that implemented the IComparable interface; 
            //therefore because this works, this means that the String class implements this interface.
            //Which means that the List object is calling the Strings CompareTo function on the full list to sort

            /* Eg. CompareTo is a .NET built in function that returns an integer which works as follows on this s1.CompareTo(s2):
                    VALUE               CONDITION
                    Less than zero      This instance precedes value (strB).

                    Zero                This instance has the same position in the sort order as value.

                    Greater than zero   This instance follows value. -or-value is null.
            */
            sList.Sort();

            foreach (string lName in sList)
            {
                Console.WriteLine("My name is {0}", lName);
            }

            /*
             The sort method will not work therefore on objects that are custome built unless the object implements this interface.
             Eg. The sort method below will crash without the inheritance to the Interface on the Dog object that it is trying to sort.
             This makes the class promise that it will only compare Customer objects to other Customer objects by using the generic version of IComparable, 
             which specification on what kind of objects it will be comparing to.
             */

            List<Dog> dogs = new List<Dog>();

            dogs.Add(new Dog("Fritzie"));
            dogs.Add(new Dog("Allie"));
            dogs.Add(new Dog("Holllie"));
            dogs.Add(new Dog("George"));

            dogs.Sort();

            foreach (Dog ldog in dogs)
            {
                Console.WriteLine("My dog name is: {0} ",ldog);
            }

        }
        class Dog : IComparable<Dog>
        {
            private string name;

            public Dog(string name)
            {
                this.Name = name;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Describe()
            {
                return "Hello, I'm a dog and my name is " + this.Name;
            }

            public int CompareTo(Dog dog)
            {
                return this.Name.CompareTo(dog.Name);
            }
        }

        /*
	    
        or

		class Dog : IComparable
		{
			private string name;
	
			public Dog(string name)
			{
				this.Name = name;
			}
	
			public string Name
			{
				get { return name; }
				set { name = value; }
			}
	
			public string Describe()
			{
				return "Hello, I'm a dog and my name is " + this.Name;
			}
	
			public int CompareTo(object obj)
			{
				if(obj is Dog)
					return this.Name.CompareTo((obj as Dog).Name);
				return 0;
			}
		}
		
        */
    }
}
