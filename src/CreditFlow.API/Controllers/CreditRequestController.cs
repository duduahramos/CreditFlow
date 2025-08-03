using System.Text.Json;
using System.Text.Json.Serialization;
using CreditFlow.API.Models;
using CreditFlow.API.Utils.Mappers;
using CreditFlow.Core.Application;
using CreditFlow.Core.Domain.Results;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreditFlow.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CreditRequestController : ControllerBase
{
    private readonly CreditRequestValidator _validator;
    private readonly ICreditRequestRepository _creditRequestRepository;

    public CreditRequestController(CreditRequestValidator validator, ICreditRequestRepository creditRequestRepository)
    {
        _validator = validator;
        _creditRequestRepository = creditRequestRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreditRequestDTO? requestDto, CancellationToken cancellationToken)
    {
        if (requestDto == null) return BadRequest("Request body is required.");

        var request = requestDto.ToEntity();
        
        await _creditRequestRepository.SaveAsync(request, cancellationToken);

        return Ok(request.Id);
    }
}