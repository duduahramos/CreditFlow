using System.Text.Json;
using CreditFlow.API.DTOs;
using CreditFlow.API.Utils.Mappers;
using CreditFlow.Core.Application;
using CreditFlow.Core.Common.Extensions;
using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.AWS;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreditFlow.API.Controllers;

[ApiController]
[Route("api/v1/credit-request")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserDTO? userDTO, CancellationToken cancellationToken)
    {
        if (userDTO == null) return BadRequest("Request body is required.");

        var user = userDTO.ToEntity();
        
        await _userRepository.SaveAsync(user, cancellationToken);

        return Ok(user.Id);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        if (id.IsNullOrEmpty())
            return BadRequest("ID is required.");

        var user = await _userRepository.GetByIdAsync(id);
        
        if (user == null)
            return NotFound("Credit request not exists.");

        var userDTO = user.ToDto();
                
        return Ok(userDTO);
    }
}