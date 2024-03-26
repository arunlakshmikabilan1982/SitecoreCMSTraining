using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;

namespace Sitecore.Demo.Foundation.SitecoreExtensions.Models.BaseItem
{
    [SitecoreType]
    public interface IBaseItemModel
    {
        [SitecoreId]
        ID Id
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.DisplayName)]
        string DisplayName
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.FullPath)]
        string FullPath
        {
            get;
            set;
        }

        [SitecoreChildren]
        IEnumerable<BaseItemModel> Children
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.Name)]
        string Name
        {
            get;
            set;
        }

        [SitecoreParent]
        BaseItemModel Parent
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        ID TemplateId
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        string TemplateName
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.SiteResolving)]
        string Url
        {
            get;
            set;
        }

        [SitecoreInfo(SitecoreInfoType.Version)]
        int Version
        {
            get;
            set;
        }
    }
}