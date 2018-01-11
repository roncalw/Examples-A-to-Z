using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Lambda_Expression_Multiple_Parameters
    {
        delegate bool IsYoungerThan(Student stud, int youngAge);

        public static void launchExample()
        {
            IsYoungerThan isYoungerThan = (s, youngAge) => s.Age < youngAge;

            /*Or the following: 
             
            IsYoungerThan isYoungerThan = (StudentColl s, int youngAge) => s.Age < youngAge;

             */

            Student stud = new Student() { Age = 25 };

            Console.WriteLine(isYoungerThan(stud, 26));
        }
    }
    
}
