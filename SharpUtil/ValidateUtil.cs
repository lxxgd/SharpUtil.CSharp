using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpUtil
{
    public static class ValidateUtil
    {
        public static bool NoNullElements<T>(T[] array)
        {
            RequireNonNull(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                    return false;
            }

            return true;
        }

        public static bool NoNullElements<T>(ICollection<T> enumerable)
        {
            RequireNonNull(enumerable);

            foreach (var item in enumerable)
            {
                if (item == null)
                    return false;
            }

            return true;
        }

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

        public static object RequireNonNull(object? obj, string? message)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
            return obj;
        }

        public static object RequireNonNull(object? obj)
        {
            if (obj == null) throw new NullReferenceException();
            return obj;
        }

        public static bool ValidIndex<T>(T[] array, int index)
        {
            RequireNonNull(array);

            if (index >= 0 && index < array.Length)
                return true;
            else
                return false;
        }

        public static T[] ValidIndexWithException<T>(T[] array, int index)
        {
            RequireNonNull(array);

            if (index >= 0 && index < array.Length)
                return array;
            else
                throw new IndexOutOfRangeException($"The validated array index is invalid: {index}");
        }

        public static bool ValidIndex<T>(ICollection<T> collection, int index)
        {
            RequireNonNull(collection);

            if (index >= 0 && index < collection.Count)
                return true;
            else
                return false;
        }

        public static ICollection<T> ValidIndexWithException<T>(ICollection<T> collection, int index)
        {
            RequireNonNull(collection);

            if (index >= 0 && index < collection.Count)
                return collection;
            else
                throw new IndexOutOfRangeException($"The validated collection index is invalid: {index}");
        }
    }
}
