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
    public class CentroDonacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CentroDonacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CentroDonacions
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CentroDonacion.ToListAsync());
        }

        // GET: CentroDonacions/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroDonacion = await _context.CentroDonacion
                .FirstOrDefaultAsync(m => m.ID == id);
            if (centroDonacion == null)
            {
                return NotFound();
            }

            return View(centroDonacion);
        }

        // GET: CentroDonacions/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentroDonacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,NombreCentro,Direccion")] CentroDonacion centroDonacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroDonacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centroDonacion);
        }

        // GET: CentroDonacions/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroDonacion = await _context.CentroDonacion.FindAsync(id);
            if (centroDonacion == null)
            {
                return NotFound();
            }
            return View(centroDonacion);
        }

        // POST: CentroDonacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NombreCentro,Direccion")] CentroDonacion centroDonacion)
        {
            if (id != centroDonacion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centroDonacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroDonacionExists(centroDonacion.ID))
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
            return View(centroDonacion);
        }

        // GET: CentroDonacions/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroDonacion = await _context.CentroDonacion
                .FirstOrDefaultAsync(m => m.ID == id);
            if (centroDonacion == null)
            {
                return NotFound();
            }

            return View(centroDonacion);
        }

        // POST: CentroDonacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centroDonacion = await _context.CentroDonacion.FindAsync(id);
            _context.CentroDonacion.Remove(centroDonacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroDonacionExists(int id)
        {
            return _context.CentroDonacion.Any(e => e.ID == id);
        }
    }
}
