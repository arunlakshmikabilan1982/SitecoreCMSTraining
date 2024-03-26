using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Foundation.SitecoreExtensions.Helpers
{
    public static class ParseHelper
    {
        public static bool ParseBoolValue(this string value)
        {
            var parsedValue = true;
            bool.TryParse(value, out parsedValue);
            return parsedValue;
        }

        public static DateTimeOffset ParseDateTimeOffsetValue(this string value)
        {
            DateTimeOffset parsedValue;
            DateTimeOffset.TryParse(value, out parsedValue);
            return parsedValue;
        }

        public static double ParseDoubleValue(this string value)
        {
            Double parsedValue;
            Double.TryParse(value, out parsedValue);
            return parsedValue;
        }

        public static int ParseIntValue(this string value)
        {
            int parsedValue;
            int.TryParse(value, out parsedValue);
            return parsedValue;
        }

        public static DateTime ParseDateTimeSitcore(this string value)
        {
            DateTime parsedValue;
            parsedValue = Sitecore.DateUtil.IsoDateToDateTime(value, DateTime.Now, true);
            return parsedValue;
        }
    }
}