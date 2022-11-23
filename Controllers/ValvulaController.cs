using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValveSizing.Models;
using ValveSizing.Models.ViewModels;

namespace ValveSizing.Controllers
{
    public class ValvulaController : Controller
    {
        private readonly ValvulasContext _context;
        public ValvulaController(ValvulasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var valvulas = _context.Valvulas.Include(b => b.Id);
            return View(await valvulas.ToListAsync());
        }

        //GET: Valvulas/
        public IActionResult Create()
        {
            ViewData["Valvulas"] = new SelectList(_context.Valvulas, "ValvulaId", "Descripcion");
            return View();
        }
        //POST: Valvulas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ValvulaViewModel model)
        {
            if (ModelState.IsValid)
            {
                float diametroFloat = model.Diametro ^ 2;
                float area = (float)(diametroFloat * Math.PI / 4);
                float salida = (float)(diametroFloat / area);

                var valvula = new Valvula()
                {
                    Descripcion = model.Descripcion,
                    Caudal = model.Caudal,
                    Diametro = model.Diametro,
                    Area = area,
                    VSalida = salida
                };
                _context.Add(valvula);
                await _context.SaveChangesAsync();
                if (model.FechaCreacion == null)
                {
                    model.FechaCreacion = DateTime.Now;
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["Valvulas"] = new SelectList(_context.Valvulas, "Descripcion", "Caudal", "Diametro");
            return View(model);
        }
    }
}
