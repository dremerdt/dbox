using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace dbox_global.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Changes an object type to target one.
        /// </summary>
        /// <param name="o">An object</param>
        /// <param name="type">A target type</param>
        /// <returns></returns>
        public static object ChangeType(this object o, Type type) =>
            o == null || type.IsValueType || o is IConvertible 
                ? Convert.ChangeType(o, type, null) 
                : o;

        /// <summary>
        /// Cast an object to type.
        /// </summary>
        /// <typeparam name="T">A target type</typeparam>
        /// <param name="o">An object</param>
        /// <returns></returns>
        public static T To<T>(this object o) => (T)ChangeType(o, typeof(T));

        /// <summary>
        /// Cast an object to type and out the cast object.
        /// </summary>
        /// <typeparam name="T">A target type</typeparam>
        /// <param name="o">An object</param>
        /// <param name="x">Out object</param>
        /// <returns></returns>
        public static T To<T>(this object o, out T x) => x = (T)ChangeType(o, typeof(T));
    }
}
