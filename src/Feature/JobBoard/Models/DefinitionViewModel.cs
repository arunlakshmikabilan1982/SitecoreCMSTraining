using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Feature.JobBoard.Models
{
    public class DefinitionViewModel
    {
        public string Title { get; set; }
        public List<Definitions> Definitions { get; set; }
    }

    public class Definitions
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }

}