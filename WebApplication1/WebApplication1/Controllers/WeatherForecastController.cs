using Microsoft.AspNetCore.Mvc;
using static IntervalApi.Controllers.IntervalsController;

namespace IntervalApi.Controllers;

[ApiController]
[Route("api/intervals")]
public class IntervalsController : ControllerBase
{
    public record intervalPoint(float x,float y);
    public record IntervalRequest(intervalPoint Interval1, intervalPoint Interval2);
    public record IntervalResponse(intervalPoint? Intersection, string? Error = null);


    [HttpPost("intersect")]
    public IActionResult Intersect([FromBody] IntervalRequest request)
    {
      

        // ---- 2. Normalise each interval (x <= y) -------------------------------
        var (x1, y1) = Normalise(request.Interval1);
        var (x2, y2) = Normalise(request.Interval2);

        // ---- 3. Compute intersection -------------------------------------------
        float start = Math.Max(x1, x2);
        float end = Math.Min(y1, y2);

        if (start > end)
        {
            return BadRequest(new IntervalResponse(null, "No intersection between these two intervals!"));
        }

        return Ok(new IntervalResponse(new intervalPoint(start, end)));
    }

    [HttpPost("intersect2")]
    public IntervalResponse Intersect2([FromBody] IntervalRequest request)
    {


        // ---- 2. Normalise each interval (x <= y) -------------------------------
        var (x1, y1) = Normalise(request.Interval1);
        var (x2, y2) = Normalise(request.Interval2);

        // ---- 3. Compute intersection -------------------------------------------
        float start = Math.Max(x1, x2);
        float end = Math.Min(y1, y2);

        if (start > end)
        {
            return new IntervalResponse(null, "No intersection between these two intervals!");
        }

        return new IntervalResponse(new intervalPoint(start, end));
    }

    private static intervalPoint   Normalise(intervalPoint intervalPoint)
    {
        return intervalPoint.x <= intervalPoint.y ? intervalPoint :new intervalPoint( intervalPoint.x, intervalPoint.y) ;
    }
}