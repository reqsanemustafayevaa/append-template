using append.business.Exceptions;
using append.business.Services.Interfaces;
using append.core.Models;
using append.core.Repositories.Interfaces;
using append.data.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public async Task<List<Setting>> GetAllAsync()
        {
            return await _settingRepository.GetAllAsync().ToListAsync();
        }

        public  Task<Setting> GetByIdAsync(int id)
        {
            var setting = _settingRepository.GetByIdAsync(x => x.Id == id);
            if (setting == null)
            {
                throw new MemberNotFoundException();
            }
            return setting;
        }

        public async Task UpdateAsync(Setting setting)
        {
           
            var existsetting = await _settingRepository.GetByIdAsync(x => x.Id == setting.Id);
            if (existsetting == null)
            {
                throw new SettingNotFoundException("", "Setting not found");
            }
            existsetting.Value = setting.Value;
            existsetting.Updatedate = DateTime.UtcNow;
            await _settingRepository.CommitAsync();

        }
    }
}
