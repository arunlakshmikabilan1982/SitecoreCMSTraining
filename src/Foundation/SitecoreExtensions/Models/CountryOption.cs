namespace Sitecore.Demo.Foundation.SitecoreExtensions.Models
{
    using System.Web.Mvc;

    public class CountryOption: SelectListItem
    {
        public string FlagImagePath { get; set;}
        public string CountryPhone { get; set; }
    }
}