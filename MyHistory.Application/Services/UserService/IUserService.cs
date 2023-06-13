using MyHistory.Application.Services.Authentication;
using MyHistory.Domain.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Application.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<AuthenticationResult>> AddUser();
        Task<IEnumerable<AuthenticationResult>> UpdateUser();
        Task<UserResponse> GetUserByEmailAsync(string email);
    }
}
