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
    public class DosyalarController : Controller
    {
        private readonly AuthDbContext _context;

        public DosyalarController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: Dosyalar
        public async Task<IActionResult> Listele()
        {
            return View(await _context.Dosyalar.ToListAsync());
        }

        // GET: Dosyalar/Details/5
        public async Task<IActionResult> Detay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosyalar = await _context.Dosyalar
                .FirstOrDefaultAsync(m => m.DosyaId == id);
            if (dosyalar == null)
            {
                return NotFound();
            }

            return View(dosyalar);
        }

        // GET: Dosyalar/Edit/5
        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosyalar = await _context.Dosyalar.FindAsync(id);
            if (dosyalar == null)
            {
                return NotFound();
            }
            return View(dosyalar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, [Bind("DosyaId,SorumluAvukatId,MuvekkilId,MuvekkilKonumuId,DosyaDurumuId,DosyaBaslamaTarihi,DosyaBitisTarihi,DosyaAdi,DosyaSehir,DosyaIlce,DosyaMahkemeAdi,DosyaSiraNo,DosyaKonu,DosyaSonDurum,DosyaMuvekkilEvraklariPath,DosyaKarsiTarafEvraklariPath,DosyaMerciEvraklari,DosyaKarsiTarafId,DosyaKarsiTarafBilgi,DosyaTuru")] Dosyalar dosyalar)
        {
            if (id != dosyalar.DosyaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosyalar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosyalarExists(dosyalar.DosyaId))
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
            return View(dosyalar);
        }

        // GET: Dosyalar/Delete/5
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosyalar = await _context.Dosyalar
                .FirstOrDefaultAsync(m => m.DosyaId == id);
            if (dosyalar == null)
            {
                return NotFound();
            }

            return View(dosyalar);
        }

        // POST: Dosyalar/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SilOnay(int id)
        {
            var dosyalar = await _context.Dosyalar.FindAsync(id);
            _context.Dosyalar.Remove(dosyalar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosyalarExists(int id)
        {
            return _context.Dosyalar.Any(e => e.DosyaId == id);
        }
    }
}
