using CreditFlow.API.DTOs;
using CreditFlow.Core.Common.Extensions;
using CreditFlow.Core.Common.Helpers;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditFlow.API.Controllers;

[Route("api/v1/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequestDTO loginRequestDto, CancellationToken cancellationToken)
    {
        if (!loginRequestDto.Username.IsValidUsername() || !loginRequestDto.Password.IsValidPassword())
        {
            return Unauthorized("Username or password invalids.");
        }

        var user = await _userRepository.GetByUsernameAsync(loginRequestDto.Username, cancellationToken);

        if (!AuthHelper.VerifyPassword(loginRequestDto.Password, user.PasswordSalt, user.PasswordHash))
        {
            return Unauthorized("Password invalid.");
        }

        return Ok();
    }
}
