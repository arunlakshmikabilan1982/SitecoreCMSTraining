namespace Sitecore.Demo.Foundation.SitecoreExtensions.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Globalization;
    using Sitecore.Links;
    using Sitecore.Links.UrlBuilders;
    using Sitecore.Sites;

    public static class SiteExtensions
    {
        public static string GetCurrentHost()
        {
            return $"{HttpContext.Current.Request.Url?.Scheme}://{HttpContext.Current.Request.Url?.Host}/{Context.Language.Name}";
        }

        public static Item GetContextItem(this SiteContext site, ID derivedFromTemplateID)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            var startItem = site.GetStartItem();
            return startItem?.GetAncestorOrSelfOfTemplate(derivedFromTemplateID);
        }

        public static Item GetRootItem(this SiteContext site)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            return site.Database.GetItem(site.RootPath);
        }

        public static Item GetStartItem(this SiteContext site)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            return site.Database.GetItem(site.StartPath);
        }

        public static Item GetSettingsItem(this SiteContext site)
        {
            if (site == null)
            {
                throw new ArgumentNullException(nameof(site));
            }

            var defaultSettingsItem = site.GetRootItem().Children
                .FirstOrDefault(x => x.Name == "Settings");

            if (defaultSettingsItem == null)
            {
                Log.Error("Site settings not found", nameof(site));
                return null;
            }

            return defaultSettingsItem;
        }

        public static string GetURLByIDPage(this SiteContext site, ID derivedFromTemplateID)
        {
            var item = site.GetStartItem().Children
                .FirstOrDefault(x => x.TemplateID == derivedFromTemplateID);

            if (item == null)
            {
                Log.Error($"Page with {derivedFromTemplateID} ID isn't specified", nameof(site));
                //throw new ArgumentNullException(nameof(item));
                return string.Empty;
            }

            var urlOptions = new ItemUrlBuilderOptions
            {
                LanguageEmbedding = LanguageEmbedding.Always
            };

            return $"{HttpContext.Current.Request.Url?.Scheme}://{HttpContext.Current.Request.Url?.Host}{item.Url(urlOptions)}";
        }
        public static string GetErrorURLByErrorType(this SiteContext site, string errorType)
        {
            var item = Sitecore.Context.Database.GetItem("/sitecore/content/PAL/Home/Error Page/"+ errorType);

            if (item == null)
            {
                Log.Error($"Page with {errorType} type isn't specified", nameof(site));
                throw new ArgumentNullException(nameof(item));
            }

            var urlOptions = new ItemUrlBuilderOptions
            {
                LanguageEmbedding = LanguageEmbedding.Always
            };

            return $"{HttpContext.Current.Request.Url?.Scheme}://{HttpContext.Current.Request.Url?.Host}{item.Url(urlOptions)}";
        }
        public static Sitecore.Sites.SiteContext GetContextSite()
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor || Sitecore.Context.PageMode.IsPreview)
            {
                // item ID for page editor and front-end preview mode
                string id = Sitecore.Web.WebUtil.GetQueryString("sc_itemid");

                // by default, get the item assuming Presentation Preview tool (embedded preview in shell)
                var item = Sitecore.Context.Item;

                // if a query string ID was found, get the item for page editor and front-end preview mode
                if (!string.IsNullOrEmpty(id))
                {
                    item = Sitecore.Context.Database.GetItem(id);
                }

                // loop through all configured sites
                foreach (var site in Sitecore.Configuration.Factory.GetSiteInfoList())
                {
                    // get this site's home page item
                    var homePage = Sitecore.Context.Database.GetItem(site.RootPath + site.StartItem);

                    // if the item lives within this site, this is our context site
                    if (homePage != null && item != null && homePage.Axes.IsAncestorOf(item))
                    {
                        return Sitecore.Configuration.Factory.GetSite(site.Name);
                    }
                }

                // fallback and assume context site
                return Sitecore.Context.Site;
            }
            else
            {
                // standard context site resolution via hostname, virtual/physical path, and port number
                return Sitecore.Context.Site;
            }
        }
        public static string GetLinkUrlLanguageMenu(string languageName, string keyword)
        {
            string url = string.Empty;
            if (!string.IsNullOrEmpty(languageName))
            {
                Language languageObj;
                Language.TryParse(languageName, out languageObj);

                var options = new Sitecore.Links.UrlBuilders.ItemUrlBuilderOptions { LanguageEmbedding = Sitecore.Links.LanguageEmbedding.Never, Language = languageObj };
                var itm = Sitecore.Context.Database.GetItem(Sitecore.Context.Item.ID, languageObj);
                url = LinkManager.GetItemUrl(itm, options);
                if (!string.IsNullOrEmpty(keyword))
                {
                    url = url + keyword;
                }
            }
            return url.Replace(" ", "-");

        }
        public static string GetStringParamsUrl()
        {
            string parameters = string.Empty;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.Contains("?"))
            {
                parameters = url.Substring(url.IndexOf("?"));
            }
            return parameters;
        }
    }
}