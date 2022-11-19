using System;
using Punygrad;


namespace Punygrad 
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOMETHING");
            var a = new Value(2.0);
            var b = new Value(1.0);
            var c = a + b;
            var d = -c;
            Console.WriteLine(d);
        }

    }

}
