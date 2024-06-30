using System.Reflection;

namespace SharpUtil
{

    /// <summary>
    /// 用于反射操作的实用类
    /// </summary>
    public static class ReflectionUtil
    {
        /// <summary>
        /// 获取指定字段
        /// </summary>
        /// <param name="type">
        /// 字段所属类型
        /// </param>
        /// <param name="fieldName">
        /// 字段的名称
        /// </param>
        /// <returns>
        /// 所指的字段的<see cref="FieldInfo"/>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static FieldInfo GetField(Type type, string fieldName)
        {
            ValidateUtil.RequireNonNull(type);
            return type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                ?? throw new ArgumentException($"The specified field was not found : {fieldName}");
        }

        /// <summary>
        /// 获取指定字段，适用于静态类
        /// </summary>
        /// <param name="type">
        /// 字段所属类型
        /// </param>
        /// <param name="fieldName">
        /// 字段的名称
        /// </param>
        /// <returns>
        /// 所指的字段的<see cref="FieldInfo"/>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static FieldInfo GetStaticField(Type type, string fieldName)
        {
            ValidateUtil.RequireNonNull(type);
            return type.GetField(fieldName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                ?? throw new ArgumentException($"The specified field was not found : {fieldName}");
        }

        /// <summary>
        /// 获取指定字段的值
        /// </summary>
        /// <param name="obj">
        /// 字段所属的实例
        /// </param>
        /// <param name="fieldName">
        /// 字段名称
        /// </param>
        /// <returns>
        /// 字段的值
        /// </returns>
        public static object? GetFieldValue(this object obj, string fieldName)
        {
            ValidateUtil.RequireNonNull(obj);
            FieldInfo? info = GetField(obj.GetType(), fieldName);
            return info.GetValue(obj);
        }

        /// <summary>
        /// 获取指定字段的值，适用于静态类
        /// </summary>
        /// <param name="fieldName">
        /// 字段名称
        /// </param>
        /// <returns>
        /// 字段的值
        /// </returns>
        public static object? GetStaticFieldValue(this Type type, string fieldName)
        {
            ValidateUtil.RequireNonNull(type);
            FieldInfo? info = GetStaticField(type, fieldName);
            return info.GetValue(null);
        }

        /// <summary>
        /// 设置字段的值
        /// </summary>
        /// <param name="obj">
        /// 字段所属实例
        /// </param>
        /// <param name="fieldName">
        /// 字段名称
        /// </param>
        /// <param name="value">
        /// 字段的值
        /// </param>
        public static void SetFieldValue(this object obj, string fieldName, object? value)
        {
            ValidateUtil.RequireNonNull(obj);
            FieldInfo? info = GetField(obj.GetType(), fieldName);
            info.SetValue(obj, value);
        }

        /// <summary>
        /// 设置字段的值，适用于静态类
        /// </summary>
        /// <param name="fieldName">
        /// 字段名称
        /// </param>
        /// <param name="value">
        /// 字段的值
        /// </param>
        public static void SetStaticFieldValue(this Type type, string fieldName, object? value)
        {
            ValidateUtil.RequireNonNull(type);
            FieldInfo? info = GetStaticField(type, fieldName);
            info.SetValue(null, value);
        }

        /// <summary>
        /// 获取指定方法
        /// </summary>
        /// <param name="type">
        /// 方法所属类型
        /// </param>
        /// <param name="methodName">
        /// 方法名称
        /// </param>
        /// <param name="parameters">
        /// 方法的参数类型，按顺序排列
        /// </param>
        /// <returns>
        /// 所指定方法的<see cref="MethodInfo"/>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static MethodInfo GetMethod(Type type, string methodName, Type[] parameters)
        {
            ValidateUtil.RequireNonNull(type);
            return type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, parameters)
                ?? throw new ArgumentException($"The specified method was not found : {methodName}");
        }

        /// <summary>
        /// 获取指定方法，适用于静态类
        /// </summary>
        /// <param name="type">
        /// 方法所属类型
        /// </param>
        /// <param name="methodName">
        /// 方法名称
        /// </param>
        /// <param name="parameters">
        /// 方法的参数类型，按顺序排列
        /// </param>
        /// <returns>
        /// 所指定方法的<see cref="MethodInfo"/>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static MethodInfo GetStaticMethod(Type type, string methodName, Type[] parameters)
        {
            ValidateUtil.RequireNonNull(type);
            return type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public, parameters)
                ?? throw new ArgumentException($"The specified method was not found : {methodName}");
        }

