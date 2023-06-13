using MyHistory.Application.Common.Interfaces.Generic;
using MyHistory.Application.Common.Interfaces.Persistence;
using MyHistory.Infrastructure.Data;

namespace MyHistory.Infrastructure.Persistence.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyHistoryDbContext _context;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(MyHistoryDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public async Task<int> CompletedAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
