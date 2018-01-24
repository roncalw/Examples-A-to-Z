using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Lambda_Expression
    {
        //Uncomment this line when not using Func
        //delegate bool IsTeenAger(Student stud);

        //Uncomment this line when not using Action
        //delegate void Printer(Student stdt);

        public static void launchExample()
        {
            /*Using Lambda is a shorthand method for writing anonymous methods (methods on the fly that are not declared and given a name 
             It saves us from using the following anonymous method assignment to the delegate (on the right side of the = sign): 
            
            using anonymous ...     IsTeenAger isTeenAger   = delegate (Student s) { return s.Age > 12 && s.Age < 20; };
            using lambda ...        IsTeenAger isTeenAger   =                   s  =>       s.Age > 12 && s.Age < 20;
            
            The delegate isTeenAger is declared with the delegate type that returns a bool and accepts just the one paramter of the type Student -- IsTeenAger(Student stud) 
            So as you can see here, s is the parameter on the left side of the => and that the expression on the right of the => is from the body of the anonymous which must return a boolean.

            */

            /*Func*/

            /*Func similar to Action<T> is a delegate but can accept more than one parameter and can return something
            Do not need the delegate declaration above just like when using Action<T>
            The last parameter type in a Func<> delegate is the return type and the rest are input parameters*/

            /*If not using Func, uncomment the delegate declaration above and run this statement instead:              
            IsTeenAger isTeenAger = s => s.Age > 12 && s.Age < 20;                                      */

            /*There are two parts here to the following statement
                * Func<Student, bool> isTeenAger
                    - makes it so that isTeenager is a delegate with a return type of bool that accepts just one parameter with the type "Student"

                * s => s.Age > 12 && s.Age < 20
                    - Lambda expression where
                        - s is a parameter
                        - => is the lambda operator and 
                        - s.Age > 12 && s.Age < 20 is the body expression
            */
            Func<Student, bool> isTeenAger = s => s.Age > 12 && s.Age < 20;

            Student stud = new Student() { Age = 25 };

            Console.WriteLine(isTeenAger(stud));

                                                    /*Action*/

            /*Similar to Func but not returning anything, just doing, and can only accept one parameter*/

            /*If not using Action, uncomment the delegate declaration above and run this statement instead: 
            Printer PrintStudentDetail = s => Console.WriteLine("Name: {0}, Age: {1} ", s.Name, s.Age);       */

            Action<Student> PrintStudentDetail = s => Console.WriteLine("Name: {0}, Age: {1} ", s.StudentName, s.Age);

            Student std = new Student() { StudentName = "Bill", Age = 21 };

            PrintStudentDetail(std);

        }
    }

}
