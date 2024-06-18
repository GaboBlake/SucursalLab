using Microsoft.AspNetCore.Mvc;
using SucursalesLab;
using SucursalLab.Entities;
using SucursalLab.Models;

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
        // EmpresaEntity empresa = new EmpresaEntity();
        // empresa.Name="Danone";
        // empresa.Description="Empresa dedicada a la venta de bebidas";

        // this._context.Empresas.Add(empresa);
        // this._context.SaveChanges();

         List<EmpresaModel> list = _context.Empresas.Select(e => new EmpresaModel
         {
            Name=e.Name,
            Description=e.Description

         }).ToList();

        return View(list);
    }

        [HttpGet]
            
        public IActionResult AddEmpresa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmpresa(EmpresaModel model)
        {
              if (ModelState.IsValid)
            {
                EmpresaEntity s = new EmpresaEntity();
                s.Id = model.Id;
                s.Name = model.Name;
                s.Description = model.Description;

                this._context.Empresas.Add(s);
                this._context.SaveChanges();
                return RedirectToAction("EmpresaList");

            }
            return View ();
        }

         [HttpGet]
        public IActionResult DeleteEmpresa(int Id)
        {
            EmpresaEntity empresa = this._context.Empresas.Where(e => e.Id == Id).First();

            if (empresa == null)
            {
                return RedirectToAction("SucursalList","Sucursal");

            }

            EmpresaEntity model = new EmpresaEntity();
            model.Id = empresa.Id;
            model.Name = empresa.Name;
            model.Description=empresa.Description;

            return View (model);
        }

        [HttpPost]
        public IActionResult DeleteEmpresa(EmpresaModel empresaModel)
        {
            bool exists = this._context.Sucursales.Any(a => a.Id == empresaModel.Id);
            if (!exists)
            {
                return View (empresaModel);
            }

            EmpresaEntity empresa = this._context.Empresas.Where (e => e.Id == empresaModel.Id).First();
            empresa.Name = empresaModel.Name;
            empresa.Description=empresaModel.Description;

            this._context.Empresas.Remove(empresa);
            this._context.SaveChanges();

            return RedirectToAction("EmpresaList","Empresa");

            
        }
    }
}