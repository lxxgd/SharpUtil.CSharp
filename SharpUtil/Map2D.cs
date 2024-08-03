using System.Collections;

namespace SharpUtil
{ 
    /// <summary>
    /// 二维地图，类似于二维数组
    /// </summary>
    /// <typeparam name="T">
    /// 元素类型
    /// </typeparam>
    public class Map2D<T> : IMap2D<T>
    {
        private Map2DElement<T>[,] _map;
        private int _width;
        private int _height;

        public Map2D(int width, int height)
        {
            _width = width;
            _height = height;
            _map = new Map2DElement<T>[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _map[x, y] = new Map2DElement<T>(x, y, default);
                }
            }
        }

        public Map2D(T[,] array)
        {
            _width = array.GetLength(0);
            _height = array.GetLength(1);
            _map = new Map2DElement<T>[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _map[x, y] = new Map2DElement<T>(x, y, array[x, y]);
                }
            }
        }

        public Map2D(Map2D<T> other)
        {
            _width = other._width;
            _height = other._height;
            _map = new Map2DElement<T>[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _map[x, y] = new Map2DElement<T>(x, y, other._map[x, y].Value);
                }
            }
        }

        public bool ValidIndex(int x, int y)
        {
            return x >= 0 && x < _width && y >= 0 && y < _height;
        }

        public T? this[int x, int y]
        {
            get { return _map[x, y].Value; }
            set { _map[x, y].Value = value; }
        }

        public void Clear()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _map[x, y].Value = default;
                }
            }
        }

        public void CopyFrom(Map2D<T> other, bool resize = true)
        {
            if (resize)
            {
                Resize(other._width, other._height);
            }
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (other.ValidIndex(x, y))
                        _map[x, y].Value = other._map[x, y].Value;
                }
            }
        }

        public void CopyTo(Map2D<T> other, bool resize = true)
        {
            if (resize)
            {
                other.Resize(_width, _height);
            }
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (other.ValidIndex(x, y))
                        other._map[x, y].Value = _map[x, y].Value;
                }
            }
        }

        public Map2D<T> Clone()
        {
            var newMap = new Map2D<T>(_width, _height);
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    newMap._map[x, y].Value = _map[x, y].Value;
                }
            }
            return newMap;
        }

        public Map2DElement<T> GetElement(int x, int y)
        {
            return _map[x, y];
        }

        public void Exchange(int x1, int y1, int x2, int y2)
        {
            (_map[x2, y2].Value, _map[x1, y1].Value) = (_map[x1, y1].Value, _map[x2, y2].Value);
        }

        public void Fill(T value)
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _map[x, y].Value = value;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
#pragma warning disable CS8603 // 可能返回 null 引用。
                    yield return _map[x, y].Value;
#pragma warning restore CS8603 // 可能返回 null 引用。
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        public void Resize(int width, int height)
        {
            if (width == _width && height == _height)
            {
                return;
            }
            var newMap = new Map2DElement<T>[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x < _width && y < _height)
                    {
                        newMap[x, y] = _map[x, y];
                    }
                    else
                    {
                        newMap[x, y] = new Map2DElement<T>(x, y, default);
                    }
                }
            }
            _map = newMap;
            _width = width;
            _height = height;
        }

        public int Count { get { return _width * _height; } }

        public bool Contains(T value)
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var element = _map[x, y];
                    if (element.Value != null && element.Value.Equals(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
