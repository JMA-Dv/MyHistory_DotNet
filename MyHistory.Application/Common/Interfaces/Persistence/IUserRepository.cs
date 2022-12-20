using MyHistory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetUserByEmail(string email);//can get user or not '?'
    }
}
