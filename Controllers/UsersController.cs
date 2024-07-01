using KraevedAPI.Models;
using KraevedAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace KraevedAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize] 
    public class UsersController : ControllerBase
    {
        private readonly IKraevedService _kraevedService;
        private readonly ILogger<UsersController> _logger; // Добавление логгера

        public UsersController(IKraevedService kraevedService, ILogger<UsersController> logger)
        {
            _kraevedService = kraevedService;
            _logger = logger; // Инициализация логгера
        }

        [HttpGet("current")]
        public async Task<ActionResult> GetCurrentUser()
        {
            try
            {
                var result = await _kraevedService.GetCurrentUserInfo(); // Исправление имени метода
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting the current user."); // Логгирование ошибки
                return StatusCode(500, new { ex.Message }); // Возвращение статуса 500 для внутренних ошибок сервера
            }
        }

        [HttpPatch("current")]
        public async Task<ActionResult> PatchUser([FromBody] UserInDto userInDto)
        {
            try
            {
                var result = await _kraevedService.PatchUser(userInDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while patching the user."); // Логгирование ошибки
                return StatusCode(500, new { ex.Message }); // Возвращение статуса 500 для внутренних ошибок сервера
            }
        }
    }
}
