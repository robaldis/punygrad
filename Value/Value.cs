
namespace Punygrad.Lib
{
    class Value
    {
        public Value(double data,
                    (Value, Value?)? children = null,
                    string? op = null)
        {
            Data = data;
            Children = children;
            Op = op;
            Grad = 0.0;
        }

        public double Data { get; }
        public (Value, Value?)? Children { get; }
        public string? Op { get; }
        public double Grad { get; set; }

        public Func<int>? _Backward;

        private static int _argCount;

        public static Value operator +(Value left, Value right)
        {
            _argCount = 1;
            Console.WriteLine(_argCount);
            Value outValue = new(left.Data + right.Data, (left, right), "+");
            outValue._Backward = () =>
            {
                left.Grad = 1.0 * outValue.Grad;
                right.Grad = 1.0 * outValue.Grad;
                return 0;
            };
            return outValue;
        }

        public static Value operator -(Value left, Value right)
        {
            Value outValue = new(left.Data - right.Data, (left, right), "-");
            outValue._Backward = () =>
            {
                left.Grad = 1.0 * outValue.Grad;
                right.Grad = 1.0 * outValue.Grad;
                return 0;
            };
            return outValue;
        }

        public static Value operator *(Value left, Value right)
        {
            Value outValue = new(left.Data * right.Data, (left, right), "*");
            outValue._Backward = () =>
            {
                left.Grad = right.Data * outValue.Grad;
                right.Grad = left.Data * outValue.Grad;
                return 0;
            };
            return outValue;
        }
        public static Value operator /(Value left, Value right)
        {
            return left * Pow(right, -1);
        }

        public static Value Pow(Value left, int right)
        {
            return Pow(left, (float)right);
        }

        public static Value Pow(Value left, float right)
        {
            var outValue = new Value(Math.Pow(left.Data, right), (left, null), "**");
            outValue._Backward = () =>
            {
                left.Grad += right * Pow(left, -1).Data * outValue.Grad;
                return 0;
            };

            return outValue;
        }

        public static Value Tanh(Value left)
        {
            var x = left.Data;
            var t = (Math.Exp(2 * x) - 1) / (Math.Exp(2 * x) + 1);
            Value outValue = new(t, (left, null), "*");
            outValue._Backward = () =>
            {
                left.Grad = (1 - Math.Pow(t, 2)) * outValue.Grad;
                return 0;
            };
            return outValue;
        }

        public override string ToString()
        {
            return $"Value({Data.ToString("#.##")})";
        }
    }
}
