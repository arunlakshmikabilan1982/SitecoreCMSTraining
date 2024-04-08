using Sitecore.Demo.Feature.Navigation.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;

namespace Sitecore.Demo.Feature.Navigation.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Footer()
        {
            var model = new FooterViewModel(RenderingContext.Current.Rendering.Item);
            return View(model);
        }
    }
}