using System.Text.Json;
using CreditFlow.API.DTOs;
using CreditFlow.API.Utils.Mappers;
using CreditFlow.Core.Application;
using CreditFlow.Core.Common.Extensions;
using CreditFlow.Infrastructure.AWS;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditFlow.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class CreditRequestController : ControllerBase
{
    private readonly CreditRequestValidator _validator;
    private readonly ICreditRequestRepository _creditRequestRepository;
    private readonly SQSManager _sqsManager;
    private readonly string? _sqsUrl;

    public CreditRequestController(
        CreditRequestValidator validator,
        ICreditRequestRepository creditRequestRepository,
        SQSManager sqsManager,
        IConfiguration configuration)
    {
        _validator = validator;
        _creditRequestRepository = creditRequestRepository;
        _sqsManager = sqsManager;
        _sqsUrl = configuration["SQS:CreditRequest"];
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreditRequestDTO? requestDto, CancellationToken cancellationToken)
    {
        if (requestDto == null) return BadRequest("Request body is required.");

        var request = requestDto.ToEntity();
        
        await _creditRequestRepository.SaveAsync(request, cancellationToken);

        await _sqsManager.SendMessageAsync(_sqsUrl, JsonSerializer.Serialize(request));

        return Ok(request.Id);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        if (id.IsNullOrEmpty())
            return BadRequest("ID is required.");

        var creditRequest = await _creditRequestRepository.GetByIdAsync(id);
        
        if (creditRequest == null)
            return NotFound("Credit request not exists.");

        var creditRequestDTO = creditRequest.ToDto();
                
        return Ok(creditRequestDTO);
    }
}