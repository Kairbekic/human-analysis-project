using HumAnalysis.Domain.Entity;
using HumAnalysis.Domain.Response;
using HumAnalysis.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> Create(ContourYearViewModel model);

        BaseResponse<Dictionary<int, string>> GetRoles();

        Task<BaseResponse<IEnumerable<ContourYearViewModel>>> GetUsers();

        Task<IBaseResponse<bool>> DeleteUser(long id);
    }
}
