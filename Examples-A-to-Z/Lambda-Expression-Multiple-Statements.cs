using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Lambda_Expression_Multiple_Statements
    {
        delegate bool IsYoungerThan(Student stud, int youngAge);

        public static void launchExample()
        {
            //Wrap expressions in curly braces if you want to have more than one statement in the body
            IsYoungerThan isYoungerThan = (s, youngAge) => 
            {
                //Can add local variables here if needed as well

                Console.WriteLine("Lambda expression with multiple statements in the body");

                return s.Age < youngAge;
            };

            Student stud = new Student() { Age = 25 };

            Console.WriteLine(isYoungerThan(stud, 26));
        }
    }
}
