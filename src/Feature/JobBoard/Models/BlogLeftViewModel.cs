using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Feature.JobBoard.Models
{
    public class BlogLeftViewModel
    {
        public List<Blogs> Blogs { get; set; }

    }

    public class Blogs { 
        public string Image { get; set;}

        public string Date { get; set;}

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public string Comments { get; set; }
    }
}