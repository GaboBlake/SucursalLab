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

        [HttpGet]
            
        public IActionResult AddSucursal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSucursal(SucursalModel model)
        {
            if (ModelState.IsValid)
            {
                SucursalEntity s = new SucursalEntity();
                s.Id = model.Id;
                s.Name = model.Name;
                s.Empresa = model.Empresa;
                s.Location = model.Location;
                s.NumEmpleados = model.NumEmpleados;
                s.Presupuesto = model.Presupuesto;

                this._context.Sucursales.Add(s);
                this._context.SaveChanges();
                return RedirectToAction("SucursalList");

            }
            return View ();
        }
    }
}