using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Abstract_Class
    {
        public static void launchExample()
        {
            /*Abstract classes, marked by the keyword abstract in the class definition, are typically used to define a base class in the hierarchy. 
            What's special about them, is that you can't create an instance of them - if you try, you will get a compile error. Instead, you have to subclass them.
            If you uncomment the following line you will get the following error since you cannot compile trying to create an instance of an abstract class. */

                //FourLeggedAnimal someAnimal = new FourLeggedAnimal();

            /*So when do you need an abstract class? It really depends on what you do.");

            To be honest, you can go a long way without needing an abstract class, but they are great for specific things, like frameworks, which is why you will find 
            quite a bit of abstract classes within the .NET framework it self. A good rule of thumb is that the name actually makes really good sense - abstract classes 
            are very often, if not always, used to describe something abstract, something that is more of a concept than a real thing.

            Eg. four legged animals, this is abstract because it is not something you can touch. You can touch a dog, a cat, both four legged animals, which could be subclasses.
            
            Create a new instance of the Dog class and then call the inherited Describe() method from the FourLeggedAnimal class.*/

                Dog dog = new Dog();

                Console.WriteLine(dog.Describe());

            /*Completely override the inherited Describe() method from the FourLeggedAnimal class.*/

                Cat cat = new Cat();

                Console.WriteLine(cat.Describe());

            /*Use the behavior from the base class in addition to new functionality. This can be done by using the \"base\" keyword, which refers to the class we inherit from.*/

                Rabbit rabbit = new Rabbit();

                Console.WriteLine(rabbit.Describe());

        }


        abstract class FourLeggedAnimal
        {
            public virtual string Describe()
            {
                return "Not much is known about this four legged animal!";
            }
        }


        class Dog : FourLeggedAnimal
        {

        }


        class Cat : FourLeggedAnimal
        {
            public override string Describe()
            {
                return "This four legged animal is a Cat!";
            }

        }


        class Rabbit : FourLeggedAnimal
        {
            public override string Describe()
            {

                string result = base.Describe();
                result += " In fact, it's a rabbit!";
                return result;
            }

        }
    }
}
