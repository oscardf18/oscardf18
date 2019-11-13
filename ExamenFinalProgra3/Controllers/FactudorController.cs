using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenFinalMVC.Models;
using ExamenFinalProgra3.Data;

namespace ExamenFinalProgra3.Controllers
{
    public class FactudorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FactudorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Factudor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Factura.Include(f => f.Clientes).Include(f => f.Empleado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Factudor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura
                .Include(f => f.Clientes)
                .Include(f => f.Empleado)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Factudor/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "IdEmpleado");
            return View();
        }

        // POST: Factudor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactura,IdCliente,IdEmpleado,Fecha")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", factura.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "IdEmpleado", factura.IdEmpleado);
            return View(factura);
        }

        // GET: Factudor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", factura.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "IdEmpleado", factura.IdEmpleado);
            return View(factura);
        }

        // POST: Factudor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactura,IdCliente,IdEmpleado,Fecha")] Factura factura)
        {
            if (id != factura.IdFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.IdFactura))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", factura.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "IdEmpleado", factura.IdEmpleado);
            return View(factura);
        }

        // GET: Factudor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura
                .Include(f => f.Clientes)
                .Include(f => f.Empleado)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Factudor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Factura.FindAsync(id);
            _context.Factura.Remove(factura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _context.Factura.Any(e => e.IdFactura == id);
        }
    }
}
