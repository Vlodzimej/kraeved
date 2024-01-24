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
        /// Получить событие по индектификатору
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

                /// <summary>
        /// Получить список событий по фильтру
        /// </summary>
        /// <param name="name"></param>
        /// <param name="regionId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricalEvent>>> GetHistoricalEvents([FromQuery] string? name, [FromQuery] DateTime? date) 
        {
            IEnumerable<HistoricalEventBrief>? result;
            var filter = new HistoricalEventFilter() { Name = name, Date = date };

            try {
                result = await _kraevedService.GetHistoricalEventsByFilter(filter);
            }

            catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }

            return Ok(result);
        }

        /// <summary>
        /// Добавить событие в БД
        /// </summary>
        /// <param name="geoObject"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> InsertHistoricalEvent(HistoricalEvent historicalEvent)
        {
            HistoricalEvent? result = null;

            try {
                result = await _kraevedService.InsertHistoricalEvent(historicalEvent);
            }

            catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }

            return Ok(result);
        }

        /// <summary>
        /// Удалить событие по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHistocialEvent(int id)
        {
            HistoricalEvent? result = null;

            try {
                result = await _kraevedService.DeleteHistoricalEvent(id);
            }

            catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }

            return Ok(result);
        }

        /// <summary>
        /// Изменить событие
        /// </summary>
        /// <param name="historicalEvent"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ActionResult> UpdateHistoricalEvent([FromBody]HistoricalEvent historicalEvent)
        {
            HistoricalEvent? result = null;

            try {
                result = await _kraevedService.UpdateHistoricalEvent(historicalEvent);
            }
            catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }

            return Ok(result);
        }
    }
}