        /// <summary>
        /// 调用指定方法
        /// </summary>
        /// <param name="obj">
        /// 方法所属实例
        /// </param>
        /// <param name="methodName">
        /// 方法名称
        /// </param>
        /// <param name="parameters">
        /// 方法的参数类型，按顺序排列
        /// </param>
        /// <param name="args">
        /// 方法的参数
        /// </param>
        /// <returns>方法的返回值</returns>
        public static object? InvokeMethod(this object obj, string methodName, Type[] parameters, params object[] args)
        {
            ValidateUtil.RequireNonNull(obj);
            MethodInfo info = GetMethod(obj.GetType(), methodName, parameters);
            return info.Invoke(obj, args);
        }

        /// <summary>
        /// 调用指定方法，适用于静态类
        /// </summary>
        /// <param name="methodName">
        /// 方法名称
        /// </param>
        /// <param name="parameters">
        /// 方法的参数类型，按顺序排列
        /// </param>
        /// <param name="args">
        /// 方法的参数
        /// </param>
        /// <returns>方法的返回值</returns>
        public static object? InvokeStaticMethod(this Type type, string methodName, Type[] parameters, params object[] args)
        {
            ValidateUtil.RequireNonNull(type);
            MethodInfo info = GetStaticMethod(type, methodName, parameters);
            return info.Invoke(null, args);
        }

        public static bool TryGetAttributes<T>(this MemberInfo memberInfo, out IEnumerable<T>? attribute) where T : Attribute
        {
            IEnumerable<T>? a = memberInfo.GetCustomAttributes<T>();
            attribute = a;
            if (a == null)
                return false;
            return true;
        }

        public static bool TryGetAttributes<T>(this Assembly assembly, out IEnumerable<T>? attribute) where T : Attribute
        {
            IEnumerable<T>? a = assembly.GetCustomAttributes<T>();
            attribute = a;
            if (a == null)
                return false;
            return true;
        }

        public static bool TryGetAttributes<T>(this Module module, out IEnumerable<T>? attribute) where T : Attribute
        {
            IEnumerable<T>? a = module.GetCustomAttributes<T>();
            attribute = a;
            if (a == null)
                return false;
            return true;
        }

        public static bool TryGetAttributes<T>(this ParameterInfo parameterInfo, out IEnumerable<T>? attribute) where T : Attribute
        {
            IEnumerable<T>? a = parameterInfo.GetCustomAttributes<T>();
            attribute = a;
            if (a == null)
                return false;
            return true;
        }

        public static bool TryGetAttribute<T>(this MemberInfo memberInfo, out T? attribute) where T : Attribute
        {
            T? a = memberInfo.GetCustomAttribute<T>();
            attribute = a;
            if (a == null)
                return false;
            return true;
        }

        public static bool TryGetAttribute<T>(this Module module, out T? attribute) where T : Attribute
        {
            T? a = module.GetCustomAttribute<T>();
            attribute = a;
            if (a == null)
                return false;
            return true;
        }
        public static bool TryGetAttribute<T>(this Assembly assembly, out T? attribute) where T : Attribute
        {
            T? a = assembly.GetCustomAttribute<T>();
            attribute = a;
            if (a == null)
                return false;
            return true;
        }
        public static bool TryGetAttribute<T>(this ParameterInfo parameterInfo, out T? attribute) where T : Attribute
        {
            T? a = parameterInfo.GetCustomAttribute<T>();
            attribute = a;
            if (a == null)
                return false;
            return true;
        }

        public static PropertyInfo GetProperty(this Type type, string propertyName)
        {
            ValidateUtil.RequireNonNull(type);
            return type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                ?? throw new ArgumentException($"The specified property was not found : {propertyName}");
        }

        public static PropertyInfo GetStaticProperty(this Type type, string propertyName)
        {
            ValidateUtil.RequireNonNull(type);
            return type.GetProperty(propertyName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                ?? throw new ArgumentException($"The specified property was not found : {propertyName}");
        }

        public static object? GetPropertyValue(this object obj, string propertyName)
        {
            ValidateUtil.RequireNonNull(obj);
            PropertyInfo? info = GetProperty(obj.GetType(), propertyName);
            return info.GetValue(obj);
        }

        public static object? GetStaticPropertyValue(this Type type, string propertyName)
        {
            ValidateUtil.RequireNonNull(type);
            PropertyInfo? info = GetStaticProperty(type, propertyName);
            return info.GetValue(null);
        }

        public static void SetPropertyValue(this object obj, string propertyName, object? value)
        {
            ValidateUtil.RequireNonNull(obj);
            PropertyInfo? info = GetProperty(obj.GetType(), propertyName);
            info.SetValue(obj, value);
        }

        public static void SetStaticPropertyValue(this Type type, string propertyName, object? value)
        {
            ValidateUtil.RequireNonNull(type);
            PropertyInfo? info = GetStaticProperty(type, propertyName);
            info.SetValue(null, value);
        }
    }
}
