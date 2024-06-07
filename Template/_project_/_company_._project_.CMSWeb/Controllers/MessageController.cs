using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _company_._project_.CMSWeb.Controllers
{
    public class MessageController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}