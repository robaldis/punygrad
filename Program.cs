using Punygrad.Lib;


namespace Punygrad
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inputs
            Value x1 = new(2.0);
            var x2 = new Value(0.0);
            // Wieghts
            var w1 = new Value(-3.0);
            var w2 = new Value(1.0);
            // Bias
            var b = new Value(6.8813735870195432);

            var x1w1 = x1 * w1;
            var x2w2 = x2 * w2;
            var x1w1x2w2 = x1w1 + x2w2;
            var n = x1w1x2w2 + b;
            Value o = Value.Tanh(n);
            string something = "something";
            Console.WriteLine(something);

            o.Grad = 1;
            o._Backward();
            n._Backward();
            x1w1x2w2._Backward();
            x1w1._Backward();
            x2w2._Backward();

            Console.WriteLine(n.Grad);
            Console.WriteLine(x1w1x2w2.Grad);
            Console.WriteLine(b.Grad);
            Console.WriteLine(x2w2.Grad);
            Console.WriteLine(x1w1.Grad);
            Console.WriteLine(x1.Grad);
            Console.WriteLine(w1.Grad);
            Console.WriteLine(x2.Grad);
            Console.WriteLine(w2.Grad);

            Console.WriteLine("------------------------------");


            Value r = new Value(1);
            Value t = new Value(2);
            Value k = r / t;
            k.Grad = 1;
            Console.WriteLine(k);
            k._Backward();
            Console.WriteLine(r.Grad);
            Console.WriteLine(t.Grad);


        }

    }

}
