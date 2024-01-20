using append.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.business.Services.Interfaces
{
    public interface ITeamMemberService
    {
        Task CreateAsync(TeamMember teamMember);
        Task UpdateAsync(TeamMember teamMember);
        Task Delete(int id);
        Task<List<TeamMember>> GetAllAsync();
        Task<TeamMember> GetByIdAsync(int id);
    }
}
