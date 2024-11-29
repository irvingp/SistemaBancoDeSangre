using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaBancoDeSangre.Data;
using SistemaBancoDeSangre.Models;

namespace SistemaBancoDeSangre.Controllers
{
    public class ControlDonacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ControlDonacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ControlDonaciones
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ControlDonaciones.Include(c => c.CentroDonacion).Include(c => c.Donante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ControlDonaciones/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlDonaciones = await _context.ControlDonaciones
                .Include(c => c.CentroDonacion)
                .Include(c => c.Donante)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (controlDonaciones == null)
            {
                return NotFound();
            }

            return View(controlDonaciones);
        }

        // GET: ControlDonaciones/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CentroDonacionId"] = new SelectList(_context.CentroDonacion, "ID", "NombreCentro");
            ViewData["DonanteId"] = new SelectList(_context.Donante, "Id", "NombreCompleto");
            return View();
        }


        // POST: ControlDonaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,DonanteId,CentroDonacionId,FechaDonacion")] ControlDonaciones controlDonaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controlDonaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CentroDonacionId"] = new SelectList(_context.CentroDonacion, "ID", "NombreCentro", controlDonaciones.CentroDonacionId);
            ViewData["DonanteId"] = new SelectList(_context.Donante, "Id", "GrupoSanguineo", controlDonaciones.DonanteId);
            return View(controlDonaciones);
        }

        // GET: ControlDonaciones/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlDonaciones = await _context.ControlDonaciones.FindAsync(id);
            if (controlDonaciones == null)
            {
                return NotFound();
            }
            ViewData["CentroDonacionId"] = new SelectList(_context.CentroDonacion, "ID", "NombreCentro", controlDonaciones.CentroDonacionId);
            ViewData["DonanteId"] = new SelectList(_context.Donante, "Id", "GrupoSanguineo", controlDonaciones.DonanteId);
            return View(controlDonaciones);
        }

        // POST: ControlDonaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DonanteId,CentroDonacionId,FechaDonacion")] ControlDonaciones controlDonaciones)
        {
            if (id != controlDonaciones.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlDonaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlDonacionesExists(controlDonaciones.ID))
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
            ViewData["CentroDonacionId"] = new SelectList(_context.CentroDonacion, "ID", "NombreCentro", controlDonaciones.CentroDonacionId);
            ViewData["DonanteId"] = new SelectList(_context.Donante, "Id", "GrupoSanguineo", controlDonaciones.DonanteId);
            return View(controlDonaciones);
        }

        // GET: ControlDonaciones/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlDonaciones = await _context.ControlDonaciones
                .Include(c => c.CentroDonacion)
                .Include(c => c.Donante)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (controlDonaciones == null)
            {
                return NotFound();
            }

            return View(controlDonaciones);
        }

        // POST: ControlDonaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controlDonaciones = await _context.ControlDonaciones.FindAsync(id);
            _context.ControlDonaciones.Remove(controlDonaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlDonacionesExists(int id)
        {
            return _context.ControlDonaciones.Any(e => e.ID == id);
        }
    }
}
