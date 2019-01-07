using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dbox_global.Utils
{
    public static class SimpleMapper
    {
        /// <summary>
        /// Mappes one property to another.
        /// </summary>
        /// <typeparam name="T">Source type</typeparam>
        /// <typeparam name="TU">Target type</typeparam>
        /// <param name="source">Source parameter</param>
        /// <param name="destination">Target parameter</param>
        public static void PropertyMap<T, TU>(T source, TU destination)
            where T : class, new()
            where TU : class, new()
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties().ToList();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);

                if (destinationProperty == null) continue;
                try
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                }
                catch (ArgumentException)
                {
                }
            }
        }
    }
}
