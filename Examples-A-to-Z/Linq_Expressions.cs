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




    }
}
