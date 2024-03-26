using Glass.Mapper.Sc;
using Sitecore.Demo.Foundation.SitecoreExtensions.Models.BaseItem;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Foundation.SitecoreExtensions.Extensions
{
    /// <summary>
    /// Define some basic propreties and all repositories should be inherited from this
    /// </summary>>
    public class BaseRepository
    {
        [Obsolete]
        protected SitecoreContext SitecoreContext
        {
            get
            {
                return new SitecoreContext();
            }
        }

        protected SitecoreService SitecoreService
        {
            get
            {
                return new SitecoreService(Sitecore.Context.Database);
            }
        }

        protected ISearchIndex SearchIndex
        {
            get
            {
                return ContentSearchManager.GetIndex(Sitecore.Context.Site.Name.ToLower() + "_" + Sitecore.Context.Database.Name + "_index");
            }
        }
        protected ISearchIndex SitecoreSearchIndex
        {
            get
            {
                return ContentSearchManager.GetIndex(Sitecore.Context.Site.Name.ToLower() + "_" + Sitecore.Context.Database.Name + "_index");
            }
        }

        [Obsolete]
        public string ItemUrl(ID templateID)
        {
            var resultUrl = "";
            using (var context = SitecoreSearchIndex.CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<SearchResultItem>();
                var culture = Sitecore.Context.Language.CultureInfo;
                predicate = predicate.And(p => p.Language == culture.Name);
                predicate = predicate.And(p => p.TemplateId == templateID);
                predicate = predicate.And(p => p.Paths.Contains(Sitecore.Context.Site.GetStartItem().ID));
                var result = context.GetQueryable<SearchResultItem>().Where(predicate).FirstOrDefault();
                if (result != null)
                {
                    var obj = SitecoreContext.Cast<BaseItemModel>(result.GetItem());
                    resultUrl = obj.Url;
                }
            }
            return resultUrl;
        }
    }
}