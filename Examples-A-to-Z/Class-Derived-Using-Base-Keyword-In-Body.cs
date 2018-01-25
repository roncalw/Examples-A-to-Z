using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples_A_to_Z
{
    class Class_Derived_Using_Base_Keyword_In_Body
    {
        public static void launchExample()
        {
            Perl perl = new Perl();
            perl.Write();
        }
    }
    class Net
    {
        public int _value = 6;
    }

    class Perl : Net
    {
        public new int _value = 7;
        public void Write()
        {
            // Show difference between base and this.
            Console.WriteLine(base._value);
            Console.WriteLine(this._value);
        }
    }
}
