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
    public class JobListingController : Controller
    {
        // GET: JobListing
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Jobs()
        {

            JobListingViewModel model = new JobListingViewModel();

            var item = RenderingContext.Current.Rendering.Item;

            if(item != null && item.Fields != null)
            {
                model.Title = item.Fields["Title"].Value;
                model.ButtonText = item.Fields["Button"].Value;

                var JobList = new MultilistField(item.Fields["JobItems"]).GetItems();

                var JobItemList = new List<JobItems>();
                
                foreach(var Job in JobList)
                {
                    var JobItem = new JobItems();

//                    JobItem.Image = "~/JobBoard/img/svg_icon/1.svg";
                    JobItem.Name = Job.Fields["Name"].Value;
                    JobItem.Location = Job.Fields["Location"].Value;
                    JobItem.JobType = Job.Fields["JobType"].Value;
                    JobItem.ApplyNow = Job.Fields["ApplyNow"].Value;
                    DateField dateField = Job.Fields["DateLine"];
                    JobItem.DateLine = dateField.DateTime.ToString("yyyy-MM-dd");


                    JobItemList.Add(JobItem);
                }

                model.JobItems = JobItemList;
                
            }

            return View(model);
        }
    }
}