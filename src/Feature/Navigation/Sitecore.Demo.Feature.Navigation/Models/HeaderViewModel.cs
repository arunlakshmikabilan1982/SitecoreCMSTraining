using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Demo.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Fields;

namespace Sitecore.Demo.Feature.Navigation.Models
{
    public class HeaderViewModel
    {
        public HeaderViewModel(Item item)
        {
            if (!item.IsDerived(Templates.Header.BaseTemplateID)) return;

            Logo = item.ImageUrl(Templates.Header.Fields.Logo);
            NavItems = new List<NavItems>();
            var navitems = new MultilistField(item.Fields[Templates.Header.Fields.NavItems]).GetItems();

            foreach (var navItem in navitems)
            {
                var navigation = new NavItems();
                navigation.NavItem_Text = navItem.Fields[Templates.NavItems.Fields.Nav_Item_label]?.Value;
                navigation.NavItem_Url = navItem.Fields[Templates.NavItems.Fields.Nav_Item_Url]?.Value;
                NavItems.Add(navigation);
            }
            Login_label = item.Fields[Templates.Header.Fields.Login_label]?.Value;
            Login_url = item.Fields[Templates.Header.Fields.Login_Url]?.Value;
            Post_Job_label = item.Fields[Templates.Header.Fields.Post_Job_label]?.Value;
            Post_Job_Url = item.Fields[Templates.Header.Fields.Post_Job_Url]?.Value;
            Item = item;
        }
        #region property
        public string Logo { get; set; }
        public List<NavItems> NavItems { get; set; }
        public string Login_label { get; set; }
        public string Login_url { get; set; }
        public string Post_Job_label { get; set; }
        public string Post_Job_Url { get; set; }
        public Item Item { get; set; }
        #endregion
    }
    public class NavItems
    {
        public string NavItem_Text { get; set; }
        public string NavItem_Url { get; set; }
        public bool hasChildren { get; set; }
    }
}