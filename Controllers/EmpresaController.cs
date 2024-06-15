using Microsoft.AspNetCore.Mvc;
using SucursalesLab;

namespace SucursalLab.Controllers
{
    public class EmpresaController : Controller
    {
    private readonly ApplicationDBContext _context;

    public EmpresaController(ApplicationDBContext context)
    {
        _context = context;
    }

    public IActionResult EmpresaList()
    {
        return View();
    }
    
    }
}