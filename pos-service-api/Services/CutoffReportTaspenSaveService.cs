using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using pos_service_api.Models;
using System.Data;

namespace pos_service_api.Services
{
    public class CutoffReportTaspenSaveService : CommonService
    {
        public CutoffReportTaspenSaveService(PosDbContext context) : base(context)
        {
        }

        public byte[] DownloadCutoffReportTaspenSave(int tahun, int bulan)
        {
            string fileName = @"TemplateReport/template_report_cadangan_taspensave.xlsx";
            byte[] excelFileBytes = System.IO.File.ReadAllBytes(fileName);

            var dataTable = getDataTable("SP_RPT_CUTOFF_TASPENSAVE", tahun, bulan);

            Console.WriteLine("Mapping DataTable to ListData ---> " + DateTime.Now);
            var listdata = dataTable.AsEnumerable().Select(data => new
            {
                TAHUN = data.Field<int>("TAHUN"),
                BULAN = data.Field<int>("BULAN"),
                SPANO = data.Field<Int64>("SPANO"),
                POLICYNO = data.Field<string?>("POLICYNO"),
                PARTNERNAME = data.Field<string?>("PARTNERNAME"),
                PRODUCTNAME = data.Field<string?>("PRODUCTNAME"),
                NAMA = data.Field<string?>("NAMA"),
                NOTAS = data.Field<string?>("NOTAS"),
                TGLSALDO = data.Field<DateTime?>("TGLSALDO"),
                IDMEMBER = data.Field<Int64>("IDMEMBER"),
                AKUMULASIPREMI = data.Field<Double?>("AKUMULASIPREMI"),
                PREMI = data.Field<Double?>("PREMI"),
                SALDOAWAL = data.Field<Double>("SALDOAWAL"),
                BPA2 = data.Field<Double?>("BPA2"),
                COI = data.Field<Double?>("COI"),
                KOMISI = data.Field<Double?>("KOMISI"),
                BPA1 = data.Field<Double?>("BPA1"),
                BPD1 = data.Field<Double?>("BPD1"),
                INVESTMENT = data.Field<Double?>("INVESTMENT"),
                BPD2 = data.Field<Double?>("BPD2"),
                SALDOAKHIR = data.Field<Double?>("SALDOAKHIR"),
                SALDO_PIUTANG_INVOICE = data.Field<Double?>("SALDO_PIUTANG_INVOICE"),
                SALDOAKHIR_FORECAST = data.Field<Double?>("SALDOAKHIR_FORECAST"),
                UP = data.Field<Double?>("UP"),
                TMTMEMBER = data.Field<DateTime?>("TMTMEMBER"),
                DOB = data.Field<DateTime?>("DOB"),
                CREATEAT = data.Field<DateTime?>("CREATEAT"),
                STAPEG = data.Field<Int32?>("STAPEG"),
                NM_STAPEG = data.Field<string?>("NM_STAPEG"),
                THN_SALDO = data.Field<Int32?>("THN_SALDO"),
                BLN_SALDO = data.Field<Int32?>("BLN_SALDO"),
                PREMI_FORECAST = data.Field<Double?>("PREMI_FORECAST"),
                PREMI_SALDO = data.Field<Double?>("PREMI_SALDO"),
                PREMI_ADJUSTMENT = data.Field<Double?>("PREMI_ADJUSTMENT"),
                TOPUP_ADJUSTMENT = data.Field<Double?>("TOPUP_ADJUSTMENT"),
                BALANCE_ADJUSTMENT = data.Field<Double?>("BALANCE_ADJUSTMENT"),
                WITHDRAW = data.Field<Double?>("WITHDRAW"),
                PAYMETH = data.Field<string?>("PAYMETH"),
                PRODCODE = data.Field<int>("PRODCODE"),
                PRODUCT_NAME = data.Field<string?>("PRODUCT_NAME"),
                ENTITY_ID = data.Field<string>("ENTITY_ID"),
                REPORTING_DATE = data.Field<string?>("REPORTING_DATE"),
                CEDED_FLAG = data.Field<string?>("CEDED_FLAG"),
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
                        SetCellValue(rowData, 2, indexdata - 6);
                        SetCellValue(rowData, 3, data.SPANO);
                        SetCellValue(rowData, 4, data.POLICYNO);
                        SetCellValue(rowData, 5, data.PARTNERNAME);
                        SetCellValue(rowData, 6, data.PRODUCTNAME);
                        SetCellValue(rowData, 7, data.NOTAS);
                        SetCellValue(rowData, 8, data.TGLSALDO);
                        SetCellValue(rowData, 9, data.IDMEMBER);
                        SetCellValue(rowData, 10, data.NAMA);
                        SetCellValue(rowData, 11, data.AKUMULASIPREMI);
                        SetCellValue(rowData, 12, data.PREMI);
                        SetCellValue(rowData, 13, data.SALDOAWAL);
                        SetCellValue(rowData, 14, data.BPA2);
                        SetCellValue(rowData, 15, data.COI);
                        SetCellValue(rowData, 16, data.KOMISI);
                        SetCellValue(rowData, 17, data.BPA1);
                        SetCellValue(rowData, 18, data.BPD1);
                        SetCellValue(rowData, 19, data.INVESTMENT);
                        SetCellValue(rowData, 20, data.BPD2);
                        SetCellValue(rowData, 21, data.SALDOAKHIR);
                        SetCellValue(rowData, 22, data.SALDO_PIUTANG_INVOICE);
                        SetCellValue(rowData, 23, data.SALDOAKHIR_FORECAST);
                        SetCellValue(rowData, 24, data.UP);
                        SetCellValue(rowData, 25, data.TMTMEMBER);
                        SetCellValue(rowData, 28, data.DOB);
                        SetCellValue(rowData, 29, data.CREATEAT);
                        SetCellValue(rowData, 30, data.STAPEG);
                        SetCellValue(rowData, 31, data.NM_STAPEG);
                        SetCellValue(rowData, 32, data.THN_SALDO);
                        SetCellValue(rowData, 33, data.BLN_SALDO);
                        SetCellValue(rowData, 34, data.PREMI_FORECAST);
                        SetCellValue(rowData, 35, data.PREMI_SALDO);
                        SetCellValue(rowData, 36, data.PREMI_ADJUSTMENT);
                        SetCellValue(rowData, 37, data.TOPUP_ADJUSTMENT);
                        SetCellValue(rowData, 38, data.BALANCE_ADJUSTMENT);
                        SetCellValue(rowData, 39, data.WITHDRAW);
                        SetCellValue(rowData, 40, data.PAYMETH);
                        SetCellValue(rowData, 41, data.PRODCODE);
                        SetCellValue(rowData, 42, data.PRODUCT_NAME);
                        SetCellValue(rowData, 43, data.ENTITY_ID);
                        SetCellValue(rowData, 44, data.REPORTING_DATE);
                        SetCellValue(rowData, 45, data.POLICYNO);
                        SetCellValue(rowData, 46, data.NOTAS);
                        SetCellValue(rowData, 47, data.CEDED_FLAG);
                        SetCellValue(rowData, 48, data.M_BEGIN_COV);
                        SetCellValue(rowData, 49, data.M_END_COV);
                        SetCellValue(rowData, 50, data.ICG_ID);
                        SetCellValue(rowData, 51, data.ICG_BEGIN_COV);
                        SetCellValue(rowData, 52, data.ICG_END_COV);
                        SetCellValue(rowData, 53, data.ICG_NB_ID);
                        SetCellValue(rowData, 54, data.NB_BEGIN_COV);
                        SetCellValue(rowData, 55, data.NB_END_COV);
                        SetCellValue(rowData, 56, data.PORTOFOLIO_ID);
                        SetCellValue(rowData, 57, data.CURRENCY_CD);
                        SetCellValue(rowData, 58, data.PV_CSM);
                        SetCellValue(rowData, 59, data.PTF_STATUS);
                        SetCellValue(rowData, 60, data.DERECOGNIZE_DT);
                        SetCellValue(rowData, 61, data.EARNED_PREM);

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
