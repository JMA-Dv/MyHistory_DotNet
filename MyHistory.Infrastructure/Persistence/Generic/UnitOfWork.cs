using Microsoft.Extensions.Logging;
using MyHistory.Application.Common.Interfaces.Generic;
using MyHistory.Application.Common.Interfaces.Persistence;
using MyHistory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Infrastructure.Persistence.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyHistoryDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(MyHistoryDbContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");
            Users = new UserRepository(_context,_logger);
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
