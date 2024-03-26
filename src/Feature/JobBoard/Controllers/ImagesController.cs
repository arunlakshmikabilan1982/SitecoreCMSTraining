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
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {


            ImageGalleryViewModel model = new ImageGalleryViewModel();

            var item = RenderingContext.Current.Rendering.Item;

            if (item != null && item.Fields != null)
            {
                //model.Title = item.Fields["Title"].Value;
                var ImageList = new MultilistField(item.Fields["Images"]).GetItems();
                var ImageItemList = new List<Images>();
                foreach (var img in ImageList)
                {
                    var ImageItem = new Images();


                    ImageField imgField = ((ImageField)img.Fields["Image"]);
                    ImageItem.Image = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);



                    ImageItemList.Add(ImageItem);

                }



                model.Images = ImageItemList;
            }

            return View(model);

        }
        }
    }
