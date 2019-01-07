using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dbox_global.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Gets value of <see cref="DescriptionAttribute"/> of property.
        /// </summary>
        /// <typeparam name="T">Template <see cref="Enum"/> type</typeparam>
        /// <param name="enumVal">A Value</param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(this T enumVal)
            where T : struct
        {
            var type = enumVal.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumVal));
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            var memberInfo = type.GetMember(enumVal.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumVal.ToString();
        }

        /// <summary>
        /// Converts a camel case string into sentence.
        /// </summary>
        /// <param name="str">A string</param>
        /// <returns>The sentence</returns>
        public static string CamelCaseToSentence(this string str)
        {
            return Regex.Replace(str, @"(?=\p{Lu}\p{Ll})|(?<=\p{Ll})(?=\p{Lu})", " ");
        }

        /// <summary>
        /// Makes first char to upper case. Throws an Exception
        /// </summary>
        /// <param name="input">A string</param>
        /// <returns>A result string</returns>
        public static string UppercaseFirsChar(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
