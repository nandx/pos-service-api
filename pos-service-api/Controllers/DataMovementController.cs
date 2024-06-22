using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pos_service_api.Dto;
using pos_service_api.Models;
using pos_service_api.Services;
using System.Collections.Generic;

namespace pos_service_api.Controllers
{
    [Route("datamovement")]
    [ApiController]
    public class DataMovementController : ControllerBase
    {
        private readonly DataMovementService _dataMovementService;

        public DataMovementController(DataMovementService dataMovementService)
        {
            _dataMovementService = dataMovementService;
        }

        [HttpGet("search")]
        public IActionResult Search(int tahun, int bulan)
        {
            List<MovementDto> list = _dataMovementService.Search(tahun, bulan);
            return Ok(list);
        }

        [HttpGet("searchhibernate")]
        public IActionResult SearchHibernate(int tahun, int bulan)
        {
            IList<DatamovementPerproduct> list = _dataMovementService.SearchHibernate(tahun, bulan);
            return Ok(list);
        }
    }
}
