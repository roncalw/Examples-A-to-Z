using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Decorator_Pattern
    {
        /*
         The role of the decorator pattern is to add the state and behavior to an object dynamically. 
         The object does not know that it is being decorated therefore it is useful pattern for evolving systems.
         You pass the object to an instance of another class that the other class extends it (decorates it).
         So the original object being passed passes the open/closed principle, where it is extended but not modified.
         This is why this pattern is so popular.
         This example was taken from http://www.dotnetforall.com/c-decorator-pattern/ a more realistic example can
         be found at https://assist-software.net/blog/implementation-decorator-pattern-c
         */

        public static void launchExample()
        {
            ICar traditionalCar = new Car();
            traditionalCar.Drive();
            traditionalCar.Brake();

            //Pass the car object into the decorator
            SuperCar superCar = new SuperCar(traditionalCar);
            superCar.Drive();
            superCar.Music();
            superCar.Brake();
            Console.Read();
        }

        /// <summary>
        /// This is my legacy component
        /// </summary>
        public interface ICar
        {
            void Drive();
            void Brake();
        }

        public class Car : ICar
        {
            public void Brake()
            {
                Console.WriteLine("Used the pad brakes");
            }

            public void Drive()
            {
                Console.WriteLine("The speed goes upto 100 Kmph");
            }
        }

        /// <summary>
        /// This class is the decorator of the Car class. It adds and modifies the behaviour of the car class
        /// </summary>
        public class SuperCar : ICar
        {
            public ICar car;
            public SuperCar(ICar car)
            {
                this.car = car;
            }

            public void Brake()
            {
                car.Brake();
                Console.WriteLine("Also has hand brake");
            }

            public void Drive()
            {
                Console.WriteLine("The speed goes upto 300 Kmph");
            }

            public void Music()
            {
                Console.WriteLine("Plays the Hi Fi music system");
            }
        }
    }
}
