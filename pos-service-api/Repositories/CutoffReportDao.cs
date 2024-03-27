using pos_service_api.Models;

namespace pos_service_api.Repositories
{
    public class CutoffReportDao
    {
        private readonly PosDbContext _context;

        public CutoffReportDao(PosDbContext context)
        {
            _context = context;
        }
    }
}
