namespace SharpUtil
{
    /// <summary>
    /// 验证数据的实用类
    /// </summary>
    public static class ValidateUtil
    {
        /// <summary>
        /// 验证数组是否包含Null值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">要验证的数组</param>
        /// <returns>是否包含Null值</returns>
        public static bool NoNullElements<T>(T[] array)
        {
            RequireNonNull(array);

            return array.All(t => t != null);
        }

        /// <summary>
        /// 验证集合是否包含Null值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">要验证的集合</param>
        /// <returns>是否包含Null值</returns>
        public static bool NoNullElements<T>(IEnumerable<T> enumerable)
        {
            RequireNonNull(enumerable);

            return enumerable.All(item => item != null);
        }

        /// <summary>
        /// 验证数组是否包含Null值，如果包含，则抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">要验证的数组</param>
        /// <returns>原数组</returns>
        /// <exception cref="ArgumentException"></exception>
        public static T[] NoNullElementsWithException<T>(T[] array)
        {
            RequireNonNull(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                    throw new ArgumentException($"The array contains null elements at index: {i}");
            }

            return array;
        }

        /// <summary>
        /// 验证集合是否包含Null值，如果包含，则抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">要验证的集合</param>
        /// <returns>原集合</returns>
        /// <exception cref="ArgumentException"></exception>
        public static IEnumerable<T> NoNullElementsWithException<T>(IEnumerable<T> enumerable)
        {
            RequireNonNull(enumerable);

            int index = 0;

            foreach (var item in enumerable)
            {
                if (item == null)
                    throw new ArgumentException($"The validated collection contains null element at index: {index}");
                index++;
            }

            return enumerable;
        }

        /// <summary>
        /// 验证对象是否为Null，如果为Null，则抛出异常
        /// </summary>
        /// <param name="obj">
        /// 要验证的对象
        /// </param>
        /// <param name="message">
        /// 异常信息
        /// </param>
        /// <returns>原对象</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static object RequireNonNull(object? obj, string? message)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
            return obj;
        }

        /// <summary>
        /// 验证对象是否为Null，如果为Null，则抛出异常
        /// </summary>
        /// <param name="obj">
        /// 要验证的对象
        /// </param>
        /// <returns>原对象</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static object RequireNonNull(object? obj)
        {
            if (obj == null) throw new NullReferenceException();
            return obj;
        }

        /// <summary>
        /// 验证指定下标是否在数组的范围内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">要验证的数组</param>
        /// <param name="index">要验证的下标</param>
        /// <returns>是否在范围内</returns>
        public static bool ValidIndex<T>(T[] array, int index)
        {
            RequireNonNull(array);

            return index >= 0 && index < array.Length;
        }

        /// <summary>
        /// 验证指定下标是否在数组的范围内，如果不在，则抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">要验证的数组</param>
        /// <param name="index">要验证的下标</param>
        /// <returns>原数组</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static T[] ValidIndexWithException<T>(T[] array, int index)
        {
            RequireNonNull(array);

            if (index >= 0 && index < array.Length)
                return array;
            throw new IndexOutOfRangeException($"The validated array index is invalid: {index}");
        }

        /// <summary>
        /// 验证指定下标是否在集合的范围内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">要验证的集合</param>
        /// <param name="index">要验证的下标</param>
        /// <returns>是否在范围内</returns>
        public static bool ValidIndex<T>(ICollection<T> collection, int index)
        {
            RequireNonNull(collection);

            return index >= 0 && index < collection.Count;
        }

        /// <summary>
        /// 验证指定下标是否在集合的范围内，如果不在，则抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">要验证的集合</param>
        /// <param name="index">要验证的下标</param>
        /// <returns>原集合</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static ICollection<T> ValidIndexWithException<T>(ICollection<T> collection, int index)
        {
            RequireNonNull(collection);

            if (index >= 0 && index < collection.Count)
                return collection;
            throw new IndexOutOfRangeException($"The validated collection index is invalid: {index}");
        }

        public static bool ValidIndex<T>(this Map2D<T> map,int x,int y)
        {
            return x >= 0 && x < map.Width && y >= 0 && y < map.Height;
        }
        
        public static Map2D<T> ValidIndexWithException<T>(this Map2D<T> map, int x, int y)
        {
            if (x >= 0 && x < map.Width && y >= 0 && y < map.Height)
            {
                return map;
            }

            throw new IndexOutOfRangeException($"The validated map index is invalid: ({x},{y})");
        }

        public static bool IsValid(this float x)
        {
            if (float.IsNaN(x))
            {
                // NaN.
                return false;
            }

            return !float.IsInfinity(x);
        }

        public static bool IsValid(this double x)
        {
            if (double.IsNaN(x))
            {
                // NaN.
                return false;
            }

            return !double.IsInfinity(x);
        }
    }
}
