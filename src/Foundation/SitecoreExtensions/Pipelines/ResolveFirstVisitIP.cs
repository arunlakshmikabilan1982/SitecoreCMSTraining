using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Pipelines.CreateVisits;
using Sitecore.Configuration;

namespace Sitecore.Demo.Foundation.SitecoreExtensions.Pipelines
{
    public class ResolveFirstVisitIP : CreateVisitProcessor
    {

        public override void Process(CreateVisitArgs args)
        {

            int intSetting = Settings.GetIntSetting("Analytics.PerformLookup.CreateVisitInterval", 5); // retrieve the delay value from the setting.
            args.Interaction.UpdateGeoIpData(TimeSpan.FromSeconds((double)intSetting)); // wait for the time specified in the Analytics.PerformLookup.CreateVisitInterval setting.

        }
    }
}