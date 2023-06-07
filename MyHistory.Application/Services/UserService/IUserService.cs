using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Application.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> AddUser();
    }
}
