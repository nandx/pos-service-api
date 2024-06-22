using NHibernate;
using NHibernate.Criterion;
using pos_service_api.Models;

namespace pos_service_api.Repositories
{
    public class DataMovementDao : CommonDaoImpl<DatamovementPerproduct>
    {
        public DataMovementDao(NHibernate.ISession session, ISessionFactory sessionFactory) : base(session, sessionFactory)
        {
            _session = session;
            _sessionFactory = sessionFactory;
        }

        public IList<DatamovementPerproduct> Search(int tahun, int bulan)
        {
            IList<DatamovementPerproduct> listdata = _session.QueryOver<DatamovementPerproduct>()
                .Where(Restrictions.Conjunction()
                .Add(Restrictions.Eq("TAHUN", tahun))
                .Add(Restrictions.Eq("BULAN", bulan))).List();
            return listdata;

        }


    }
}
