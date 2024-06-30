using KraevedAPI.Models;
using KraevedAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace KraevedAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorization]
    public class UsersController : ControllerBase
    {
        private readonly IKraevedService _kraevedService;
        public UsersController(IKraevedService kraevedService)
        {
            _kraevedService = kraevedService;
        }

        [HttpGet("current")]
        public async Task<ActionResult> GetCurrentUser() {
            UserOutDto? result = null;

            try {
                result = await _kraevedService.GetCurrentUserInfd();
            }

            catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }

            return Ok(result);
        }

        [HttpPatch("current")]
        public async Task<ActionResult> PatchUser(UserInDto userInDto) {
            UserOutDto? result = null;

            try {
                result = await _kraevedService.PatchUser(userInDto);
            }

            catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }

            return Ok(result);
        }
    }

    internal class AuthorizationAttribute : Attribute
    {
    }
}