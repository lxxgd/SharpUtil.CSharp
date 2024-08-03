
namespace SharpUtil
{
    public interface IMap2D<T> : IEnumerable<T>
    {
        T? this[int x, int y] { get; set; }

        int Height { get; }
        int Width { get; }

        void Clear();
        Map2D<T> Clone();
        void CopyFrom(Map2D<T> other, bool resize = true);
        void CopyTo(Map2D<T> other, bool resize = true);
        void Exchange(int x1, int y1, int x2, int y2);
        void Fill(T value);
        Map2DElement<T> GetElement(int x, int y);
        void Resize(int width, int height);
    }
}