using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pos_service_api.Dto;
using pos_service_api.Models;
using System.Data;

namespace pos_service_api.Repositories
{
    public class DatamovementPerproductDao
    {

        private readonly PosDbContext _context;

        public DatamovementPerproductDao(PosDbContext context)
        {
            _context = context;
        }

        public List<MovementDto> SearchNative(int tahun, int bulan)
        {
            string sqlQuery = @"SELECT
	            datamovement.TAHUN,
	            datamovement.BULAN,
	            datamovement.PRODUCTCODE,
	            datamovement.PRODUCTNAME,
	            datamovement.PENSIUN,
	            datamovement.MENINGGAL,
	            datamovement.KELUAR
            FROM
	            DATAMOVEMENT_PERPRODUCT datamovement
            WHERE
	            datamovement.TAHUN = @tahun
	            AND datamovement.BULAN = @bulan";

            var dataTable = new DataTable();

            using (SqlConnection connection = (SqlConnection)_context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = sqlQuery;
                    command.Parameters.AddWithValue("@tahun", tahun);
                    command.Parameters.AddWithValue("@bulan", bulan);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        dataTable = dataset.Tables[0];
                    }
                }
                connection.Close();
            }

            var listdata = dataTable.AsEnumerable().Select(data => new MovementDto
            {
                TAHUN = data.Field<int>("TAHUN"),
                BULAN = data.Field<int>("BULAN"),
                KODEPRODUK = data.Field<string?>("PRODUCTCODE"),
                NAMAPRODUK = data.Field<string?>("PRODUCTNAME"),
                PENSIUN = data.Field<int>("PENSIUN"),
                MENINGGAL = data.Field<int>("MENINGGAL"),
                KELUAR = data.Field<int>("KELUAR")
            });



            return listdata.ToList();

        }

    }
}
