
namespace MyHistory.Application.Common.Interfaces.Generic
{
    public interface IUnitOfWork:IDisposable
    {
        int Save();

    }
}
