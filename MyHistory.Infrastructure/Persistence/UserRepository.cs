using Microsoft.Extensions.Logging;
using MyHistory.Application.Common.Interfaces.Persistence;
using MyHistory.Domain.Entities;
using MyHistory.Infrastructure.Data;
using MyHistory.Infrastructure.Persistence.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Infrastructure.Persistence
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyHistoryDbContext dbContext) : base(dbContext)
        {
        }

        public User? GetUserByEmail(string email)
        {
            return _dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
