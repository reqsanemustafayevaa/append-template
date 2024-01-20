using append.core.Models;
using append.core.Repositories.Interfaces;
using append.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.data.Repositories.Implementations
{
    public class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(AppDbContext context) : base(context)
        {
        }
    }
}
