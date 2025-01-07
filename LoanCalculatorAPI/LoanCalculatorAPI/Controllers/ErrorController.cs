using Microsoft.AspNetCore.Mvc;

namespace LoanCalculatorAPI.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    [HttpGet("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        return Problem();
    }
}