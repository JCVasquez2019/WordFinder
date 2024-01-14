using WordFinder.Application.Contracts.Persistence;
using WordFinder.Domain.Common;

namespace WordFinder.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;
        Task<int> Complete();
    }
}
