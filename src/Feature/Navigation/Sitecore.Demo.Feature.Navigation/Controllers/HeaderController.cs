
using Sitecore.Data.Fields;
using Sitecore.Demo.Feature.Navigation.Models;
using Sitecore.Mvc.Presentation;    
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sitecore.Demo.Feature.Navigation.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Header
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Header()
        {
            var item = new HeaderViewModel(RenderingContext.Current.Rendering.Item);
            return View(item);
        }
    }
}