
using MyHistory.Application.Common.Interfaces.Persistence;

namespace MyHistory.Application.Common.Interfaces.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompletedAsync();

        public IUserRepository Users { get; }



    }
}
