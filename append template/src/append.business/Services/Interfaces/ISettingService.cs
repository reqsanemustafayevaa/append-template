using append.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.business.Services.Interfaces
{
    public interface ISettingService
    {
        Task<List<Setting>> GetAllAsync();
        Task<Setting> GetByIdAsync(int id);
        Task UpdateAsync(Setting setting);
    }
}
