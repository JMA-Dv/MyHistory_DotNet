using Microsoft.EntityFrameworkCore;
using MyHistory.Application.Common.Interfaces.Persistence;
using MyHistory.Domain.Entities;
using MyHistory.Infrastructure.Data;
using MyHistory.Infrastructure.Persistence.Generic;

namespace MyHistory.Infrastructure.Persistence
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyHistoryDbContext dbContext) : base(dbContext)
        {
        }

        public async  Task<User?> GetUserByEmail(string email)
        {

            var some = await _dbContext.Users.Where(x=>x.Email == email).FirstAsync();
            var result = await _dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return result;
        }
    }
}
