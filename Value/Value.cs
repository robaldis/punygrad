
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
        }

        public void Backward(Value left, Value right) 
        {
            Console.WriteLine("OG");
        }


        public double Data { get; }
        public (Value, Value)? Children { get; }
        public string? Op { get; }

        public static Value operator +(Value left, Value right) 
        {
            Value thing = new Value(left.Data + right.Data, (left, right), "+");
            return thing;
        }

        public static Value operator -(Value left, Value right) 
        {
            return new Value(left.Data - right.Data, (left, right), "-");
        }

        public static Value operator *(Value left, Value right) 
        {
            return new Value(left.Data * right.Data, (left, right), "*");
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
