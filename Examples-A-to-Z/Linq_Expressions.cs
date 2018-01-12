using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Linq_Expressions
    {
        /*
         LINQ to query from the following data sources uses the associated provider:
            Object Collection - LINQ to Objects
            ADO.NET Dataset - LINQ to DataSet
            XML Document - LINQ to XML
            Entity Framework - LINQ to Entities
            SQL Database - LINQ to SQL
            Other data sources... - By implementing IQueryable
         */

        /*
         LINQ is nothing but the collection of extension methods for classes that implements IEnumerable and IQueryable interface.
         Eg. System.Linq.Enumerable.Aggregate<> or System.Linq.Queryable.Aggregate<> or System.Linq.Enumerable.Average or System.Linq.Queryable.Average

            - The System.Linq.Enumerable class includes extension methods for the classes that implement IEnumerable<T> interface, this include all the collection types 
              in System.Collections.Generic namespaces such as List<T>, Dictionary<T>, SortedList<T>, Queue<T>, HashSet<T>, LinkedList<T> etc.

            - Queryable class includes extension methods for classes that implement IQueryable<t> interface. IQueryable<T> is used to provide querying 
              capabilities against a specific data source where the type of the data is known. For example, Entity Framework api implements IQueryable<T> 
              interface to support LINQ queries with underlaying database like SQL Server
         */

        /*The following is a sample LINQ query that returns a collection of strings which contains the word "Tutorials" in it. */
        public static void launchExample()
        {
            // string collection
            IList<string> stringList = new List<string>()
            {
                "C# Tutorials",
                "VB.NET Tutorials",
                "Learn C++",
                "MVC Tutorials" ,
                "Java"
            };

                                                                    // LINQ Query Syntax
            /*Query syntax starts with a From clause followed by a Range variable. The From clause is structured like 
            "From rangeVariableName in IEnumerablecollection" (IEnumerablecollection because IList inherits from that). 
            In English, this means, from each object in the collection. It is similar to a foreach loop: foreach (Student s in studentList).

            After the From clause, you can use different Standard Query Operators to filter, group, join elements of the collection. 
            There are around 50 Standard Query Operators available in LINQ. In the above figure, we have used "where" operator (aka clause) followed by a condition. 
            This condition is generally expressed using lambda expression.

            LINQ query syntax always ends with a Select or Group clause. The Select clause is used to shape the data. You can select the whole object as it is or 
            only some properties of it. In the above example, we selected the each resulted string elements.
            
             */
            var result1 = from s in stringList
                         where s.Contains("Tutorials")
                         select s;

            foreach (var str in result1)
            {
                Console.WriteLine(str);
            }


            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            // LINQ Query Syntax to find out teenager students
            var teenAgerStudent1 = from s in studentList
                                  where s.Age > 12 && s.Age < 20
                                  select s;
            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent1)
            {
                Console.WriteLine(std.StudentName);
            }

            // LINQ Method Syntax
            /*Method syntax (also known as fluent syntax) uses extension methods included in the Enumerable or Queryable static class, 
            similar to how you would call the extension method of any class. 

            The method syntax comprises of extension methods and Lambda expression. The extension method Where() is defined in the Enumerable class.
            The signature of the Where extension method below (do mouseover on parenthesis after Where) is a predicate delegate IEnumerable<Student>.Where(Func<Student>, bool> predicate).
            This means that you can pass any function, to the delegate, that accepts a Student object as an input parameter and returns a Boolean value. 
            This lambda expression (inside the Where clause) works since the input, s, is <Student> and the Contains method returns a bool*/

            /*The following is a sample LINQ method syntax query that returns from the same collection of strings above from stringList but this time containing the word "Java" */
            var result2 = stringList.Where(s => s.Contains("Tutorials"));


            foreach (var str in result2)
            {
                Console.WriteLine(str);
            }

            // The following is another example of the LINQ Method syntax to find out the teenager students that were pulled above using the LINQ Query syntax
            var teenAgerStudent2 = studentList.Where(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent2)
            {
                Console.WriteLine(std.StudentName);
            }

        }

    }
}
