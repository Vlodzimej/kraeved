using KraevedAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace KraevedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IKraevedService _kraevedService;
        public AuthController(IKraevedService kraevedService)
        {
            _kraevedService = kraevedService;
        }
        [HttpPost]
        public async Task<ActionResult> SendSms(String message)
        {
            String? result = null;
            try {
                result = await _kraevedService.SendSms(message);
            }

            catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }

            return Ok(result);
            
        }
    }
}