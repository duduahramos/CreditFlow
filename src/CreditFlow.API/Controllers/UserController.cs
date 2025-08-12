using System.Text.Json;
using CreditFlow.API.DTOs;
using CreditFlow.API.Utils.Mappers;
using CreditFlow.Core.Application;
using CreditFlow.Core.Common.Extensions;
using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.AWS;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditFlow.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<UserResponseDTO>> Post([FromBody] UserRequestDTO? userRequestDTO, CancellationToken cancellationToken)
    {
        if (userRequestDTO == null) return BadRequest("Request body is required.");

        var user = userRequestDTO.ToEntity();
        
        await _userRepository.SaveAsync(user, cancellationToken);

        return Ok(user.ToResponseDto());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        if (id.IsNullOrEmpty())
            return BadRequest("ID is required.");

        var user = await _userRepository.GetByIdAsync(id);
        
        if (user == null)
            return NotFound("User not exists.");

        var userDTO = user.ToResponseDto();
                
        return Ok(userDTO);
    }
}