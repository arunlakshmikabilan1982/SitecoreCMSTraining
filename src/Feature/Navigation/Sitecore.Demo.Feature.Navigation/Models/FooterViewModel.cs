using Sitecore.Data.Items;
using System;
using System.Collections.Generic;

using Sitecore.Demo.Foundation.SitecoreExtensions.Extensions;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;

namespace Sitecore.Demo.Feature.Navigation.Models
{
    public class FooterViewModel
    {
        public FooterViewModel(Item item)
        {
            if (!item.IsDerived(Templates.Footer.BaseTemplateID)) return;

            Logo = item.ImageUrl(Templates.Footer.Fields.Logo);
            Gmail = item.Fields[Templates.Footer.Fields.Gmail]?.Value;
            Phone = item.Fields[Templates.Footer.Fields.Phone]?.Value;
            Address = item.Fields[Templates.Footer.Fields.Address]?.Value;
            Companylabel = item.Fields[Templates.Footer.Fields.Company_label]?.Value;

            Companies = new List<FooterLink>();
            var CompaniesListItem = new MultilistField(item.Fields[Templates.Footer.Fields.Companies]).GetItems();
            foreach (var EachCompany in CompaniesListItem)
            {
                var Company = new FooterLink();
                Company.Footerlabel = EachCompany.Fields[Templates.FooterList.Fields.Footer_label].Value;
                Company.FooterUrl = EachCompany.Fields[Templates.FooterList.Fields.Footer_Link].Value;
                Companies.Add(Company);
            }

            Categorylabel = item.Fields[Templates.Footer.Fields.Category_label]?.Value;

            Categories = new List<FooterLink>();
            var CategoryListItem = new MultilistField(item.Fields[Templates.Footer.Fields.Categories]).GetItems();
            foreach (var EachCategory in CategoryListItem)
            {
                var Company = new FooterLink();
                Company.Footerlabel = EachCategory.Fields[Templates.FooterList.Fields.Footer_label].Value;
                Company.FooterUrl = EachCategory.Fields[Templates.FooterList.Fields.Footer_Link].Value;
                Categories.Add(Company);
            }

            Subscribelabel = item.Fields[Templates.Footer.Fields.Subscribe_label]?.Value;
            SubscribeUrl = item.Fields[Templates.Footer.Fields.Subscribe_Url]?.Value;
            SubscribeDescription = item.Fields[Templates.Footer.Fields.Subscribe_Description]?.Value;
            Copyrights_label = item.Fields[Templates.Footer.Fields.Copyrights_label]?.Value;
        }
        #region property
        public string Logo { get; set; }
        public string Gmail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Companylabel { get; set; }
        public List<FooterLink> Companies { get; set; }
        public string Categorylabel { get; set; }
        public List<FooterLink> Categories { get; set; }
        public string Subscribelabel { get; set; }
        public string SubscribeUrl { get; set; }
        public string SubscribeDescription { get; set; }
        public string Copyrights_label { get; set; }
        public Item item { get; set; }
        #endregion
    }
    public class FooterLink
    {
        public string Footerlabel { get; set; }
        public string FooterUrl { get; set; }
    }
}