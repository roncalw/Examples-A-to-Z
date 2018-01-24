using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Generics
    {
        /*
         Generics were introduced in C# 2.0. Generics allow you to define a class with placeholders for the type of its fields, methods, parameters, etc. 
         Generics replace these placeholders with some specific type at compile time.

         Instead of defining the fields by type in the body of a class, define using a variable for the type as well, like "T", then when instianted and supplying the type
         that T will be replaced with the supplied type. 
        */
        public static void launchExample()
        {
            /*                                                                      MyGenericClass<T>                      */
            MyGenericClass<int> intGenericClass = new MyGenericClass<int>(10);                  // Everywhere you see a T in the class definition, replace that T with int
            int val1 = intGenericClass.genericMethod(200);

            MyGenericClass<string> strGenericClass = new MyGenericClass<string>("Smally");      // Everywhere you see a T in the class definition, replace that T with string
            string val2 = strGenericClass.genericMethod("Biggy");


            /*                                  MyGenericClass1<T> where the class does not have a T for all of the members but has some with a declared type                  */
            //Call a generic class that has some of the fields with a type that does not change (not all fields are generic, a mix)
            MyGenericClass1<int> strGenericClass1 = new MyGenericClass1<int>();                 // Everywhere you see a T in the class definition, replace that T with int
            string val3 = strGenericClass1.genericMethod(5);                                    //Returns a different type than what was supplied, because the class did not have the return var defined by T


            /*                                MyGenericClass2<int,string> where the class does not have just Ts for all of the members but has a mix of T1 and T2                  */
            //Call a generic class that has multiple generic types for some of the fields
            MyGenericClass2<int,string> strGenericClass2 = new MyGenericClass2<int,string>("testing");  // Everywhere you see a T1 in the class definition, replace that T1 with int; everywhere you see a T2 in the class definition, replace that T2 with string
            string val4 = strGenericClass2.genericMethod(5);                                            //Returns a different type than what was supplied, because the class did not have the return var defined by T

        }
    }

    /*
     Instead of defining the fields by type in the body of the class below, define using variable for the type as well, like "T", then when instianted and supplying the type
     that T will be replaced with the supplied type:
    */
    public class MyGenericClass<T>
    {
        private T genericMemberVariable;

        public MyGenericClass(T value)
        {
            genericMemberVariable = value;
        }

        public T genericMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);

            return genericMemberVariable;
        }

        //public T genericProperty { get; set; }
    }

    /*
     This class does not define all of the fields by T and instead supplies an actual type for some of the fields. Eg. String for a private variable.
    */
    public class MyGenericClass1<T>
    {
        private string genericMemberVariable;

        public MyGenericClass1()
        {
            genericMemberVariable = "Mixed Generic";
        }

        public string genericMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);

            Console.WriteLine("Return type: {0}, value: {1}", typeof(string).ToString(), genericMemberVariable);

            return genericMemberVariable;
        }
    }

    /*
     This class is defined with multiple generic types.
    */
    public class MyGenericClass2<T1,T2>
    {
        private T2 genericMemberVariable;

        public MyGenericClass2(T2 value)
        {
            genericMemberVariable = value;
        }

        public T2 genericMethod(T1 genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T1).ToString(), genericParameter);

            Console.WriteLine("Return type: {0}, value: {1}", typeof(T2).ToString(), genericMemberVariable);

            return genericMemberVariable;
        }
    }
}
