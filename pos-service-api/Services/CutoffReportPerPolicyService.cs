using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using pos_service_api.Dto;
using pos_service_api.Models;
using System.Data;
using System.IO.Compression;
using System.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace pos_service_api.Services
{
    public class CutoffReportPerPolicyService : CommonService
    {

        private readonly PosDbContext _context;
        public CutoffReportPerPolicyService(PosDbContext context) : base(context)
        {
            _context = context;
        }
        public List<PolicyDto> SearchCadanganPerPolis(int? tahun, int? bulan, string? policyno, string? productname, string? partnername)
        {
            if (tahun == null || bulan == null)
                return new List<PolicyDto>();


            var dataTable = new DataTable();

            using (SqlConnection connection = (SqlConnection)_context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT cutoff.NOMOR_SPA, cutoff.NOMOR_POLIS AS POLICYNO, cutoff.NAMA_INSTANSI_BUSB AS INSTANSI, " +
                        "cutoff.NAMA_PRODUK, COUNT(*) AS TOTAL_PESERTA FROM TBL_DETAIL_CUTOFF_THN_BLN cutoff " +
                        "WHERE cutoff.SEGMEN_PRODUK = 'KUMPULAN' AND cutoff.THN = @p_tahun AND cutoff.BLN = @p_bulan " +
                        "AND cutoff.STAPEG IN (0, 1, 6, 9, 20, 22, 30, 31 , 100) AND cutoff.NAMA_INSTANSI_BUSB LIKE @p_instansi " +
                        "AND cutoff.NAMA_PRODUK LIKE @p_productname AND cutoff.NOMOR_POLIS LIKE @p_policyno " +
                        "AND cutoff.KODE_PRODUK NOT IN ('TS', 'CL') " +
                        "GROUP BY cutoff.NOMOR_SPA, cutoff.NOMOR_POLIS, cutoff.NAMA_INSTANSI_BUSB, cutoff.NAMA_PRODUK";
                    command.Parameters.AddWithValue("@p_tahun", tahun);
                    command.Parameters.AddWithValue("@p_bulan", bulan);
                    command.Parameters.AddWithValue("@p_instansi", $"%{partnername}%");
                    command.Parameters.AddWithValue("@p_productname", $"%{productname}%");
                    command.Parameters.AddWithValue("@p_policyno", $"%{policyno}%");

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
                connection.Close();
            }

            var listdata = dataTable.AsEnumerable().Select(data => new PolicyDto
            {
                IDPOLICY = data.Field<Int64>("NOMOR_SPA"),
                POLICYNO = data.Field<string?>("POLICYNO"),
                PARTNERNAME = data.Field<string?>("INSTANSI"),
                PRODUCTNAME = data.Field<string?>("NAMA_PRODUK"),
                TOTALMEMBER = data.Field<int>("TOTAL_PESERTA")
            });

            return listdata.ToList();
        }

        public MemoryStream DownloadCadanganPerPolicy(int tahun, int bulan, string? policyno, string? productname, string? partnername)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    
                    List<Int64> listPolicyId = new List<Int64>();
                    listPolicyId.Add(2256);
                    listPolicyId.Add(2263);
                    listPolicyId.Add(2874);

                    foreach (Int64 policyid in listPolicyId)
                    {
                        ZipArchiveEntry entry = archive.CreateEntry(policyid + ".xlsx");

                        byte[] fileBytes = CadanganPerPolicy(tahun, bulan, policyid);
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.Write(fileBytes, 0, fileBytes.Length);
                        }

                    }

                    



                }
                Console.WriteLine("DOWNLOAD CADANGAN PER POLICY - END " + tahun + "-" + bulan + " ---> " + DateTime.Now);
                return memoryStream;
            }
        }

        private byte[] CadanganPerPolicy(int tahun, int bulan, Int64 idpolicy)
        {
            string fileName = @"TemplateReport/template_report_cadangan_per_policy.xlsx";
            byte[] excelFileBytes = System.IO.File.ReadAllBytes(fileName);
            var dataTable = getDataTable("SP_RPT_CUTOFF_PER_POLICY", tahun, bulan, idpolicy);
            Console.WriteLine("Mapping DataTable to ListData ---> " + DateTime.Now);
            var listdata = dataTable.AsEnumerable().Select(data => new
            {
                NOTAS = data.Field<string?>("NOTAS")
            });

            Console.WriteLine("MemoryStream ---> " + DateTime.Now);
            using (MemoryStream stream = new MemoryStream(excelFileBytes))
            {
                Console.WriteLine("XSSFWorkbook ---> " + DateTime.Now);
                using (XSSFWorkbook workbook = new XSSFWorkbook(stream))
                {
                    ISheet sheet = workbook.GetSheetAt(0);
                    SetCellValue(sheet.GetRow(1), 1, tahun);
                    SetCellValue(sheet.GetRow(2), 1, bulan);
                    SetCellValue(sheet.GetRow(4), 1, listdata.Count());

                    int indexdata = 7;
                    foreach (var data in listdata)
                    {
                        IRow rowData = sheet.GetRow(indexdata) ?? sheet.CreateRow(indexdata);

                        SetCellValue(rowData, 0, (indexdata - 6));
                        SetCellValue(rowData, 1, data.NOTAS);
                        indexdata++;
                    }

                    Console.WriteLine("SetCellValue END ---> " + DateTime.Now);


                    using (MemoryStream updatedStream = new MemoryStream())
                    {
                        workbook.Write(updatedStream);
                        Console.WriteLine("workbook.Write(updatedStream) END ---> " + DateTime.Now);
                        return updatedStream.ToArray();
                    }
                }
            }
        }
    }
}
