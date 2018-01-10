/*

Abstract methods are only allowed within abstract classes. Their definition will look like a regular method, but they have no code inside them: 

You want to define an empty method that does nothing because an abstract method is an obligation to implement that very method in all subclasses. 
In fact, it's checked at compile time, to ensure that your subclasses has this method defined. 

This is a great way to create a base class for something, while still maintaining a certain amount of control of what the subclasses should be able to do. 
With this in mind, you can always treat a subclass as its baseclass, whenever you need to use methods defined as abstract methods on the baseclass. 

*/
using System;

namespace Examples_A_to_Z
{
    class Abstract_Class_W_Abstract_Method
    {
        public static void launchExample()
        {

            System.Collections.ArrayList animalList = new System.Collections.ArrayList();

            animalList.Add(new Dog());
            animalList.Add(new Cat());

            foreach (FourLeggedAnimal animal in animalList)
                Console.WriteLine(animal.Describe());
        }

        /*Must be empty, ;If you try to add something like a return with a string it will give you the following compile error:
            Compilation error (line 22, col 31): 'Program.FourLeggedAnimal.Describe()' cannot declare a body because it is marked abstract*/

        abstract class FourLeggedAnimal
        {
            public abstract string Describe();
        }

        class Dog : FourLeggedAnimal
        {
            public override string Describe()
            {
                return "I'm a dog!";
            }
        }

        class Cat : FourLeggedAnimal
        {
            public override string Describe()
            {
                return "I'm a cat!";
            }
        }
    }
}
