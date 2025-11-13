using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CaptchaTester.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaptchaController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CaptchaController> _logger;
        private static readonly string captchaUrl = "https://identity-farabi.ephoenix.ir/api/Captcha/GetCaptcha";

        public CaptchaController(IHttpClientFactory httpClientFactory, ILogger<CaptchaController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet("loop")]
        public async Task<IActionResult> StartLoop(int delaySeconds = 3)
        {
            _logger.LogInformation("🚀 شروع ارسال درخواست‌های کپچا... (تا زمانی که متوقف نشود)");

            var http = _httpClientFactory.CreateClient();
            int counter = 0;

            while (true)
            {
                counter++;
                try
                {
                    var response = await http.GetAsync(captchaUrl);

                    if (response.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        _logger.LogWarning($"❌ درخواست {counter} رد شد (429): {body}");
                        return Ok($"❌ محدودیت رسید! درخواست {counter} رد شد.");
                    }

                    _logger.LogInformation($"✅ درخواست {counter} موفق ({(int)response.StatusCode})");

                }
                catch (Exception ex)
                {
                    _logger.LogError($"⚠️ خطا در درخواست {counter}: {ex.Message}");
                }

                await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
            }
        }
    }
}
