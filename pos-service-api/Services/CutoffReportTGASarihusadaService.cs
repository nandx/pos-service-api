using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using pos_service_api.Models;
using System;
using System.Data;
using System.Reflection;

namespace pos_service_api.Services
{
    public class CutoffReportTGASarihusadaService : CommonService
    {
        public CutoffReportTGASarihusadaService(PosDbContext context) : base(context)
        {
        }

        public byte[] DownloadCutoffReportTGASarihusada(int tahun, int bulan)
        {
            string fileName = @"TemplateReport/template_report_cadangan_tga_sarihusada.xlsx";
            byte[] excelFileBytes = System.IO.File.ReadAllBytes(fileName);

            var dataTable = getDataTable("SP_RPT_CUTOFF_TGA_SARIHUSADA", tahun, bulan);
            Console.WriteLine("Mapping DataTable to ListData ---> " + DateTime.Now);
            var listdata = dataTable.AsEnumerable().Select(data => new
            {
                TAHUN = data.Field<Int32?>("TAHUN"),
                BULAN = data.Field<Int32?>("BULAN"),
                SPANO = data.Field<Int64?>("SPANO"),
                POLICYNO = data.Field<string?>("POLICYNO"),
                PARTNERNAME = data.Field<string?>("PARTNERNAME"),
                PRODUCTNAME = data.Field<string?>("PRODUCTNAME"),
                NOTAS = data.Field<string?>("NOTAS"),
                TGLSALDO = data.Field<DateTime?>("TGLSALDO"),
                MEMBERNO = data.Field<Int64?>("MEMBERNO"),
                NAME = data.Field<string?>("NAME"),
                AKUMULASI_PREMI = data.Field<Double?>("AKUMULASI_PREMI"),
                PREMI = data.Field<Double?>("PREMI"),
                SALDO_AWAL = data.Field<Double?>("SALDO_AWAL"),
                BPA2 = data.Field<Double?>("BPA2"),
                COI = data.Field<Double?>("COI"),
                KOMISI = data.Field<Double?>("KOMISI"),
                BPA1 = data.Field<Double?>("BPA1"),
                BPD1 = data.Field<Double?>("BPD1"),
                INV = data.Field<Double?>("INV"),
                BPD2 = data.Field<Double?>("BPD2"),
                SALDO_AKHIR = data.Field<Double?>("SALDO_AKHIR"),
                UP = data.Field<Double?>("UP"),
                TMT_MEMBER = data.Field<DateTime?>("TMT_MEMBER"),
                DOB = data.Field<DateTime?>("DOB"),
                CREATE_AT = data.Field<DateTime?>("CREATE_AT"),
                STAPEG = data.Field<Int32?>("STAPEG"),
                NM_STAPEG = data.Field<string?>("NM_STAPEG"),
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

                        SetCellValue(rowData, 0, data.TAHUN);
                        SetCellValue(rowData, 1, data.BULAN);
                        SetCellValue(rowData, 2, (indexdata - 6));
                        SetCellValue(rowData, 3, data.SPANO);
                        SetCellValue(rowData, 4, data.POLICYNO);
                        SetCellValue(rowData, 5, data.PARTNERNAME);
                        SetCellValue(rowData, 6, data.PRODUCTNAME);
                        SetCellValue(rowData, 7, data.NOTAS);
                        SetCellValue(rowData, 8, data.TGLSALDO);
                        SetCellValue(rowData, 9, data.MEMBERNO);
                        SetCellValue(rowData, 10, data.NAME);
                        SetCellValue(rowData, 11, data.AKUMULASI_PREMI);
                        SetCellValue(rowData, 12, data.PREMI);
                        SetCellValue(rowData, 13, data.SALDO_AWAL);
                        SetCellValue(rowData, 14, data.BPA2);
                        SetCellValue(rowData, 15, data.COI);
                        SetCellValue(rowData, 16, data.KOMISI);
                        SetCellValue(rowData, 17, data.BPA1);
                        SetCellValue(rowData, 18, data.BPD1);
                        SetCellValue(rowData, 19, data.INV);
                        SetCellValue(rowData, 20, data.BPD2);
                        SetCellValue(rowData, 21, data.SALDO_AKHIR);
                        SetCellValue(rowData, 22, data.UP);
                        SetCellValue(rowData, 23, data.TMT_MEMBER);
                        SetCellValue(rowData, 24, data.DOB);
                        SetCellValue(rowData, 25, data.CREATE_AT);
                        SetCellValue(rowData, 26, data.STAPEG);
                        SetCellValue(rowData, 27, data.NM_STAPEG);
                        SetCellValue(rowData, 28, data.PAYMETH);
                        SetCellValue(rowData, 29, data.PRODCODE);
                        SetCellValue(rowData, 30, data.PRODUCT_NAME);
                        SetCellValue(rowData, 31, data.ENTITY_ID);
                        SetCellValue(rowData, 32, data.REPORTING_DATE);
                        SetCellValue(rowData, 33, data.POLICYNO);
                        SetCellValue(rowData, 34, data.NOTAS);
                        SetCellValue(rowData, 35, data.CEDED_FLAG);
                        SetCellValue(rowData, 36, data.M_BEGIN_COV);
                        SetCellValue(rowData, 37, data.M_END_COV);
                        SetCellValue(rowData, 38, data.ICG_ID);
                        SetCellValue(rowData, 39, data.ICG_BEGIN_COV);
                        SetCellValue(rowData, 40, data.ICG_END_COV);
                        SetCellValue(rowData, 41, data.ICG_NB_ID);
                        SetCellValue(rowData, 42, data.NB_BEGIN_COV);
                        SetCellValue(rowData, 43, data.NB_END_COV);
                        SetCellValue(rowData, 44, data.PORTOFOLIO_ID);
                        SetCellValue(rowData, 45, data.CURRENCY_CD);
                        SetCellValue(rowData, 46, data.PV_CSM);
                        SetCellValue(rowData, 47, data.PTF_STATUS);
                        SetCellValue(rowData, 48, data.DERECOGNIZE_DT);
                        SetCellValue(rowData, 49, data.EARNED_PREM);

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
