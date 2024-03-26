using System;
using Glass.Mapper.Sc.Fields;

namespace Sitecore.Demo.Foundation.SitecoreExtensions.Extensions
{
    public static class GlassExtensionHelper
    {
        public static bool IsValid(this Image img)
        {
            return !string.IsNullOrEmpty(img?.Src);
        }

        public static bool IsValid(this Link lnk)
        {
            if (lnk == null) return false;
            return ((lnk.Type == LinkType.Internal || lnk.Type == LinkType.Media) && lnk.TargetId != Guid.NewGuid()) || !string.IsNullOrEmpty(lnk.Url);
        }
    }
}