using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NPOI.HPSF;
using pos_service_api.Dto;
using pos_service_api.Models;
using pos_service_api.Services;
using System.IO.Compression;
using System.Text.Json.Nodes;

namespace pos_service_api.Controllers
{
    [ApiController]
    [Route("cutoff-report")]
    public class CutoffReportController : ControllerBase
    {
        private readonly CutoffReportTaspenSaveService _cutoffReportTaspenSaveService;
        private readonly CutoffReportCreditLifeService _cutoffReportCreditLifeService;
        private readonly CutoffReportTGASarihusadaService _cutoffReportTGASarihusadaService;
        private readonly CutoffReportPerPolicyService _cutoffReportPerPolicyService;

        public CutoffReportController(
            CutoffReportTaspenSaveService cutoffReportTaspenSaveService, CutoffReportCreditLifeService cutoffReportCreditLifeService,
            CutoffReportTGASarihusadaService cutoffReportTGASarihusadaService, CutoffReportPerPolicyService cutoffReportPerPolicyService)
        {
            _cutoffReportTaspenSaveService = cutoffReportTaspenSaveService;
            _cutoffReportCreditLifeService = cutoffReportCreditLifeService;
            _cutoffReportTGASarihusadaService = cutoffReportTGASarihusadaService;
            _cutoffReportPerPolicyService = cutoffReportPerPolicyService;
        }

        [HttpGet("download-taspen-save")]
        public IActionResult DownloadTaspenSave(int tahun, int bulan)
        {
            Console.WriteLine("DOWNLOAD TASPEN SAVE - START " + tahun + "-" + bulan + " ---> " + DateTime.Now);
            byte[] fileBytes = _cutoffReportTaspenSaveService.DownloadCutoffReportTaspenSave(tahun, bulan);
            Console.WriteLine("DOWNLOAD TASPEN SAVE - END " + tahun + "-" + bulan + " ---> " + DateTime.Now);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report Cadangan Taspen Save " + tahun + "-" + bulan + ".xlsx");
        }

        [HttpGet("download-credit-life")]
        public IActionResult DownloadCreditLife(int tahun, int bulan)
        {
            Console.WriteLine("DOWNLOAD CREDIT LIFE - START " + tahun + "-" + bulan + " ---> " + DateTime.Now);
            byte[] fileBytes = _cutoffReportCreditLifeService.DownloadCutoffReportCreditLife(tahun, bulan);
            Console.WriteLine("DOWNLOAD CREDIT LIFE - END " + tahun + "-" + bulan + " ---> " + DateTime.Now);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report Cadangan Credit Life " + tahun + "-" + bulan + ".xlsx");
        }

        [HttpGet("download-tga-sarihusada")]
        public IActionResult DownloadTGASariHusada(int tahun, int bulan)
        {
            Console.WriteLine("DOWNLOAD TGA SARI HUSADA - START " + tahun + "-" + bulan + " ---> " + DateTime.Now);
            byte[] fileBytes = _cutoffReportTGASarihusadaService.DownloadCutoffReportTGASarihusada(tahun, bulan);
            Console.WriteLine("DOWNLOAD TGA SARI HUSADA - END " + tahun + "-" + bulan + " ---> " + DateTime.Now);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report Cadangan TGA SARIHUSADA " + tahun + "-" + bulan + ".xlsx");
        }


        [HttpGet("search-cadangan-per-policy")]
        public IActionResult SearchCadanganPerPolicy(int tahun, int bulan, string? policyno, string? productname, string? partnername)
        {
            Console.WriteLine("SEARCH CADANGAN PER POLICY - START " + tahun + "-" + bulan + " ---> " + DateTime.Now);
            List<PolicyDto> list  = _cutoffReportPerPolicyService.SearchCadanganPerPolis(tahun, bulan, policyno, productname, partnername);
            Console.WriteLine("SearchCadanganPerPolicy ----> " + list);
            return Ok(list);
        }

        [HttpGet("download-cadangan-per-policy")]
        public IActionResult DownloadCadanganPerPolicy(int tahun, int bulan, string? policyno, string? productname, string? partnername)
        {
            Console.WriteLine("DOWNLOAD CADANGAN PER POLICY - START " + tahun + "-" + bulan + " ---> " + DateTime.Now);
            MemoryStream memoryStream = _cutoffReportPerPolicyService.DownloadCadanganPerPolicy(tahun, bulan, policyno, productname, partnername);
            return File(memoryStream.ToArray(), "application/octet-stream", "Report Cadangan Per Polis.zip");
        }

    }
}
