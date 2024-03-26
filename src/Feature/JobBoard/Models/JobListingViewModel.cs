using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Feature.JobBoard.Models
{
    public class JobListingViewModel
    {

        public string Title { get; set; }

        public string ButtonText { get; set; }

        public List<JobItems> JobItems { get; set; }

    }

    public class JobItems
    {
        public string Image { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string JobType { get; set; }

        public string ApplyNow { get; set; }

        public string DateLine { get; set; }
    }
}