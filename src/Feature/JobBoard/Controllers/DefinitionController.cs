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
    public class DefinitionController : Controller
    {
        // GET: Definition
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Definition()
        {
            DefinitionViewModel model = new DefinitionViewModel();

            var item = RenderingContext.Current.Rendering.Item;

            if (item != null && item.Fields != null)
            {
                model.Title = item.Fields["Title"].Value;
                var DefinitionList = new MultilistField(item.Fields["Definitions"]).GetItems();
                var DefinitionItemList = new List<Definitions>();
                foreach (var cart in DefinitionList)
                {
                    var DefinitionItem = new Definitions();

                    DefinitionItem.Title = cart.Fields["Title"]?.Value;
                    DefinitionItem.Description = cart.Fields["Description"]?.Value;


                    DefinitionItemList.Add(DefinitionItem);

                }

                model.Definitions = DefinitionItemList;

            }

            return View(model);
        }
    }
}