using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using pos_service_api.Models;
using System.Data;

namespace pos_service_api.Services
{
    public class CommonService
    {

        private readonly PosDbContext _context;
        public CommonService(PosDbContext context)
        {
            _context = context;
        }
        protected void SetCellValue(IRow rowData, int indexcell, String? value)
        {
            ICell cellDataTahun = rowData.GetCell(indexcell) ?? rowData.CreateCell(indexcell);
            cellDataTahun.SetCellValue(value);
        }

        protected void SetCellValue(IRow rowData, int indexcell, int value)
        {
            ICell cellDataTahun = rowData.GetCell(indexcell) ?? rowData.CreateCell(indexcell);
            cellDataTahun.SetCellValue(value);
        }

        protected void SetCellValue(IRow rowData, int indexcell, Int32? value)
        {
            ICell cellDataTahun = rowData.GetCell(indexcell) ?? rowData.CreateCell(indexcell);
            if (value.HasValue)
                cellDataTahun.SetCellValue(value.GetValueOrDefault());
        }

        protected void SetCellValue(IRow rowData, int indexcell, Int64 value)
        {
            ICell cellDataTahun = rowData.GetCell(indexcell) ?? rowData.CreateCell(indexcell);
            cellDataTahun.SetCellValue(value);
        }

        protected void SetCellValue(IRow rowData, int indexcell, DateTime? value)
        {
            ICell cellDataTahun = rowData.GetCell(indexcell) ?? rowData.CreateCell(indexcell);
            cellDataTahun.SetCellValue(value?.ToString("yyyy-MM-dd"));
        }

        protected void SetCellValue(IRow rowData, int indexcell, Double value)
        {
            ICell cellDataTahun = rowData.GetCell(indexcell) ?? rowData.CreateCell(indexcell);
            cellDataTahun.SetCellValue(value);
        }

        protected void SetCellValue(IRow rowData, int indexcell, Double? value)
        {
            ICell cellDataTahun = rowData.GetCell(indexcell) ?? rowData.CreateCell(indexcell);
            if(value.HasValue)
                cellDataTahun.SetCellValue(value.GetValueOrDefault());
        }

        protected DataTable getDataTable(string storeprocedurename, int year, int month)
        {
            var dataTable = new DataTable();

            using (var connection = _context.Database.GetDbConnection() as SqlConnection)
            {
                connection.Open();
                Console.WriteLine("Connection Open ---> " + DateTime.Now);
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storeprocedurename;

                    // Menambahkan parameter
                    command.Parameters.Add(new SqlParameter("@p_bulan", month));
                    command.Parameters.Add(new SqlParameter("@p_tahun", year));

                    Console.WriteLine("SqlDataAdapter ---> " + DateTime.Now);
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataset = new DataSet();
                        Console.WriteLine("adapter.Fill(dataset) ---> " + DateTime.Now);
                        adapter.Fill(dataset);
                        Console.WriteLine("dataset.Tables[0] ---> " + DateTime.Now);
                        dataTable = dataset.Tables[0];
                    }

                }
                Console.WriteLine("Connection Closing ---> " + DateTime.Now);

            }
            return dataTable;
        }


        protected DataTable getDataTable(string storeprocedurename, int year, int month, Int64 idpolicy)
        {
            var dataTable = new DataTable();

            using (var connection = _context.Database.GetDbConnection() as SqlConnection)
            {
                connection.Open();
                Console.WriteLine("Connection Open ---> " + DateTime.Now);
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storeprocedurename;

                    // Menambahkan parameter
                    command.Parameters.Add(new SqlParameter("@p_bulan", month));
                    command.Parameters.Add(new SqlParameter("@p_tahun", year));
                    command.Parameters.Add(new SqlParameter("@p_idpolicy", idpolicy));

                    Console.WriteLine("SqlDataAdapter ---> " + DateTime.Now);
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataset = new DataSet();
                        Console.WriteLine("adapter.Fill(dataset) ---> " + DateTime.Now);
                        adapter.Fill(dataset);
                        Console.WriteLine("dataset.Tables[0] ---> " + DateTime.Now);
                        dataTable = dataset.Tables[0];
                    }

                }
                Console.WriteLine("Connection Closing ---> " + DateTime.Now);

            }
            return dataTable;
        }


    }
}
