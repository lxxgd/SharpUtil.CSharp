using System.Runtime.CompilerServices;

namespace SharpUtil
{
    public static class RandomUtil
    {
        public static bool NextBoolean(this Random random)
        {
            return random.Next() % 2 == 0;
        }

        public static bool NextBoolean(this Random random, double probability)
        {
            return probability switch
            {
                < 0 => throw new ArgumentException("probability must be non-negative", nameof(probability)),
                >= 1 => true,
                0 => false,
                _ => random.NextDouble() < probability
            };
        }

        public static bool NextBoolean(this Random random,double numerator,double denominator) 
        {
            if (numerator < 0)
                throw new ArgumentException("numerator must be non-negative", nameof(numerator));
            if(denominator <= 0)
                throw new ArgumentException("denominator must be positive", nameof(denominator));
            if (numerator == 0)
                return false;
            if (numerator >= denominator)
                return true;
            return random.NextDouble() < numerator / denominator;
        }

        public static float NextSingle(this Random random,float max) 
        {
            return random.NextSingle() * max;
        }

        public static float NextFloat(this Random random, float max)
        {
            return NextSingle(random, max);
        }

        public static float NextSingle(this Random random,float min,float max)
        {
            return random.NextSingle() * (max - min) + min;
        }

        public static float NextFloat(this Random random, float min, float max)
        {
            return NextSingle(random, min, max);
        }

        public static double NextDouble(this Random random,double max)
        {
            return random.NextDouble() * max;
        }

        public static double NextDouble(this Random random, double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        public static int NextInt(this Random random) 
        {
            return random.Next();
        }

        public static int NextInt(this Random random, int max)
        {
            return random.Next(max);
        }

        public static int NextInt(this Random random, int min, int max)
        {
            return random.Next(min, max);
        }

        public static long NextLong(this Random random) 
        {
            return random.NextInt64();
        }

        public static long NextLong(this Random random, long max)
        {
            return random.NextInt64(max);
        }

        public static long NextLong(this Random random, long min, long max)
        {
            return random.NextInt64(min, max);
        }

        public static char NextChar(this Random random, char min, char max)
        {
            return (char)random.Next(min, max + 1);
        }

        public static char NextChar(this Random random) 
        {
            return (char)random.Next(char.MinValue, char.MaxValue + 1);
        }
    }
}
