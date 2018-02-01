using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Generic_Custom_List
    {
        public static void launchExample()
        {
            string StartDebuggerHer = "Start Debugger here"; //Start dubber on the Console.Write line
            Console.WriteLine(StartDebuggerHer);

            // int is the type argument for creating a custom build list object.
            GenericList<int> list = new GenericList<int>();

            for (int x = 0; x < 10; x++)
            {
                list.AddHead(x);
            }

            /*
                The foreach method requires that "list" here in the parenthesis contain a method definition of GetEnumerator() of the type IEnumerator<T>, see the example file 
                here that explains the foreach and IEnumerable/IEnumerator in more detail.

                Debugging will show that control starts at foreach, then goes to list, then in, and then straight to the enumerator. 
            */
            foreach (int i in list)
            {
                System.Console.Write(i + " ");
            }
            System.Console.WriteLine("\nDone");
        }
    }

    /*
    
    The GenericList<T> class contains a nested class called Node which will be what holds the data in the custom list
    The caller will instantiate a new Node pbject for each item in the list storing the value of each in the Data property (gets updated via the constructor)
    The class has another property called Next that is of its own class' type which is Node that the caller will use to copy the Node object that was last instantiated to it
    (via a temporary holding variable called Head that stores the last Node instantiation). 

    Based on the loop above to store the list of items, there will be 9 node objects when complete, each object will have the corresponding item value stored in the Data property 
    along with storing the previous instantiation of the node object itself in the Next property.

        The objects will look like the followingL
        Instantiation A:(node.Data=1,node.Next=null), B:(node.Data=2,node.Next=node(A)), C:(node.Data=3,node.Next=node(B)), D:(node.Data=4,node.Next=node(C)), E:(node.Data=5,node.Next=node(D)), ...
    
    This list is created by the repeated calls to the AddHead method abovev which
        * 1st Creates a new Node Method (assigning the data from the item immediately through the constructor in Node
        * 2nd Assigns the Head object (which is of type Node to be used for copying the Node object like Next) to the Next property of this newly instantiated Node object 
                    (Head will not have a value yet the 1st time this is called so Null will be assigned to Next the 1st time, but because in the very next step after this one
                    the new Node object is assigned to the Head object, the next time this AddHead method is called the head object will be equal to the previous node object, to then 
                    be assigned to Next, so the 2nd time this is called the 2nd instantiation of Node will store the previous instantiation of NOde
        * 3rd Assigns the new Node object to the Head object (so that Head can be assigned in the next AddHead method call to the Node.Next property (the 2nd step here of this method).

    */
    public class GenericList<T>
    {
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }

            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            // T as private member data type.
            private T data;

            // T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        // constructor
        public GenericList()
        {
            head = null;
        }

        // T as method parameter type:
        //AddHead creates a new Node that will store the value passed in as t. 
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //See the loop orocess above for details
            //the value of head represents a copy of the last Node object that was instantiated in the AddHead method via the loop above
            Node current = head;

            //Since current is now a copy of head which was the last instantiation of the Node object, the value of current.Data will be 9 in the loop and the value of 
            //current.Next will the 8th instantiation of the Node object which will get assigned to current in the last line, so that current will now be the 8th instantiation 
            //of the Node object.
            //When looping through again, the Data property will therefore be the value that correpsonds to the 8th instatiation of the Node object, and the Next property will be 
            //the 7th instantiation of the Node object and so on and so on.
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
