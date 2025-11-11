using Microsoft.AspNetCore.Mvc;
using StreamAddFee.IntervalService;

[ApiController]
[Route("api/[controller]")]
public class IntervalsController : ControllerBase
{
    private readonly IntervalService _service;

    public IntervalsController(IntervalService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult AddInterval(Interval interval)
    {
        if (_service.TryAddInterval(interval))
            return Ok(new { message = "Interval added successfully." });
        else
            return Conflict(new { message = "Overlap detected. Interval rejected." });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }
}