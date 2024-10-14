using Microsoft.AspNetCore.Mvc;
using lr5.Services;

namespace Lr5Project.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(string value, DateTime expiryDate)
        {
            // Записуємо значення в Cookies з вказаною датою старіння
            CookieOptions options = new CookieOptions
            {
                Expires = expiryDate
            };
            Response.Cookies.Append("CustomValue", value, options);

            return RedirectToAction("CheckCookie");
        }

        public IActionResult CheckCookie()
        {
            // Перевіряємо наявність значення в Cookies
            string cookieValue = Request.Cookies["CustomValue"];
            if (cookieValue != null)
            {
                ViewBag.Value = cookieValue;
                return View("CookieFound");
            }
            return View("CookieNotFound");
        }
    }
}
