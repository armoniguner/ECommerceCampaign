using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCampaign.API.Tasks
{
    public class CampaignPushJobScheduler
    {
        public static void Start()
        {
            ISchedulerFactory schFactory = new StdSchedulerFactory();
            IScheduler sch = schFactory.GetScheduler().GetAwaiter().GetResult();
            sch.Start();

            IJobDetail job = JobBuilder.Create<CampaignPushJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                //.StartNow()
                .StartAt(DateBuilder.DateOf(15,34,0))
                .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(60) //60*60 -every hour
                .RepeatForever())
                .Build();

            sch.ScheduleJob(job, trigger);
        }
    }
}
