using CreditFlow.API.Models;
using CreditFlow.Core.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditFlow.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDTO loginRequestDto, CancellationToken cancellationToken)
        {
            if (!loginRequestDto.Username.IsValidUsername() || !loginRequestDto.Password.IsValidPassword())
            {
                return Unauthorized("Username or password invalids.");
            }

            return Ok();
        }
    }
}
