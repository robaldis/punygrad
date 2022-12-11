using System;
using Punygrad.Lib;


namespace Punygrad 
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOMETHING");
            var a = new Value(2.0);
            var b = new Value(1.0);
            var c = new Value(1.0);
            var d = a + b;
            var e = d * c;
            e.Grad = 1;
            e._Backward();
            Console.WriteLine(e);
            Console.WriteLine(d.Grad);
            Console.WriteLine(c.Grad);
        }

    }

}
