using System;
using System.Collections.Generic;
using System.Text;

namespace dbox_global.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsNight(this DateTime date)
        {
            return date.Hour >= 0 && date.Hour < 8;
        }
    }
}
