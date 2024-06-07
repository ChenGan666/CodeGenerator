using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.Entity;
using _company_._project_.Service.WebHelpers;

namespace _company_._project_.Web.Areas.Admin.Controllers
{
    public class HomeController : LoggedOnController
    {

        public IActionResult Index()
        {
            ViewBag.AdminMenu = DictionaryHelper.GetDicByName("后台菜单").ChildrenList;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}