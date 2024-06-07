using _company_._project_.Service.Attributes;

namespace _company_._project_.Web.Areas.Admin.Controllers
{
    [LoginPermission]
    public class LoggedOnController : AdminBaseController
    {
    }
}