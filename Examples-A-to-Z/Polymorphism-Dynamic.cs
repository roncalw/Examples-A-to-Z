using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Polymorphism
    {
        /*        
        Polymorphism helps to promote flexibility in designs by allowing the same method to have different implementations. 
        In essence, you can leverage polymorphism to separate interface from implementation. 
        It promotes code reuse and separation of concerns in your application
             
        It promotes code reuse and separation of concerns in your application.
        
        There are three types of polymorphism:
            * Inclusion -   which is this example below; it is also called Method Overriding and can be achieved in C# using virtual methods
                            When you have a function defined in a class that you want to be implemented in an inherited class(es), you use virtual functions. 
                            The virtual functions could be implemented differently in different inherited class and the call to these functions will be decided at runtime.
                            In method overriding, you have methods having identical signatures present in both the base and the derived classes. 
                            You would typically want to use virtual methods to implement run-time polymorphism or late binding. 
                            Note that a virtual method is one that is declared as virtual in the base class and you can allow the subclasses of the type to 
                            override the virtual method(s)
            * Parametric -  Parametric polymorphism, or template polymorphism, is a type where you have more than one method in your class with identical names 
                            but varying parameters, i.e., they all have the same method names, but they differ in the parameters.
            * Overloading - Overloading polymorphism is a type that exists in classes that are independent of each other -- they are not related 
                            (inheritance, dependency, etc.) to each other in any way. As an example, you can have two distinct classes not related in any way with each other 
                            and having a method with the same name. Operator overloading is an example of this type of polymorphism.
             
        */
        public static void launchExample()
        {
            Caller c = new Caller();
            Rectangle r = new Rectangle(10, 7);
            Triangle t = new Triangle(10, 5);
            c.CallArea(r);
            c.CallArea(t);
            Console.ReadKey();
        }
    }

    abstract class Shape
    {
        protected int width, height;

        public Shape(int a = 0, int b = 0)
        {
            width = a;
            height = b;
        }

        public virtual int area()
        {
            Console.WriteLine("Parent class area :");
            return 0;
        }
    }

    class Rectangle : Shape
    {
        public Rectangle(int a = 0, int b = 0) : base(a, b)
        {

        }

        public override int area()
        {
            Console.WriteLine("Rectangle class area :");
            return (width * height);
        }
    }

    class Triangle : Shape
    {
        public Triangle(int a = 0, int b = 0) : base(a, b)
        {

        }

        public override int area()
        {
            Console.WriteLine("Triangle class area :");
            return (width * height / 2);
        }
    }

    class Caller
    {
        public void CallArea(Shape sh)
        {
            int a;
            a = sh.area();
            Console.WriteLine("Area: {0}", a);
        }
    }
}
