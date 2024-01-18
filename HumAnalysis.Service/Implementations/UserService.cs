using HumAnalysis.Domain.Entity;
using HumAnalysis.Domain.Response;
using HumAnalysis.Domain.ViewModels.User;
using HumAnalysis.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Service.Implementations
{
    public class UserService : IUserService
    {
        public Task<IBaseResponse<User>> Create(ContourYearViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Dictionary<int, string>> GetRoles()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<ContourYearViewModel>>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
