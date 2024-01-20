
using append.data.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace append.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var members=_context.TeamMembers.ToList();
            return View(members);
        }

       
    }
}