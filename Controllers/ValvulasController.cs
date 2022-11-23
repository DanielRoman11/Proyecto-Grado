using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using ValveSizing.Models;

namespace ValveSizing.Controllers
{
    public class ValvulasController : Controller
    {
        private readonly ValvulasContext _context;

        public ValvulasController(ValvulasContext context)
        {
            _context = context;
        }

        // GET: Valvulas
        public async Task<IActionResult> Index() => await NewMethod();

        private async Task<IActionResult> NewMethod()
        {
            return View(await _context.Valvulas.ToListAsync());
        }

        // GET: Valvulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Valvulas == null)
            {
                return NotFound();
            }

            var valvula = await _context.Valvulas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valvula == null)
            {
                return NotFound();
            }

            return View(valvula);
        }

        // GET: Valvulas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Valvulas/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Valvula model)
        {
            if (ModelState.IsValid)
            {
                double enMetros = ((model.Diametro * 25.0) / 1000);
                double area = (Math.Pow(enMetros, 2) * (Math.PI / 4.0));

                var valvula = new Valvula()
                {
                    FechaCreacion = (DateTime)model.FechaCreacion,
                    Descripcion = model.Descripcion,
                    Caudal = model.Caudal,
                    Diametro = model.Diametro,
                    Area = area,
                    VSalida = enMetros / area
                };
                _context.Add(valvula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Valvulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Valvulas == null)
            {
                return NotFound();
            }

            var valvula = await _context.Valvulas.FindAsync(id);
            if (valvula == null)
            {
                return NotFound();
            }
            return View(valvula);
        }

        // POST: Valvulas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaCreacion,Descripcion,Caudal,Diametro,Area,VSalida")] Valvula model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    double enMetros = ((model.Diametro * 25.0) / 1000);
                    model.Area = (Math.Pow(enMetros, 2) * (Math.PI / 4.0));
                    model.VSalida = model.Caudal / model.Area;

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValvulaExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Valvulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Valvulas == null)
            {
                return NotFound();
            }

            var valvula = await _context.Valvulas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valvula == null)
            {
                return NotFound();
            }

            return View(valvula);
        }

        // POST: Valvulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Valvulas == null)
            {
                return Problem("Entity set 'ValvulasContext.Valvulas'  is null.");
            }
            var valvula = await _context.Valvulas.FindAsync(id);
            if (valvula != null)
            {
                _context.Valvulas.Remove(valvula);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValvulaExists(int id)
        {
          return _context.Valvulas.Any(e => e.Id == id);
        }
    }
}