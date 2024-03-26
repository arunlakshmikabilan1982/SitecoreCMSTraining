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
    public class FeaturedCandidatesController : Controller
    {
        // GET: FeaturedCandidates
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Candidates()
        {

            FeaturedCandidatesViewModel model = new FeaturedCandidatesViewModel();

            var item = RenderingContext.Current.Rendering.Item;

            if (item != null && item.Fields != null)
            {
                model.Title = item.Fields["Title"].Value;

                var CandidatesList = new MultilistField(item.Fields["Candidates"]).GetItems();

                var CandidatesItemList = new List<Candidates>();

                foreach (var Candidates in CandidatesList)
                {
                    var CandidatesItem = new Candidates();

                    CandidatesItem.Image = "~/JobBoard/img/candiateds/1.png";

                    ImageField imgField = ((ImageField)Candidates.Fields["Image"]);
                    CandidatesItem.Image = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);

                    CandidatesItem.Name = Candidates.Fields["Name"].Value;
                    CandidatesItem.JobRole = Candidates.Fields["JobRole"].Value;

                    CandidatesItemList.Add(CandidatesItem);
                }

                model.Candidates = CandidatesItemList;

            }

            return View(model);
        }
    }
}