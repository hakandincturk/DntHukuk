using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;

namespace DntHukuk.Web.Controllers
{
    public class DurusmaController : Controller
    {
        private readonly durusmaContext _context;

        public DurusmaController(durusmaContext context)
        {
            _context = context;
        }

        // GET: Durusma
        public async Task<IActionResult> Index()
        {
            return View(await _context.Durusma.ToListAsync());
        }

        // GET: Durusma/Details/5
        public async Task<IActionResult> Detay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durusma = await _context.Durusma
                .FirstOrDefaultAsync(m => m.DurusmaId == id);
            if (durusma == null)
            {
                return NotFound();
            }

            return View(durusma);
        }

        // GET: Durusma/Create
        public IActionResult Ekle()
        {
            return View();
        }

        // POST: Durusma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("DurusmaId,DosyaId,DurusmaTuruId,DurusmaAdi,MahkemeAciklama,DurusmaTarihi")] Durusma durusma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(durusma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(durusma);
        }

        // GET: Durusma/Edit/5
        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durusma = await _context.Durusma.FindAsync(id);
            if (durusma == null)
            {
                return NotFound();
            }
            return View(durusma);
        }

        // POST: Durusma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, [Bind("DurusmaId,DosyaId,DurusmaTuruId,DurusmaAdi,MahkemeAciklama,DurusmaTarihi")] Durusma durusma)
        {
            if (id != durusma.DurusmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(durusma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DurusmaExists(durusma.DurusmaId))
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
            return View(durusma);
        }

        // GET: Durusma/Delete/5
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durusma = await _context.Durusma
                .FirstOrDefaultAsync(m => m.DurusmaId == id);
            if (durusma == null)
            {
                return NotFound();
            }

            return View(durusma);
        }

        // POST: Durusma/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SilOnay(int id)
        {
            var durusma = await _context.Durusma.FindAsync(id);
            _context.Durusma.Remove(durusma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DurusmaExists(int id)
        {
            return _context.Durusma.Any(e => e.DurusmaId == id);
        }
    }
}
