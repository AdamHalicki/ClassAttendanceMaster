using Domain.Entities;
using Domain.Repositiories;
using System.Linq;

namespace Persistance.Repositories
{
    internal interface IInternalRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        IQueryable<TEntity> Query();
    }
}
