using Domain.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.Linq.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IEntity
    {
        private readonly KensyLibraryDbContext _dbContext;

        public GenericRepository(KensyLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            entity.CreationTime = DateTime.Now;
            entity.CreatorUser = "Admin";
            entity.IsActive = true;
            _dbContext.Set<TEntity>().Add(entity);
        }

        public async Task CreateRange(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.CreationTime = DateTime.Now;
                entity.CreatorUser = "Admin";
                entity.IsActive = true;
            };

            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task Disable(int id)
        {
            var entity = await GetById(id);
            entity.IsActive = false;
            entity.DisableUser = "Admin";
            entity.DisableDateTime = DateTime.Now;
            _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task Enable(int id)
        {
            var entity = await GetById(id);
            entity.IsActive = true;
            entity.EnableUser = "Admin";
            entity.EnableDateTime = DateTime.Now;
            _dbContext.Set<TEntity>().Update(entity);
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
        {
            return _dbContext.Set<TEntity>().WithTranslations();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Update(int id, TEntity entity)
        {
            entity.LastModificationTime = DateTime.Now;
            entity.LastModifiedUser = "Admin";
            _dbContext.Set<TEntity>().Update(entity);
        }

        Task<bool> IGenericRepository<TEntity>.AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
        {
            return this.WhereAsync<TEntity>(expression).AnyAsync();
        }

        public Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity
        {
            return this.WhereAsync<TEntity>(expression).FirstOrDefaultAsync();
        }

        IQueryable<TEntity> IGenericRepository<TEntity>.Query<TEntity>(Expression<Func<TEntity, bool>> expression)
        {
            return this.WhereAsync<TEntity>(expression).AsNoTracking();
        }

        IQueryable<TEntity> IGenericRepository<TEntity>.Query<TEntity>()
        {
            return this.GetAll<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> WhereAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity
        {
            return _dbContext.Set<TEntity>().Where(expression).WithTranslations();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
