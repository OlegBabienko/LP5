using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using lr5.Services; 

namespace Lr5Project.Middlewares
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Передаємо запит далі по конвеєру
            }
            catch (Exception ex)
            {
                // Логування виключення в файл
                string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "logs", "exceptions.txt");
                await File.AppendAllTextAsync(logFilePath, $"{DateTime.Now}: {ex.Message}\n");
                throw; // Перевикидаємо виключення далі
            }
        }
    }
}
