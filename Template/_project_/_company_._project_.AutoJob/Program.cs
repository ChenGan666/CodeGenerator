using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace _company_._project_.AutoJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Time Job Start");
            RunProgram().GetAwaiter().GetResult();
            Console.Read();
        }

        private static async Task RunProgram()
        {
            try
            {
                // Grab the Scheduler instance from the Factory  
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                var factory = new StdSchedulerFactory(props);
                var scheduler = await factory.GetScheduler();


                // 启动任务调度器  
                await scheduler.Start();


                // 定义一个 Job  
                IJobDetail job1 = JobBuilder.Create<DemoJob1>()
                    .WithIdentity("job1", "group1")
                    .Build();
                IJobDetail job2 = JobBuilder.Create<DemoJob2>()
                    .WithIdentity("job2", "group1")
                    .Build();
                ISimpleTrigger trigger1 = (ISimpleTrigger)TriggerBuilder.Create()
                    .WithIdentity("trigger1") // 给任务一个名字  
                    .StartAt(DateTime.Now) // 设置任务开始时间  
                    .ForJob("job1", "group1") //给任务指定一个分组  
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(1)  //循环的时间 1秒1次 
                        .RepeatForever())
                    .Build();
                ISimpleTrigger trigger2 = (ISimpleTrigger)TriggerBuilder.Create()
                    .WithIdentity("trigger2") // 给任务一个名字  
                    .StartAt(DateTime.Now) // 设置任务开始时间  
                    .ForJob("job2", "group1") //给任务指定一个分组  
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(2)  //循环的时间 1秒1次 
                        .RepeatForever())
                    .Build();

                // 等待执行任务  
                await scheduler.ScheduleJob(job1, trigger1);
                await scheduler.ScheduleJob(job2, trigger2);
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
    }

    public class DemoJob1 : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Console.Out.WriteLineAsync("demo1 of AutoJob!");
        }
    }

    public class DemoJob2 : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Console.Out.WriteLineAsync("demo2 of AutoJob!");
        }
    }
}
