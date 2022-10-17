using Microsoft.AspNetCore.Mvc;

namespace KütüphaneSistemi.Controllers
{
    public class AuthController : Controller
    {     
        public IActionResult Login()
        {
            return View();
        }
    }
}
