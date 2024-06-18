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

        [HttpGet]
        public IActionResult DeleteSucursal(int Id)
        {
            SucursalEntity sucursal = this._context.Sucursales.Where(s => s.Id == Id).First();

            if (sucursal == null)
            {
                return RedirectToAction("SucursalList","Sucursal");

            }

            SucursalModel model = new SucursalModel();
            model.Id = sucursal.Id;
            model.Name = sucursal.Name;
            model.Empresa = sucursal.Empresa;
            model.Location = sucursal.Location;
            model.NumEmpleados = sucursal.NumEmpleados;
            model.Presupuesto = sucursal.Presupuesto;

            return View (model);
        }

        [HttpPost]
        public IActionResult DeleteSucursal(SucursalModel sucursalModel)
        {
            bool exists = this._context.Sucursales.Any(a => a.Id == sucursalModel.Id);
            if (!exists)
            {
                return View (sucursalModel);
            }

            SucursalEntity sucursal = this._context.Sucursales.Where (s => s.Id == sucursalModel.Id).First();
            sucursal.Name = sucursalModel.Name;
            sucursal.Empresa = sucursalModel.Empresa;
            sucursal.Location = sucursalModel.Location;
            sucursal.NumEmpleados= sucursalModel.NumEmpleados;
            sucursal.Presupuesto= sucursalModel.Presupuesto;

            this._context.Sucursales.Remove(sucursal);
            this._context.SaveChanges();

            return RedirectToAction("SucursalList","Sucursal");

            
        }

        [HttpGet]
        public IActionResult EditSucursal(int Id)
        {
            SucursalEntity sucursal = this._context.Sucursales.Where(s => s.Id == Id).First();

            if (sucursal==null)
            {
                return RedirectToAction("SucursalList","Sucursal");
            }

            SucursalModel model = new SucursalModel();
            model.Id = sucursal.Id;
            model.Name = sucursal.Name;
            model.Empresa = sucursal.Empresa;
            model.Location = sucursal.Location;
            model.NumEmpleados = sucursal.NumEmpleados;
            model.Presupuesto=sucursal.Presupuesto;

            return View(model);

        }

        [HttpPost]
        public IActionResult EditSucursal(SucursalModel sucursalModel)
        {
            SucursalEntity sucursal =this._context.Sucursales.Where(s=>s.Id == sucursalModel.Id).First();

            if(sucursalModel == null)
            {
                return RedirectToAction("SucursalModel");
            }

            sucursal.Name = sucursalModel.Name;
            sucursal.Empresa = sucursalModel.Empresa;
            sucursal.Location = sucursal.Location;
            sucursal.NumEmpleados= sucursal.NumEmpleados;
            sucursal.Presupuesto = sucursal.Presupuesto;

            this._context.Sucursales.Update(sucursal);
            this._context.SaveChanges();

            return RedirectToAction("SucursalList","Sucursal");
        }
    }
}