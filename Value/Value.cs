
namespace Punygrad.Lib
{
    class Value
    {


        public Value(double data, 
                (Value, Value)? children=null,
                string? op=null)
        {
            Data = data;
            Children = children;
            Op = op;
            Grad = 0.0;
        }

        public double Data { get; }
        public (Value, Value)? Children { get; }
        public string? Op { get; }
        public double Grad { get; set; }

        public Func<int>? _Backward;

        public static Value operator +(Value left, Value right) 
        {
            Value outValue = new Value(left.Data + right.Data, (left, right), "+");
            outValue._Backward = () => {
                left.Grad = 1.0 * outValue.Grad;
                right.Grad = 1.0 * outValue.Grad;
                return 0;
            };
            return outValue;
        }

        public static Value operator -(Value left, Value right) 
        {
            return new Value(left.Data - right.Data, (left, right), "-");
        }

        public static Value operator *(Value left, Value right) 
        {
            Value outValue = new Value(left.Data * right.Data, (left, right), "*");
            outValue._Backward = () => {
                left.Grad = right.Data * outValue.Grad;
                right.Grad = left.Data * outValue.Grad;
                return 0;
            };
            return outValue;
        }

        public static Value operator /(Value left, Value right) 
        {
            return new Value(left.Data / right.Data, (left, right), "/");
        }
        
        // Unary

        public static Value operator ++(Value value) 
        {
            return new Value(value.Data+1, (value,new Value(1)), "+");
        }

        public static Value operator --(Value value) 
        {
            return new Value(value.Data-1, (value,new Value(1)), "-");
        }

        public static Value operator +(Value value)
        {
            return new Value(+value.Data);
        }

        public static Value operator -(Value value)
        {
            return new Value(-value.Data);
        }

        public override string ToString()
        {
            return $"Value({Data.ToString("#.##")})";
        }
    }
}
