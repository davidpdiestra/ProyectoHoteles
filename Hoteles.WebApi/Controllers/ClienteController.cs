using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
