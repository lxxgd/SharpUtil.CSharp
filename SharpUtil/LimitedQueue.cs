namespace SharpUtil
{
    /// <summary>
    /// 一个有限长度的队列
    /// </summary>
    /// <typeparam name="T">
    /// 队列元素的类型
    /// </typeparam>
    public class LimitedQueue<T> : Queue<T>
    {
        public int Limit { get; set; }

        public LimitedQueue(int limit) : base(limit)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(limit);
            Limit = limit;
        }

        public LimitedQueue(int limit, IEnumerable<T> collection) : base(collection)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(limit);
            Limit = limit;
        }

        public LimitedQueue(int limit,Queue<T> queue) : base(queue)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(limit);
            Limit = limit; 
        }

        public new void Enqueue(T item)
        {

            base.Enqueue(item);
            if (Count > Limit)
            {
                Dequeue();
            }
        }
    }
}
