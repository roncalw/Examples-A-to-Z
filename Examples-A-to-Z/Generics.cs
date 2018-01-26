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


            /*                            MyGenericClass3<string> where the class uses one generic type on all fields but where the type is constrained to a reference type                  */
            //Call a generic class that has multiple generic types for some of the fields
            MyGenericClass3<string> strGenericClass3 = new MyGenericClass3<string>("testing");          // Everywhere you see a T1 in the class definition, replace that T1 with int; everywhere you see a T2 in the class definition, replace that T2 with string
            string val5 = strGenericClass3.genericMethod("more testing");                                            //Returns a different type than what was supplied, because the class did not have the return var defined by T

            //If instantiate with <int>, this will crash
            //MyGenericClass3<int> intGenericClass4 = new MyGenericClass3<int>(568);
            //int val6 = intGenericClass.genericMethod(394);


            /*                            Swapper class that is NOT generic but does have a generic method. Can constrain generic methods as well.                  */

            int a = 1;
            int b = 2;

            Swapper.Swap<int>(ref a, ref b);        //Can omit the type argument and the compiler will infer it. Eg. Swapper.Swap(ref a, ref b); Type reference will only work when having parameters

            System.Console.WriteLine(a + " " + b); //Note: Since the class parameters are by reference "a" and "b" will be processed in the Swapper class, the class will not have to return anything 

            Console.ReadLine();


            /*                            SwapIfGreater class that is NOT generic but does have a generic method with a constraint that the type must implement the IComparable<T> Interface.                  */

            int a1 = 1;
            int b1 = 2;

            Swapper.SwapIfGreater<int>(ref a1, ref b1);        //Can omit the type argument and the compiler will infer it. Eg. Swapper.Swap(ref a, ref b); Type reference will only work when having parameters

            System.Console.WriteLine(a1 + " " + b1); //Note: Since the class parameters are by reference "a" and "b" will be processed in the Swapper class, the class will not have to return anything 

            Console.ReadLine();

            //
            
            
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

    /*
     This class is defined with a contstrained generic type.
        Constraint	                Description
        where T: class	            Type must be reference type like a class or string
        where T: struct	            Type must be value type like an integer.
        where T: new()	            Type must have public parameterless constructor.
        where T: <base class name>	Type must be or derive from the specified base class
        where T: <interface name>	Type must be or implement the specified interface.
        where T: U	                Type supplied for T must be or derive from the argument supplied for U.

        If using multiple generic types and need multiple contraints just call the where clause mutliple times
        Eg. class MyGenericClass<T1, T2> where T1: class where T2:struct
    */
    public class MyGenericClass3<T1> where T1: class                //T1 must be a reference type like a class of string
    {
        private T1 genericMemberVariable;

        public MyGenericClass3(T1 value)
        {
            genericMemberVariable = value;
        }

        public T1 genericMethod(T1 genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T1).ToString(), genericParameter);

            Console.WriteLine("Return type: {0}, value: {1}", typeof(T1).ToString(), genericMemberVariable);

            return genericMemberVariable;
        }
    }

    /*This is not a generic class, but it does have a generic method*/
    public class Swapper
    {
        //Swap the left hand side with the right hand side
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static void SwapIfGreater<T>(ref T lhs, ref T rhs) where T : System.IComparable<T>
        {
            T temp;
            /* CompareTo is a .NET built in function that returns an inter
               Eg. If T is String the String.CompareTo(value) method is called which works as follows:
                    VALUE               CONDITION
                    Less than zero      This instance precedes value (strB).

                    Zero                This instance has the same position in the sort order as value.

                    Greater than zero   This instance follows value. -or-value is null.

              Eg. If T is Int32 the Int32.CompareTo(value) method is called which works as follows:
                    VALUE               CONDITION
                    Less than zero      This instance is less than value (value is what is passed in to the CompareTo(value) method.

                    Zero                This instance is equal to value.

                    Greater than zero   This instance is greater than value.
            */
            if (lhs.CompareTo(rhs) > 0)
            {
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        }


    }

}
