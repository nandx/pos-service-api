using pos_service_api.Models;
using System.Linq.Expressions;

namespace pos_service_api.Repositories
{
    public interface ICommonDao<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();

        IList<TEntity> GetAllList();

        TEntity? GetById(long id);

        TEntity FindBy(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);

        Task SaveOrUpdate(TEntity entity);

        Task Create(TEntity entity);

        Task Update(long id, TEntity entity);

        Task Delete(TEntity entity);
    }
}
