using Microsoft.AspNetCore.Mvc;

namespace CapExTSVS.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
