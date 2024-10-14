using Microsoft.AspNetCore.Mvc;
using System;

namespace lr5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetCookie(string value, DateTime expirationDate)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = expirationDate
            };
            Response.Cookies.Append("MyCookie", value, options);

            return RedirectToAction("CheckCookie");
        }

        public IActionResult CheckCookie()
        {
            //throw new Exception("Це тестова помилка для перевірки логування!");

            var cookieValue = Request.Cookies["MyCookie"];
            if (cookieValue != null)
            {
                ViewBag.CookieValue = cookieValue;
            }
            else
            {
                ViewBag.CookieValue = "Кукі не знайдено.";
            }
            return View();
        }
    }
}
