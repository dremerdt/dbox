using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace dbox_global.Utils
{
    public static class StringUtil
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Converts a string to <see cref="DateTime"/> with <paramref name="format"/>
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="format">Date format</param>
        /// <returns>Converted datetime</returns>
        public static DateTime ToDateTime(this string str, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentException("The format cannot be null or empty.");
            }

            return DateTime.ParseExact(str, format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Generate SHA512 hash string.
        /// </summary>
        /// <param name="str">A string</param>
        /// <returns>Generated hash</returns>
        public static string HashString(string str)
        {
            var cryptoServiceProvider = new SHA512CryptoServiceProvider();

            var cryptoString = Encoding.UTF8.GetBytes(str);

            var hash = cryptoServiceProvider.ComputeHash(cryptoString);

            var ret = "";
            foreach (var a in hash)
            {
                if (a < 16)
                    ret += "0" + a.ToString("x");
                else
                    ret += a.ToString("x");
            }

            return ret;
        }

        /// <summary>
        /// Generate SHA512 hash of bytes
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>Generated hash</returns>
        public static string HashBytes(byte[] bytes)
        {
            var md5 = new SHA512CryptoServiceProvider();
            var retVal = md5.ComputeHash(bytes);

            var sb = new StringBuilder();
            foreach (var t in retVal)
                sb.Append(t.ToString("x2"));

            return sb.ToString();
        }

        /// <summary>
        /// Generate a random string with configured length.
        /// </summary>
        /// <param name="length">Length of string</param>
        /// <returns>Generated string</returns>
        public static string GenerateString(int length)
        {
            var builder = new StringBuilder();

            while (builder.Length < length)
            {
                var next = Random.Next(0, 9);

                if (next % 3 == 0)
                {
                    var str = (char)Random.Next('A', 'Z');

                    if (str.ToString(CultureInfo.InvariantCulture).ToLower() == "i" ||
                        str.ToString(CultureInfo.InvariantCulture).ToLower() == "o" ||
                        str.ToString(CultureInfo.InvariantCulture).ToLower() == "l")
                        continue;

                    builder.Append(str);
                }

                else if (next % 2 == 0)
                {
                    var str = (char)Random.Next('a', 'z');

                    if (str.ToString(CultureInfo.InvariantCulture).ToLower() == "i" ||
                        str.ToString(CultureInfo.InvariantCulture).ToLower() == "o" ||
                        str.ToString(CultureInfo.InvariantCulture).ToLower() == "l")
                        continue;

                    builder.Append(str);
                }
                else
                    builder.Append((char)Random.Next('1', '9'));
            }

            return builder.ToString();
        }
    }
}
