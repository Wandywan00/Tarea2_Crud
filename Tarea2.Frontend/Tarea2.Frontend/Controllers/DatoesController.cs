using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarea2.Frontend;
using Tarea2.Frontend.Data;

namespace Tarea2.Frontend.Controllers
{
    public class DatoesController : Controller
    {
        private readonly Tarea2FrontendContext _context;

        public DatoesController(Tarea2FrontendContext context)
        {
            _context = context;
        }

        // GET: Datoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dato.ToListAsync());
        }

        // GET: Datoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dato = await _context.Dato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dato == null)
            {
                return NotFound();
            }

            return View(dato);
        }

        // GET: Datoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Datoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,titulo,duracion,genero")] Dato dato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dato);
        }

        // GET: Datoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dato = await _context.Dato.FindAsync(id);
            if (dato == null)
            {
                return NotFound();
            }
            return View(dato);
        }

        // POST: Datoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,titulo,duracion,genero")] Dato dato)
        {
            if (id != dato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatoExists(dato.Id))
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
            return View(dato);
        }

        // GET: Datoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dato = await _context.Dato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dato == null)
            {
                return NotFound();
            }

            return View(dato);
        }

        // POST: Datoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dato = await _context.Dato.FindAsync(id);
            if (dato != null)
            {
                _context.Dato.Remove(dato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatoExists(int id)
        {
            return _context.Dato.Any(e => e.Id == id);
        }
    }
}
