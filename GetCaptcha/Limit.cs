using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;



// مقدار آدرس کپچا
string captchaUrl = "https://identity-farabi.ephoenix.ir/api/Captcha/GetCaptcha";

// تعداد درخواست‌هایی که می‌خوای امتحان کنه
int totalRequests = 100;

// فاصله بین درخواست‌ها بر حسب میلی‌ثانیه (مثلاً 1000 یعنی هر 1 ثانیه)
int delayMs = 1000;



// وقتی اپ اجرا شد، به‌صورت خودکار شروع کنه تست کردن
_ = Task.Run(async () =>
{
    Console.WriteLine("start!");
    var http = new HttpClient();
    int successCount = 0;

    for (int i = 1; i <= totalRequests; i++)
    {
        try
        {
            var response = await http.GetAsync(captchaUrl);

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                var body = await response.Content.ReadAsStringAsync();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"429): {body}");
                Console.ResetColor();
                Console.WriteLine($"\n limite = {successCount} ");
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"success {i}  ({(int)response.StatusCode})");
                Console.ResetColor();
                successCount++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error  {i}: {ex.Message}");
        }

        await Task.Delay(delayMs);
    }

    Console.WriteLine("\n end");
});

app.Run();
