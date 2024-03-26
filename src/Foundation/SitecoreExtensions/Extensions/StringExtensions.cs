namespace Sitecore.Demo.Foundation.SitecoreExtensions.Extensions
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string Humanize(this string input)
        {
            return Regex.Replace(input, "(\\B[A-Z])", " $1");
        }

        public static string ToCssUrlValue(this string url)
        {
            return string.IsNullOrWhiteSpace(url) ? "none" : $"url('{url}')";
        }

        public static string ConvertIpAddress(this string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
            {
                return string.Empty;
            }
            var ip = ipAddress.Split(',')[0];
            if (ip.Contains("."))
            {
                return ip.Split(':')[0];
            }
            return ip;
        }
    }
}