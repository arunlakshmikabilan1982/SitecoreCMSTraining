using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Feature.JobBoard.Models
{
    public class ImageGalleryViewModel
    {

        //public string Title
        //{
         //   get; set;
        //}

        public List<Images> Images
        {
            get;set;
        }
    }

    public class Images
    {
        public string Image
        {
            get;set;
        }
    }
}