using Domain.Entities;
using Domain.Repositiories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class Repository<TEntity> : IInternalRepository<TEntity>, IRepository<TEntity>
            where TEntity : class, IBaseEntity, new()
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            return this.dbContext.Add(entity).Entity;
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            dbContext.AddRange(entities);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await dbContext.AddAsync(entity)).Entity;
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await dbContext.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            dbContext.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            dbContext.Remove(entity);
        }

        public void Remove(int id)
        {
            var entity = new TEntity() { Id = id };
            dbContext.Attach(entity);
            dbContext.Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            dbContext.RemoveRange(entities);
        }

        public void Remove(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                var entity = new TEntity() { Id = id };
                dbContext.Attach(entity);
                dbContext.Remove(entity);
            }
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<int> GetAllIds()
        {
            return dbContext.Set<TEntity>()
                .Select(entity => entity.Id)
                .ToList();
        }

        public async Task<IEnumerable<int>> GetAllIdsAsync()
        {
            return await dbContext.Set<TEntity>()
                .Select(entity => entity.Id)
                .ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return dbContext.Find<TEntity>(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbContext.FindAsync<TEntity>(id);
        }

        public IQueryable<TEntity> Query()
        {
            return dbContext.Set<TEntity>();
        }
    }
}
