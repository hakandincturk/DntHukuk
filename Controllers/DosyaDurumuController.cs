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
    public class DosyaDurumuController : Controller
    {
        private readonly AuthDbContext _context;

        public DosyaDurumuController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: DosyaDurumu
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        // GET: DosyaDurumu/Create
        public IActionResult DosyaDurumuEkle()
        {
            return View();
        }

        // POST: DosyaDurumu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DosyaDurumuEkle([Bind("dosyaDurumuId,dosyaDurumuTuru")] DosyaDurumu dosyaDurumu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosyaDurumu);
                await _context.SaveChangesAsync();
                return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
            }
            return View(dosyaDurumu);
        }

        // GET: DosyaDurumu/Edit/5
        public async Task<IActionResult> DosyaDurumuDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosyaDurumu = await _context.DosyaDurumu.FindAsync(id);
            if (dosyaDurumu == null)
            {
                return NotFound();
            }
            return View(dosyaDurumu);
        }

        // POST: DosyaDurumu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DosyaDurumuDuzenle(int id, [Bind("dosyaDurumuId,dosyaDurumuTuru")] DosyaDurumu dosyaDurumu)
        {
            if (id != dosyaDurumu.dosyaDurumuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosyaDurumu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosyaDurumuExists(dosyaDurumu.dosyaDurumuId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
            }
            return View(dosyaDurumu);
        }

        // GET: DosyaDurumu/Delete/5
        public async Task<IActionResult> DosyaDurumuSil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosyaDurumu = await _context.DosyaDurumu
                .FirstOrDefaultAsync(m => m.dosyaDurumuId == id);
            if (dosyaDurumu == null)
            {
                return NotFound();
            }

            return View(dosyaDurumu);
        }

        // POST: DosyaDurumu/Delete/5
        [HttpPost, ActionName("DosyaDurumuSil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DosyaDurumuSilOnay(int id)
        {
            var dosyaDurumu = await _context.DosyaDurumu.FindAsync(id);
            _context.DosyaDurumu.Remove(dosyaDurumu);
            await _context.SaveChangesAsync();
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        private bool DosyaDurumuExists(int id)
        {
            return _context.DosyaDurumu.Any(e => e.dosyaDurumuId == id);
        }
    }
}
