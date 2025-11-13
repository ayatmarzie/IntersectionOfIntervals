using Microsoft.AspNetCore.Mvc;

namespace IntervalApi.Controllers;

[ApiController]
[Route("api/intervals")]
public class IntervalsController : ControllerBase
{
    public record IntervalRequest(float[] Interval1, float[] Interval2);
    public record IntervalResponse(float[]? Intersection, string? Error = null);

    [HttpPost("intersect")]
    public IActionResult Intersect([FromBody] IntervalRequest request)
    {
        // ---- 1. Validate payload ------------------------------------------------
        if (request.Interval1 == null || request.Interval1.Length != 2 ||
            request.Interval2 == null || request.Interval2.Length != 2)
        {
            return BadRequest(new IntervalResponse(null,
                "Both intervals must be supplied as arrays of exactly two floats, e.g. { \"interval1\": [1.0, 3.5], \"interval2\": [2.0, 4.0] }"));
        }

        // ---- 2. Normalise each interval (x <= y) -------------------------------
        var (x1, y1) = Normalise(request.Interval1[0], request.Interval1[1]);
        var (x2, y2) = Normalise(request.Interval2[0], request.Interval2[1]);

        // ---- 3. Compute intersection -------------------------------------------
        float start = Math.Max(x1, x2);
        float end = Math.Min(y1, y2);

        if (start > end)
        {
            return Ok(new IntervalResponse(null, "No intersection between these two intervals!"));
        }

        return Ok(new IntervalResponse(new[] { start, end }));
    }

    private static (float x, float y) Normalise(float a, float b)
    {
        return a <= b ? (a, b) : (b, a);
    }
}