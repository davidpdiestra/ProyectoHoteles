using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
