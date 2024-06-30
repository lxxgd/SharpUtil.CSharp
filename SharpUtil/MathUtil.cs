namespace SharpUtil
{
    public static class MathUtil
    {

        public static bool NotNaN(this double x)
        {
            return !double.IsNaN(x);
        }

        public static bool IsNaN(this double x)
        {
            return double.IsNaN(x);
        }

        public static bool NotInfinity(this double x)
        {
            return !double.IsInfinity(x);
        }

        public static bool IsInfinity(this double x)
        {
            return double.IsInfinity(x);
        }

        public static bool NotNaN(this float x)
        {
            return !float.IsNaN(x);
        }

        public static bool IsNaN(this float x)
        {
            return float.IsNaN(x);
        }

        public static bool NotInfinity(this float x)
        {
            return !float.IsInfinity(x);
        }

        public static bool IsInfinity(this float x)
        {
            return float.IsInfinity(x);
        }

        public static bool Between(this double value, double a, double b)
        {
            return (value > a && value < b) || (value < a && value > b);
        }

        public static bool Between(this float value, float a, float b)
        {
            return (value > a && value < b) || (value < a && value > b);
        }

        public static bool Between(this int value, int a, int b)
        {
            return (value > a && value < b) || (value < a && value > b);
        }

        public static bool Between(this long value, long a, long b)
        {
            return (value > a && value < b) || (value < a && value > b);
        }
    }
}
