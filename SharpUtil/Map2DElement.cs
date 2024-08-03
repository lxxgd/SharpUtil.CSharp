﻿namespace SharpUtil
{
    public class Map2DElement<T>
    {
        public int X { get; }
        public int Y { get; }
        public T? Value { get; set; }

        public Map2DElement(int x, int y, T? value)
        {
            X = x;
            Y = y;
            Value = value;
        }
    }
}
