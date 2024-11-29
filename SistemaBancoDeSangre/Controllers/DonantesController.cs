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
    public class DonantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donantes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donante.ToListAsync());
        }

        // GET: Donantes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donante = await _context.Donante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donante == null)
            {
                return NotFound();
            }

            return View(donante);
        }

        // GET: Donantes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,Edad,Genero,GrupoSanguineo,Direccion,Peso")] Donante donante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donante);
        }

        // GET: Donantes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donante = await _context.Donante.FindAsync(id);
            if (donante == null)
            {
                return NotFound();
            }
            return View(donante);
        }

        // POST: Donantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompleto,Edad,Genero,GrupoSanguineo,Direccion,Peso")] Donante donante)
        {
            if (id != donante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonanteExists(donante.Id))
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
            return View(donante);
        }

        // GET: Donantes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donante = await _context.Donante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donante == null)
            {
                return NotFound();
            }

            return View(donante);
        }

        // POST: Donantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donante = await _context.Donante.FindAsync(id);
            _context.Donante.Remove(donante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonanteExists(int id)
        {
            return _context.Donante.Any(e => e.Id == id);
        }
    }
}
