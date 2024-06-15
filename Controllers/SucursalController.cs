using Microsoft.AspNetCore.Mvc;

namespace SucursalesLab.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult SucursalList()
        {
            return View();
        }
    }
}