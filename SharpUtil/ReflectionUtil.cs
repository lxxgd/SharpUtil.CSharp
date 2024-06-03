﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            FieldInfo? info = GetField(obj.GetType(),fieldName);
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
            FieldInfo? info = GetStaticField(type,fieldName);
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
            FieldInfo? info = GetField(obj.GetType(),fieldName);
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
            FieldInfo? info = GetStaticField(type,fieldName);
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
            MethodInfo info = GetMethod(obj.GetType(),methodName,parameters);
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
            MethodInfo info = GetStaticMethod(type,methodName,parameters);
            return info.Invoke(null, args);
        }
    }
}
