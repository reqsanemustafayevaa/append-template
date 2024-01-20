using append.business.Exceptions;
using append.business.Services.Interfaces;
using append.business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace append.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
           _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _authService.Login(model);
            }
            catch(InvalidCredsException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception )
            {
                throw;
            }
            return RedirectToAction("index","Team");
        }
    }
}
