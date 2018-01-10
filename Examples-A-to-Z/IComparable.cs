using System;
using System.Collections.Generic;

namespace Examples_A_to_Z
{
    class IComparable
    {
        public static void launchExample()
        {
            List<Dog> dogs = new List<Dog>();

            dogs.Add(new Dog("Fido"));
            dogs.Add(new Dog("Bob"));
            dogs.Add(new Dog("Adam"));

            dogs.Sort();

            foreach (Dog dog in dogs)
                Console.WriteLine(dog.Describe());

        }/*
	
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
         //or

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
    }
}
