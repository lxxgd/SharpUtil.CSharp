using System.Collections;

namespace SharpUtil
{
    /// <summary>
    /// 非空列表，不会包含Null元素，具有默认值
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class NonNullList<E> : IList<E>
    {
        public List<E> list;
        public E defaultValue;

        /// <param name="size">列表大小</param>
        /// <param name="defaultValue">元素默认值</param>
        public NonNullList(int size, E defaultValue)
        {
            ValidateUtil.RequireNonNull(defaultValue);
            E[] e = new E[size];
            Array.Fill(e, defaultValue);
            List<E> list = new(e);
            this.list = list;
            this.defaultValue = defaultValue;
        }

        /// <param name="defaultValue">元素默认值</param>
        /// <param name="e">用来填充的数组</param>
        public NonNullList(E defaultValue, params E[] e)
        {
            ValidateUtil.RequireNonNull(defaultValue);
            ValidateUtil.NoNullElementsWithException(e);
            this.list = new List<E>(e);
            this.defaultValue = defaultValue;

        }

        public E this[int index]
        {
            get => ((IList<E>)list)[index];
            set
            {
                ValidateUtil.RequireNonNull(value);
                list[index] = value;
            }
        }

        public int Count => ((ICollection<E>)list).Count;

        public bool IsReadOnly => ((ICollection<E>)list).IsReadOnly;

        public void Add(E item)
        {
            ValidateUtil.RequireNonNull(item);
            list.Add(item);
        }

        public void Clear()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = defaultValue;
            }
        }

        public bool Contains(E item)
        {
            return ((ICollection<E>)list).Contains(item);
        }

        public void CopyTo(E[] array, int arrayIndex)
        {
            ((ICollection<E>)list).CopyTo(array, arrayIndex);
        }

        public IEnumerator<E> GetEnumerator()
        {
            return ((IEnumerable<E>)list).GetEnumerator();
        }

        public int IndexOf(E item)
        {
            return ((IList<E>)list).IndexOf(item);
        }

        public void Insert(int index, E item)
        {
            ((IList<E>)list).Insert(index, item);
        }

        public bool Remove(E item)
        {
            return ((ICollection<E>)list).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<E>)list).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }
    }
}
