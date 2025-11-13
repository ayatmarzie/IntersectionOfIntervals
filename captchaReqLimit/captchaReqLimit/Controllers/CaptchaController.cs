using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace CaptchaTester.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaptchaController : ControllerBase
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = Timeout.InfiniteTimeSpan
        };

        private readonly ILogger<CaptchaController> _logger;
        private readonly CaptchaResultStore _store;
        private static readonly string captchaUrl = "https://identity-farabi.ephoenix.ir/api/Captcha/GetCaptcha";

        public CaptchaController(ILogger<CaptchaController> logger, CaptchaResultStore store)
        {
            _logger = logger;
            _store = store;
        }

        [HttpGet("loop")]
        public async Task<IActionResult> StartLoop(int delaySeconds = 3)
        {
            _logger.LogInformation(" Starting Captcha requests loop...");
            _store.Add("Loop started...");

            int counter = 0;
            var random = new Random();

            _ = Task.Run(async () =>
            {
                while (true)
                {
                    counter++;
                    try
                    {
                        var response = await _httpClient.GetAsync(captchaUrl);
                        var body = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == HttpStatusCode.TooManyRequests)
                        {
                            string msg = $" Request {counter} rejected (429): {body}";
                            _logger.LogWarning(msg);
                            _store.Add(msg);
                        }
                        else
                        {
                            // ✅ Parse and store the full JSON (Postman style)
                            try
                            {
                                using var doc = JsonDocument.Parse(body);
                                var formatted = JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
                                string msg = $" Request {counter} OK (200):\n{formatted}";
                                _logger.LogInformation(msg);
                                _store.Add(formatted);
                            }
                            catch
                            {
                                string msg = $"Request {counter} OK (200, raw): {body}";
                                _logger.LogInformation(msg);
                                _store.Add(msg);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string msg = $" Error in request {counter}: {ex.Message}";
                        _logger.LogError(msg);
                        _store.Add(msg);
                    }

                    int actualDelay = delaySeconds * 1000 + random.Next(500, 1500);
                    await Task.Delay(actualDelay);
                }
            });

            return Ok("Loop started in background. Visit /api/captcha/responses to view raw responses.");
        }

        [HttpGet("responses")]
        public IActionResult GetResponses()
        {
            var logs = _store.GetAll();
            return new JsonResult(logs);
        }
    }
}
