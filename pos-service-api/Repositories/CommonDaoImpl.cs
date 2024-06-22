using System.Linq.Expressions;
using NHibernate;
using pos_service_api.Models;

namespace pos_service_api.Repositories
{
    public class CommonDaoImpl<TEntity> : ICommonDao<TEntity> where TEntity : IEntity
    {
        protected NHibernate.ISession _session { get; set; }
        protected NHibernate.ISessionFactory _sessionFactory { get; set; }

        public CommonDaoImpl(NHibernate.ISession session, NHibernate.ISessionFactory sessionFactory)
        {
            _session = session;
            _sessionFactory = sessionFactory;
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IList<TEntity> GetAllList()
        {
            return (IList<TEntity>)_session.Query<TEntity>().ToList();
        }

        public TEntity? GetById(long id)
        {
            return _session.Query<TEntity>().Where(field => field.ID == id).FirstOrDefault();
        }

        public TEntity FindBy(Expression<Antlr.Runtime.Misc.Func<TEntity, bool>> expression)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> FilterBy(Expression<Antlr.Runtime.Misc.Func<TEntity, bool>> expression)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveOrUpdate(TEntity entity)
        {
            using (_session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }

            return Task.CompletedTask;
        }

        public Task Create(TEntity entity)
        {
            using (_session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(entity);
                    transaction.Commit();
                }
            }

            return Task.CompletedTask;
        }

        public Task Update(long id, TEntity entity)
        {
            using (_session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(entity);
                    transaction.Commit();
                }
            }

            return Task.CompletedTask;
        }

        public Task Delete(TEntity entity)
        {
            using (_session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(entity);
                }
            }
            return Task.CompletedTask;
        }

        public TEntity FindBy(Expression<System.Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FilterBy(Expression<System.Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }


    }
}
