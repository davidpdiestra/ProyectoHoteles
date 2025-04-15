using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    public class HabitacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
