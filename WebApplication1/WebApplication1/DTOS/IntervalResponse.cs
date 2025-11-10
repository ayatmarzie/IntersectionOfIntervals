namespace IntervalApi.Controllers;


    public record IntervalResponse(intervalPoint? Intersection, string? Error = null);
