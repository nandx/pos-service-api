using pos_service_api.Dto;
using pos_service_api.Models;
using pos_service_api.Repositories;

namespace pos_service_api.Services
{
    public class DataMovementService
    {
        private readonly DatamovementPerproductDao _datamovementPerproductDao;
        private readonly DataMovementDao _dataMovementDao;

        public DataMovementService(DatamovementPerproductDao datamovementPerproductDao, DataMovementDao dataMovementDao) {
            _datamovementPerproductDao = datamovementPerproductDao;
            _dataMovementDao = dataMovementDao; 
        }

        public List<MovementDto> Search(int tahun, int bulan) {
            if (bulan > 12 || bulan < 1)
                return [];


            List<MovementDto> list = _datamovementPerproductDao.SearchNative(tahun, bulan);
            return list;
        }

        public IList<DatamovementPerproduct> SearchHibernate(int tahun, int bulan)
        {
            if (bulan > 12 || bulan < 1)
                return [];


            IList<DatamovementPerproduct> list = _dataMovementDao.Search(tahun, bulan);
            return list;
        }
    }
}
