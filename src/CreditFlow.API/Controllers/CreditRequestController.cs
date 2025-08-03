using System.Text.Json;
using System.Text.Json.Serialization;
using CreditFlow.API.Models;
using CreditFlow.API.Utils.Mappers;
using CreditFlow.Core.Application;
using CreditFlow.Core.Domain.Results;
using Microsoft.AspNetCore.Mvc;

namespace CreditFlow.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CreditRequestController : ControllerBase
{
    private readonly CreditRequestValidator _validator;

    public CreditRequestController(CreditRequestValidator validator)
    {
        _validator = validator;
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreditRequestDTO? requestDto, CancellationToken cancellationToken)
    {
        if (requestDto == null) return BadRequest("Request body is required.");

        var request = requestDto.ToEntity();

        var result = await _validator.ValidateAsync(request, cancellationToken);

        return Ok(result);
    }
}