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

            sList.Add("Chadwick");
            sList.Add("Terry");
            sList.Add("Lou");

            //The following sort method will only work on objects that implemented the IComparable or IComparable<T> interface; 
            //therefore because this works on the string array below, this means that the String class implements this interface.
            sList.Sort();

            foreach (string lName in sList)
            {
                Console.WriteLine("My name is {0}", lName);
            }

            /*
             The sort method will not work therefore on objects that are custom built (which creates a custom type) unless the object implements this interface. 
             
             The reason why the sort() method will not work on objects that do not implement the interface is because when calling the List<T>.Sort method without any parameters it uses 
             the Comparer<T>.Default property to determine how to sort and therefore needs it. This property will actually look at T to see if it implements the IComparable<T> or IComparable 
             interface and if it does it will use the implementation in T to determine how to sort, which is by looking at the CompareTo method. (If T does not implement either interface it will 
             actually throw an InvalidOperationException.)
             
             Eg. The sort method on the Dog object below will not crash because the Dog object implements the IComparable<T> interface, because implementing that interface passes the check from the 
             Comparer<T>.Default property that enforces T to implement either the IComparable<T> or IComparable interface so that it can then use that implementation of CompareTo in T. 

             As part of creating this CompareTo method in the Dog abject it will then define the details of the CompareTo method as well, such as what property of the class to run the comparison 
             on and promising that the CompareTo will only compare Dog objects to other Dog objects.

             Without the CompareTo in the Dog object the sort would not have known if the sort should be on the Dog ID or the Dog Name.

             The following is an example of the CompareTo on a string (Eg. Dog.Name)

             Eg. CompareTo is a .NET built in function that returns an integer which works as follows on this s1.CompareTo(s2):
                    VALUE               CONDITION
                    Less than zero      This instance precedes value (strB).

                    Zero                This instance has the same position in the sort order as value.

                    Greater than zero   This instance follows value. -or-value is null.                 
                         
             Once the Comparer is determined, tt then uses Array.Sort to get the algorithm to know what ints or strings etc become before or after in sort order.
         
            */

            List<Dog> dogs = new List<Dog>();

            dogs.Add(new Dog("Fritzie",1));
            dogs.Add(new Dog("Allie",2));
            dogs.Add(new Dog("Holllie",3));
            dogs.Add(new Dog("George",4));

            dogs.Sort();

            foreach (Dog ldog in dogs)
            {
                Console.WriteLine("My dog name is: {0}, my ID is: {1} ",ldog.Name,ldog.ID);
            }

            /*
            If passing the Comparer to the sort method instead however, such as Sort(comparer). you can bypass using the default comparer as specified above.

            The Sort(comparer) method will instead use your own Comparer object that is passed in, this class must implement the Comparer<T> class or IComparer<T> interface which requires 
            a Compare(T, T) method. So this sort isn't looking in your class for the comparer because we are giving it the comparer.

            Signature: public void Sort (System.Collections.Generic.IComparer<T> comparer);
            Interface: Requires the Compare(T, T) method.
            Eg Call: Sort(comparer)

            When making your own comparer it is recommended by Microsoft to derive from Comparer<T> instead of implementing your own for the IComparer<T> interface.

            The following is an example of deriving from Comparer<T>
            */

            /*Notice this is not sorting by the default (which is Name as defined in the Dog object). 
            This is sorting by ID instead because that is what the Comparer class that we build says to sort by             
            */
            dogs.Sort(new DogCompareByID()); 
            

            foreach (Dog ldog in dogs)
            {
                Console.WriteLine("My dog name is: {0}, my ID is: {1} ", ldog.Name, ldog.ID);
            }

            DogCompareByID IDFirst = new DogCompareByID();

            Dog DogA = new Dog("Princess", 22);
            Dog DogB = new Dog("Fido", 22);

            int x = IDFirst.Compare(DogA, DogB);

            Console.WriteLine();
            Console.WriteLine(x.ToString());

        }
        public class Dog : IComparable<Dog>
        {       
            public Dog(string name, int id)
            {
                Name = name;
                ID = id;
            }

            public string Name { get; set; }

            public int ID { get; set; }

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

        //It is recommended by Microsoft to derive from Comparer<T> vs implementing from IComparer<T> 
        //Code wise the onnly difference between the two is getting rid of the "override" key word since that does not apply 
        //and of course changing the implementation from Comparer<Dog> to IComparer<Dog>
        public class DogCompareByID : Comparer<Dog>
        {
            public override int Compare(Dog x, Dog y)
            {
                return x.ID.CompareTo(y.ID);
            }
        }
    }
}
