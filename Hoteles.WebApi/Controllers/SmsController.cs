using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    public class SmsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
