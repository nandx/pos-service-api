using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using pos_service_api.Models;
using System.Data;

namespace pos_service_api.Services
{
    public class CutoffReportCreditLifeService : CommonService
    {
        public CutoffReportCreditLifeService(PosDbContext context) : base(context)
        {
        }

        public byte[] DownloadCutoffReportCreditLife(int tahun, int bulan)
        {
            string fileName = @"TemplateReport/template_report_cadangan_creditlife.xlsx";
            byte[] excelFileBytes = System.IO.File.ReadAllBytes(fileName);

            var dataTable = getDataTable("SP_RPT_CUTOFF_CREDITLIFE", tahun, bulan);
            Console.WriteLine("Mapping DataTable to ListData ---> " + DateTime.Now);
            var listdata = dataTable.AsEnumerable().Select(data => new
            {
                IDMEMBER = data.Field<Int64>("IDMEMBER"),
                NOTAS = data.Field<string?>("NOTAS"),
                IDCARDNUMBER = data.Field<string?>("IDCARDNUMBER"),
                FULLNAME = data.Field<string?>("FULLNAME"),
                DOB = data.Field<DateTime>("DOB"),
                MULAI_ASURANSI = data.Field<DateTime>("MULAI_ASURANSI"),
                AKHIR_ASURANSI = data.Field<DateTime>("AKHIR_ASURANSI"),
                TOTALSUMASSURED = data.Field<Double?>("TOTALSUMASSURED"),
                TOTALPREMIUM = data.Field<Double?>("TOTALPREMIUM"),
                STAPEG = data.Field<Int32?>("STAPEG"),
                NAMA_STAPEG = data.Field<string?>("NAMA_STAPEG"),
                TERMBULAN = data.Field<Int32?>("TERMBULAN"),
                TERMTAHUN = data.Field<Int32?>("TERMTAHUN"),
                PKNO = data.Field<string?>("PKNO"),
                UPM = data.Field<string?>("UPM"),
                INSTANSI = data.Field<string?>("INSTANSI"),
                BULAN = data.Field<Int32?>("BULAN"),
                TAHUN = data.Field<Int32?>("TAHUN"),
                POLICYNO = data.Field<string?>("POLICYNO"),
                PAYMETH = data.Field<string>("PAYMETH"),
                PRODCODE = data.Field<int>("PRODCODE"),
                PRODUCT_NAME = data.Field<string>("PRODUCT_NAME"),
                ENTITY_ID = data.Field<string>("ENTITY_ID"),
                REPORTING_DATE = data.Field<string>("REPORTING_DATE"),
                CEDED_FLAG = data.Field<string>("CEDED_FLAG"),
                M_BEGIN_COV = data.Field<string?>("M_BEGIN_COV"),
                M_END_COV = data.Field<string?>("M_END_COV"),
                ICG_ID = data.Field<string?>("ICG_ID"),
                ICG_BEGIN_COV = data.Field<string?>("ICG_BEGIN_COV"),
                ICG_END_COV = data.Field<string?>("ICG_END_COV"),
                ICG_NB_ID = data.Field<string?>("ICG_NB_ID"),
                NB_BEGIN_COV = data.Field<string?>("NB_BEGIN_COV"),
                NB_END_COV = data.Field<string?>("NB_END_COV"),
                PORTOFOLIO_ID = data.Field<string?>("PORTOFOLIO_ID"),
                CURRENCY_CD = data.Field<string?>("CURRENCY_CD"),
                PV_CSM = data.Field<string?>("PV_CSM"),
                PTF_STATUS = data.Field<string?>("PTF_STATUS"),
                DERECOGNIZE_DT = data.Field<string?>("DERECOGNIZE_DT"),
                EARNED_PREM = data.Field<string?>("EARNED_PREM")
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
                        SetCellValue(rowData, 1, data.IDMEMBER);
                        SetCellValue(rowData, 2, data.NOTAS);
                        SetCellValue(rowData, 3, data.IDCARDNUMBER);
                        SetCellValue(rowData, 4, data.FULLNAME);
                        SetCellValue(rowData, 5, data.DOB);
                        SetCellValue(rowData, 6, data.MULAI_ASURANSI);
                        SetCellValue(rowData, 7, data.AKHIR_ASURANSI);
                        SetCellValue(rowData, 8, data.TOTALSUMASSURED);
                        SetCellValue(rowData, 9, data.TOTALPREMIUM);
                        SetCellValue(rowData, 10, data.STAPEG);
                        SetCellValue(rowData, 11, data.NAMA_STAPEG);
                        SetCellValue(rowData, 12, data.TERMBULAN);
                        SetCellValue(rowData, 13, data.TERMTAHUN);
                        SetCellValue(rowData, 14, data.PKNO);
                        SetCellValue(rowData, 15, data.UPM);
                        SetCellValue(rowData, 16, data.INSTANSI);
                        SetCellValue(rowData, 17, data.BULAN);
                        SetCellValue(rowData, 18, data.TAHUN);
                        SetCellValue(rowData, 19, data.PAYMETH);
                        SetCellValue(rowData, 20, data.PRODCODE);
                        SetCellValue(rowData, 21, data.PRODUCT_NAME);
                        SetCellValue(rowData, 22, data.ENTITY_ID);
                        SetCellValue(rowData, 23, data.REPORTING_DATE);
                        SetCellValue(rowData, 24, data.POLICYNO);
                        SetCellValue(rowData, 25, data.NOTAS);
                        SetCellValue(rowData, 26, data.CEDED_FLAG);
                        SetCellValue(rowData, 27, data.M_BEGIN_COV);
                        SetCellValue(rowData, 28, data.M_END_COV);
                        SetCellValue(rowData, 29, data.ICG_ID);
                        SetCellValue(rowData, 30, data.ICG_BEGIN_COV);
                        SetCellValue(rowData, 31, data.ICG_END_COV);
                        SetCellValue(rowData, 32, data.ICG_NB_ID);
                        SetCellValue(rowData, 33, data.NB_BEGIN_COV);
                        SetCellValue(rowData, 34, data.NB_END_COV);
                        SetCellValue(rowData, 35, data.PORTOFOLIO_ID);
                        SetCellValue(rowData, 36, data.CURRENCY_CD);
                        SetCellValue(rowData, 37, data.PV_CSM);
                        SetCellValue(rowData, 38, data.PTF_STATUS);
                        SetCellValue(rowData, 39, data.DERECOGNIZE_DT);
                        SetCellValue(rowData, 40, data.EARNED_PREM);

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
