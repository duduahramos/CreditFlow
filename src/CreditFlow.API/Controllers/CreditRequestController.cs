using CreditFlow.API.Models;
using CreditFlow.API.Utils.Mappers;
using CreditFlow.Core.Domain.Results;
using Microsoft.AspNetCore.Mvc;

namespace CreditFlow.API.Controllers;

public class CreditRequestController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<CreditValidationResult> Post([FromBody] CreditRequestDTO requestDto)
    {
        var request = requestDto.ToEntity();
        
        var result = await 
    }
}