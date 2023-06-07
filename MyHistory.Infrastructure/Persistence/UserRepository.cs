using MyHistory.Application.Common.Interfaces.Persistence;
using MyHistory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        public Task Add(User user)
        {
            

        }

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(x => x.Email == email);
        }
    }
}
