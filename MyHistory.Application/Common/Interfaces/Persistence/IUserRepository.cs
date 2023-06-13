using MyHistory.Application.Common.Interfaces.Generic;
using MyHistory.Domain.Entities;

namespace MyHistory.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User?> GetUserByEmail(string email);//can get user or not '?'

    }
}
