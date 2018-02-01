using System;
using System.Collections;
using System.Collections.Generic;

namespace Examples_A_to_Z
{
    class IEnumerable_IEnumerator_foreach
    {
        public static void launchExample()
        {
            // Create a Tokens instance. (token: a representation of something else, in this case a token represents a part of sentence)
            //The tokens will be created by splitting this string here using the space as a delimiter
            Tokens f = new Tokens("This is a sample sentence.", new char[] { ' ', '-' });

            /* 
                Display the tokens. Note the foreach here will require that the tokens class have a GetEnumerator method in it
                whose return type is an Enumerator. This is because we are saying to the foreach to enumerate using the method in f vs saying to do the foreach in a specific method.
                If we did specify the method name like GoGetIt() then the return must be IEnumerable such as specifing IEnumerable or List if returning a list (see comment below)

            */
            foreach (string item in f)
            {
                System.Console.WriteLine(item);
            }
        }
    }

    /*
        Can comment out the Interface implmentation syntax but is good practice here because it will enforce adding the GetNumerator() method which the foreach requires when 
        enumerating on a class (eg. "... in f" where f is the class) vs being told what method to go to.
    */
    public class Tokens : IEnumerable 
    {
        private string[] elements;

        public Tokens(string source, char[] delimiters)
        {
            // The constructor parses the string argument into tokens.
            elements = source.Split(delimiters);
        }


        //The IEnumerable interface (being implemented in the above syntax) requires implementation of this method GetEnumerator and the foreach requires that it return an IEnumerator because 
        //the foreach iteration is being done "in" a class vs specifying a method name. (see the foreach comments above for more details.
        //The Get Enumerator just simply returns an enumerator back to the foreach
        public IEnumerator GetEnumerator()
        {
            /*
             * When you use the yield keyword in a statement, you indicate that the method, operator, or get accessor in which it appears is an iterator. 
             * Using yield to define an iterator removes the need for an explicit extra class (the class that holds the state for an enumeration
             * If you uncomment this section here and comment out the line below, return new TokenEnumerator(this); and its class below it
             * This will work as an enumerator. This is because, yield is an iterator.
                var i = 0;

                while (i < 4)
                {
                    yield return elements[i];
                    i++;
                }
            */

            //This returns an Enumerator since the TokenEnumerator class does implement the IEnumerator interface
            return new TokenEnumerator(this);        


            /*
                    Cannot return a list type to the foreach as in the following and as in the other example file for yield (where it shows an example of returning a List type)
                    when the return type is IEnumerator as we are forced to define since the foreach's "in" refers to an object, "f", that forces the foreach to find the 
                    GetEnumerator method in that object that has a return type of IEnumerator.
                    
                    Can return a List type if you change the return type of the GetEnumerator here to IEnumerable or List type
                    
                    Eg. If substituted f with f.GetEnumerator telling the foreach where the GEtEnumerator is you would still have to change the return type to 
                    IEnumerable or List<string> because if the return type is IEnumerator then the return type must only be an Enumerator which is yield like in the above example 
                    or a class that implements an Enumerator like the exmaple above that.
            */

            /*
                    var list = new List<string>();

                    while (i < 5)
                    {
                        list.Add(elements[i]);
                        i++;
                    }
                
                    return list;
            */

        }


        // Declare an inner class that implements the IEnumerator interface.
        
        private class TokenEnumerator : IEnumerator
        {
            private int position = -1;
            private Tokens t;

            public TokenEnumerator(Tokens t)
            {
                this.t = t;
            }

            // The IEnumerator interface requires a MoveNext method.
            public bool MoveNext()
            {
                if (position < t.elements.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // The IEnumerator interface requires a Reset method.
            public void Reset()
            {
                position = -1;
            }

            // The IEnumerator interface requires a Current method.
            public object Current
            {
                get
                {
                    return t.elements[position];
                }
            }
        }
    }
 }
