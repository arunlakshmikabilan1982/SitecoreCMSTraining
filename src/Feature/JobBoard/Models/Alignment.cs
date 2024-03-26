using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Demo.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Demo.Feature.JobBoard.Models
{
    public class Alignment
    {
        public Alignment(Item item)
        {
            if (!item.IsDerived(Templates.Alignment.BaseTemplateID)) return;

            Title = item.Fields[Templates.Alignment.Fields.Title]?.Value;
            Description = item.Fields[Templates.Alignment.Fields.Description]?.Value;
            Image = item.ImageUrl(Templates.Alignment.Fields.Image);

            Item = item;
        }

        #region property
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Item Item { get; set; }

        #endregion

    }

}