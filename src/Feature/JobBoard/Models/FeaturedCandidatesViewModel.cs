using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Feature.JobBoard.Models
{
    public class FeaturedCandidatesViewModel
    {
        public string Title { get; set; }

        public List<Candidates> Candidates { get; set; }

    }

    public class Candidates
    {
        public string Image{get;set;}

        public string Name { get; set; }

        public string JobRole { get; set; }
    }
}