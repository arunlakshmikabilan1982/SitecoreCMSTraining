using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Demo.Feature.JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Demo.Feature.JobBoard.Controllers
{
    public class BlogLeftController : Controller
    {
        // GET: BlogLeft
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blogs()
        {

            BlogLeftViewModel model = new BlogLeftViewModel();

            var item = RenderingContext.Current.Rendering.Item;
            
            if(item != null && item.Fields != null)
            {
                var BlogItemList = new List<Blogs>(); 
                var BlogList = new MultilistField(item.Fields["Blogs"]).GetItems(); 

                foreach(var Blog in BlogList)
                {
                    var BlogItem = new Blogs();

                    ImageField imgField = ((ImageField)Blog.Fields["Image"]);
                    BlogItem.Image = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);

                    BlogItem.Title = Blog.Fields["Title"].Value;
                    BlogItem.Description = Blog.Fields["Description"].Value;

                    DateField dateField = Blog.Fields["Date"];
                    BlogItem.Date = dateField.DateTime.ToString("yyyy-MM-dd");
                    BlogItem.Tags = Blog.Fields["Tags"].Value;
                    BlogItem.Comments = Blog.Fields["Comments"].Value;

                    BlogItemList.Add(BlogItem);
                }

                model.Blogs = BlogItemList;


            }

            return View(model);
        }
    }
}