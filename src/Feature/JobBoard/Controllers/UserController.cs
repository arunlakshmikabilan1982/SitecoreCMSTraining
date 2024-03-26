using Sitecore.Mvc.Presentation;
using Sitecore.Demo.Feature.JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Demo.Feature.JobBoard.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile()
        {

            UserViewModel model = new UserViewModel();

            var item = RenderingContext.Current.Rendering.Item;

            if(item != null && item.Fields != null)
            {
                model.Name = item.Fields["Name"]?.Value;
                model.PhoneNo = item.Fields["PhoneNo"]?.Value;
                model.Email = item.Fields["Email"]?.Value;
                model.Address = item.Fields["Address"]?.Value;
            }
            return View(model);
        }
    }
}