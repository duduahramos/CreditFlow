using CreditFlow.API.DTOs;
using CreditFlow.API.Utils.Mappers;
using CreditFlow.API.Utils.Services;
using CreditFlow.Core.Common.Extensions;
using CreditFlow.Core.Common.Helpers;
using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditFlow.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ILoginRepository _loginRepository;
    private readonly TokenService _tokenService;
    public AuthController(IUserRepository userRepository, ILoginRepository loginRepository, TokenService tokenService)
    {
        _userRepository = userRepository;
        _loginRepository = loginRepository;
        _tokenService = tokenService;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequestDTO loginRequestDto, CancellationToken cancellationToken)
    {
        if (!loginRequestDto.Username.IsValidUsername() || !loginRequestDto.Password.IsValidPassword())
        {
            return Unauthorized("Username or password invalids.");
        }

        var user = await _userRepository.GetByUsernameAsync(loginRequestDto.Username, cancellationToken);

        if (user == null) return Unauthorized("Username invalid.");

        if (!AuthHelper.VerifyPassword(loginRequestDto.Password, user.PasswordSalt, user.PasswordHash))
        {
            return Unauthorized("Password invalid.");
        }

        var token = await _tokenService.GenerateToken(user);
        var refeshToken = _tokenService.GenerateRefreshToken();

        var login = new Login
        {
            Username = user.Username,
            Token = token,
            RefreshToken = refeshToken
        };

        await _loginRepository.UpdateASync(login, cancellationToken);
        
        return Ok(login.ToDTO());
    }
}
