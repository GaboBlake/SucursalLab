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
    
    }
}