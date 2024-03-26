using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Feature.JobBoard
{
    public class Templates
    {

        public struct Alignment
        {
            public static readonly ID ID = new ID("{F142DE0F-5D1E-444D-890C-1E28070C7BB8}");
            public static readonly ID BaseTemplateID = new ID("{09612602-A8BC-4947-9C58-68EDE4C494A5}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{05EA1C4A-F10F-4D64-926F-BE01DC3D7597}");
                public static readonly ID Description = new ID("{753EEB9F-0B8A-4179-B268-0C86E79FA411}");
                public static readonly ID Image = new ID("{4D0728DF-B351-48E0-ACDA-7D6AFC1F94B9}");
            }
        }
    }
}