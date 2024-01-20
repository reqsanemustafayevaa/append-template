using append.business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.business.Services.Interfaces
{
    public interface IAuthService
    {
        Task Login(LoginViewModel loginVm);
    }
}
