using append.business.Exceptions;
using append.business.Services.Implementations;
using append.business.Services.Interfaces;
using append.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace append.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            var settings=await _settingService.GetAllAsync();
            return View(settings);
        }
        public async Task<IActionResult> Update(int id)
        {
            var existsetting = await _settingService.GetByIdAsync(id);
            if (existsetting == null)
            {
                return View("Error");
            }
            return View(existsetting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View(setting);
            }
            try
            {
                await _settingService.UpdateAsync(setting);
            }
            catch (SettingNotFoundException ex)
            {
                return View("Error");
            }
          
            catch (Exception )
            {
                throw;
            }
            return RedirectToAction("index");
        }

    }
}
