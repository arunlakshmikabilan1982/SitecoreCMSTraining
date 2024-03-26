using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Feature.JobBoard
{
    public class SendEmail
    {

        public void Execute(Sitecore.Data.Items.Item[] items,Sitecore.Tasks.CommandItem commandItem,Sitecore.Tasks.ScheduleItem scheduleItem)
        {
            try
            {
                Log.Info("Email Scheduler is executed",this);
            }

            catch(Exception e)
            {
                Log.Error("Scheduler Exception :"+ e.InnerException.Message,this);
            }
        }
    }
}