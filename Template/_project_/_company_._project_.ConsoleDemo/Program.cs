using System;
using Microsoft.Extensions.Configuration;
using _company_._project_.BLL;
using _company_._project_.DAL;
using _company_._project_.Entity;
using System.Reflection;
using System.Collections.Generic;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using System.Linq;

namespace _company_._project_.ConsoleDemo
{
    class Program
    {
        public static IConfigurationRoot Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();

        static void Main(string[] args)
        {
            Assembly asm = Assembly.Load("_company_._project_.AdminWeb");
            var classes = asm.GetTypes();
            List<MethodInfo> controllermethodlist = null;
            List<MethodInfo> ignoremethodlist = null;
            List<string> classList = new List<string>();
        
            foreach (var item in classes)
            {
                if (item.Name.IndexOf("Controller") > -1)
                {
                    classList.Add(item.FullName);

                }

            }
            Type t = null;
            foreach(string item in classList)
            {
                if (item.IndexOf("BaseController") > -1)
                {
                    t = asm.GetType(item);
                    if (t != null)
                    {
                        ignoremethodlist = new List<MethodInfo>(t.GetMethods());
                       
                    }
                }
                if (item.IndexOf("SystemLogController") > -1)
                {
                    t = asm.GetType(item);
                    if (t != null)
                    {
                        controllermethodlist =new List<MethodInfo>(t.GetMethods()) ;
                        break;
                    }
                }
            }
            List<string> ignoreresult = new List<string>();
            foreach (var item in ignoremethodlist)
            {
                ignoreresult.Add("/SystemLogController/" + item.Name.ToString());
            }
            List<string> result = new List<string>();
            foreach (var item in controllermethodlist)
            {
                result.Add("/SystemLogController/" + item.Name.ToString());
            }
            var newcontrl = result.Except(ignoreresult).ToList();
            foreach (var item in newcontrl)
            {
                Console.WriteLine(item);
            }

        }
       



         ///



    }
}
