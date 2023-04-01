using Domain.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IGenericRepository<TEntity>
 where TEntity : class, IEntity
    {

        Task CommitAsync();
        Task<TEntity> GetById(int id);

        void Create<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Update(int id, TEntity entity);

        Task Disable(int id);
        Task Enable(int id);

       
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;

        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;

        Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;


        IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;
        IQueryable<TEntity> WhereAsync<TEntity>(Expression<Func<TEntity, bool>> expression)where TEntity : class, IEntity;
    }
}
