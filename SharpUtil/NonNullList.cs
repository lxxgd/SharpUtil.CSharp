using System.Collections;

namespace SharpUtil
{
    /// <summary>
    /// 非空列表，不会包含Null元素，具有默认值
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class NonNullList<E> : IList<E>, IList, IReadOnlyList<E>
    {
        private readonly List<E> list;
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
            list = new(e);
            this.defaultValue = defaultValue;

        }

        public E this[int index]
        {
            get => ((IList<E>)list)[index];
            set => list[index] = value ?? defaultValue;
        }

        object? IList.this[int index] 
        {
            get => ((IList)list)[index];
            set => ((IList)list)[index] = value ?? defaultValue;
        }

        public int Count => ((ICollection<E>)list).Count;

        public bool IsReadOnly => ((ICollection<E>)list).IsReadOnly;

        public bool IsFixedSize => ((IList)list).IsFixedSize;

        public bool IsSynchronized => ((ICollection)list).IsSynchronized;

        public object SyncRoot => ((ICollection)list).SyncRoot;

        public void Add(E item)
        {
            ValidateUtil.RequireNonNull(item);
            list.Add(item);
        }

        public int Add(object? value)
        {
            ValidateUtil.RequireNonNull(value);
            return ((IList)list).Add(value);
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

        public bool Contains(object? value)
        {
            return ((IList)list).Contains(value);
        }

        public void CopyTo(E[] array, int arrayIndex)
        {
            ((ICollection<E>)list).CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)list).CopyTo(array, index);
        }

        public IEnumerator<E> GetEnumerator()
        {
            return ((IEnumerable<E>)list).GetEnumerator();
        }

        public int IndexOf(E item)
        {
            return ((IList<E>)list).IndexOf(item);
        }

        public int IndexOf(object? value)
        {
            return ((IList)list).IndexOf(value);
        }

        public void Insert(int index, E item)
        {
            ((IList<E>)list).Insert(index, item ?? defaultValue);
        }

        public void Insert(int index, object? value)
        {
            ((IList)list).Insert(index, value ?? defaultValue);
        }

        public bool Remove(E item)
        {
            return ((ICollection<E>)list).Remove(item);
        }

        public void Remove(object? value)
        {
            ((IList)list).Remove(value);
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
