using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sitecore.Demo.Foundation.SitecoreExtensions.Models.BaseItem
{
    [SitecoreType]
    public class BaseItemModel : IBaseItemModel
    {
        public virtual ID Id
        {
            get;
            set;
        }

        public virtual Language Language
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.DisplayName)]
        public virtual string DisplayName
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.FullPath)]
        public string FullPath
        {
            get;
            set;
        }

        [SitecoreChildren]
        public virtual IEnumerable<BaseItemModel> Children
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.Name)]
        public virtual string Name
        {
            get;
            set;
        }

        [SitecoreParent]
        public virtual BaseItemModel Parent
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        public virtual ID TemplateId
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        public virtual string TemplateName
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.Default)]
        public virtual string Url
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.SiteResolving)]
        public virtual string RelativeUrl
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.AlwaysIncludeServerUrl)]
        public virtual string AbsoluteUrl
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.Version)]
        public virtual int Version
        {
            get;
            set;
        }

        [SitecoreField("__Base template")]
        public virtual string BaseTemplateIds
        {
            get;
            set;
        }

        [SitecoreField("__Created")]
        public virtual DateTime CreatedDate
        {
            get;
            set;
        }

        public IList<string> BaseTemplates
        {
            get
            {
                List<string> list = new List<string>();
                bool flag = !string.IsNullOrWhiteSpace(this.BaseTemplateIds);
                IList<string> result;
                if (flag)
                {
                    result = this.BaseTemplateIds.Split(new char[]
                    {
                        '|'
                    }).ToList<string>();
                }
                else
                {
                    result = list;
                }
                return result;
            }
        }
    }
}