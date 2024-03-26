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
    public class AlignmentController : Controller
    {
        // GET: Alignment
        public ActionResult Index()
        {

            var items = new Alignment(RenderingContext.Current.Rendering.Item);


            return View(items);
        }

    }
}