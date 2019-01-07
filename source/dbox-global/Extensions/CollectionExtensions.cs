using System;
using System.Collections.Generic;
using System.Text;

namespace dbox_global.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Merges one two collections into one.
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="source">Source collection</param>
        /// <param name="collection">Merge collection</param>
        public static void Merge<T>(this ICollection<T> source, IEnumerable<T> collection)
        {
            Merge(source, collection, false);
        }

        /// <summary>
        /// Merges one two collections into one.
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="source">Source collection</param>
        /// <param name="collection">Merge collection</param>
        /// <param name="ignoreDuplicates"> Ignore duplicates flag</param>
        public static void Merge<T>(this ICollection<T> source, IEnumerable<T> collection, bool ignoreDuplicates)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    var addItem = true;

                    if (ignoreDuplicates)
                        addItem = !source.Contains(item);

                    if (addItem)
                        source.Add(item);
                }
            }
        }
    }
}
