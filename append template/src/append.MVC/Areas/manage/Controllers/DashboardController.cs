using Microsoft.AspNetCore.Mvc;

namespace append.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
