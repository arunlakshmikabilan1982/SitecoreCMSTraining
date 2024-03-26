using Sitecore.Mvc.Presentation;
using Sitecore.Demo.Feature.JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Demo.Feature.JobBoard.Controllers
{
    public class HeroController : Controller
    {
        // GET: Hero
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeroBanner()
        {

            HeroViewModel model = new HeroViewModel();

            var item = RenderingContext.Current.Rendering.Item;

            if(item != null && item.Fields != null)
            {
                model.JobsListed = item.Fields["JobsListed"].Value;
                model.Title = item.Fields["Title"].Value;
                model.Description = item.Fields["Description"].Value;
                model.ButtonText = item.Fields["ButtonText"].Value;
               // model.Image = item.Fields["Image"].Value;
            }



            return View(model);
        }

    }
}