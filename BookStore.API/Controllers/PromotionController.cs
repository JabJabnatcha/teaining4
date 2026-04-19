using Microsoft.AspNetCore.Mvc;
using BookStore.Application.Services;
using BookStore.Application.DTOs;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PromotionController : ControllerBase
{
    private readonly PromotionService _service;

    public PromotionController(PromotionService service)
    {
        _service = service;
    }

    [HttpPost("check")]
    public IActionResult Check([FromBody] CheckPromotionRequest request)
    {
        var result = _service.Check(request);
        return Ok(result);
    }
}