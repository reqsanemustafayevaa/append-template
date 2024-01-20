using append.business.Services.Interfaces;
using append.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace append.MVC.ViewServices
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;

        public LayoutService(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<List<Setting>> GetSettings()
        {
            return await _settingService.GetAllAsync();
        }
    }
}
