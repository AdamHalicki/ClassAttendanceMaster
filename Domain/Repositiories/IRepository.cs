using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositiories
{
    public interface IRepository<TEntity>
            where TEntity : class, IBaseEntity, new()
    {
        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<int> GetAllIds();

        Task<IEnumerable<int>> GetAllIdsAsync();

        TEntity Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        Task<TEntity> AddAsync(TEntity entity);

        Task AddAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Remove(int id);

        void Remove(IEnumerable<TEntity> entities);

        void Remove(IEnumerable<int> ids);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
