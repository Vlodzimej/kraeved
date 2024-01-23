using KraevedAPI.ClassObjects;
using KraevedAPI.Core;
using KraevedAPI.Models;
using KraevedAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace KraevedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricalEventsController : ControllerBase
    {
        private readonly IKraevedService _kraevedService;
        public HistoricalEventsController(IKraevedService kraevedService)
        {
            _kraevedService = kraevedService;
        }

                /// <summary>
        /// Получить гео-объект по индектификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricalEvent?>> GetGeoHistoricalEventById(int id)
        {
            HistoricalEvent? result = null;
            try {
                result = await _kraevedService.GetHistoricalEventById(id);
                if(result == null) {
                    return BadRequest("Не найдено");
                }
            }
            catch(Exception ex) {
                return BadRequest(new { ex });
            }
            return Ok(result);
        }
    }
}