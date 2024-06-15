using Microsoft.AspNetCore.Mvc;
using SucursalLab.Models;

namespace SucursalesLab.Controllers
{
    public class SucursalController : Controller
    {
    private readonly ApplicationDBContext _context;

    public SucursalController(ApplicationDBContext context)
    {
        _context = context;
    }
        public IActionResult SucursalList()
        {
            // SucursalEntity sucursal = new SucursalEntity();
            // sucursal.Name = "García";
            // sucursal.Empresa = "Danone";
            // sucursal.Location = "Av. Lincoln #6158";
            // sucursal.NumEmpleados=48;
            // sucursal.Presupuesto=192003;

            // this._context.Sucursales.Add(sucursal);
            // this._context.SaveChanges();

            List<SucursalModel> list = _context.Sucursales.Select(s => new SucursalModel
            {
                Id = s.Id,
                Name = s.Name,
                Empresa=s.Empresa,
                Location=s.Location,
                NumEmpleados=s.NumEmpleados,
                Presupuesto=s.Presupuesto
            }).ToList();
            

            return View(list);
        }
    }
}