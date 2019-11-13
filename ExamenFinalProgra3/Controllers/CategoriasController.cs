﻿using System;
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
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = await _context.Categorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categorias == null)
            {
                return NotFound();
            }

            return View(categorias);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,NombreCategoria,Descripcion")] Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorias);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = await _context.Categorias.FindAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }
            return View(categorias);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,NombreCategoria,Descripcion")] Categorias categorias)
        {
            if (id != categorias.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriasExists(categorias.IdCategoria))
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
            return View(categorias);
        }
        public ActionResult EditField(int id, string field, string value)
        {
            bool status = false; string mensaje = "Valor no establecido";
            Categorias categorias = (from a in _context.Categorias
                                   where a.IdCategoria == id
                                   select a).FirstOrDefault();
            switch (field)
            {
                case "Nombre":
                    categorias.NombreCategoria = value.Trim();
                    break;
                case "Descripcion":
                    categorias.Descripcion = value.Trim();
                    break;
                

            }
            _context.SaveChanges();
            status = true;
            mensaje = "Valor establecido";
            return Json(new { value = value, status = status, mensaje = mensaje });
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = await _context.Categorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categorias == null)
            {
                return NotFound();
            }

            return View(categorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorias = await _context.Categorias.FindAsync(id);
            _context.Categorias.Remove(categorias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriasExists(int id)
        {
            return _context.Categorias.Any(e => e.IdCategoria == id);
        }

        public ActionResult CreateConAjax(Categorias categorias)
        {
            string mensaje = "Error al crea el registro";
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categorias);
                _context.SaveChanges();
                mensaje = "Registro creado";
            }
            return Json(new { result = false, mensaje = mensaje });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConAjax(Categorias categorias)
        {
            string mensaje = "Error al editar el registro";
            if (ModelState.IsValid)
            {
                _context.Entry(categorias).State = EntityState.Modified;
                _context.SaveChanges();
                mensaje = "Registro editado";
            }
            return Json(new { result = false, mensaje = mensaje });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConAjax(Categorias categorias)
        {
            string mensaje = "Error al borrar registro";
            Categorias categoriasFind = _context.Categorias.Find(categorias.IdCategoria);
            _context.Categorias.Remove(categoriasFind);
            _context.SaveChanges();
            mensaje = "Registro borrado!";
            return Json(new { result = true, mensaje = mensaje });
        }
    }
}
