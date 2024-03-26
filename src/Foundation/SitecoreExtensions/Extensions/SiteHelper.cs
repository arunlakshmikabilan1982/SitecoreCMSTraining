using Glass.Mapper.Sc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Foundation.SitecoreExtensions.Helpers
{
    public static class SiteHelper
    {
        /// <summary>
        /// Glass context item that used by glass to map item to entity
        /// </summary>
        public static SitecoreContext SitecoreGlassContext
        {
            get
            {
                return new SitecoreContext();
            }
        }

        /// <summary>
        /// get current Site Path
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentSitePath()
        {
            return Sitecore.Context.Site.ContentStartPath;
        }
    }
}