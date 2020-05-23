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
    public class IcraHukukuController : Controller
    {
        private readonly AuthDbContext _context;

        public IcraHukukuController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: IcraHukuku
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dosya.ToListAsync());
        }

        // GET: IcraHukuku/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosya = await _context.Dosya
                .FirstOrDefaultAsync(m => m.DosyaId == id);
            if (dosya == null)
            {
                return NotFound();
            }

            return View(dosya);
        }

        // GET: IcraHukuku/Create
        public IActionResult IcraHukukuDosyaEkle()
        {
            return View();
        }

        // POST: IcraHukuku/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IcraHukukuDosyaEkle([Bind("DosyaId,SorumluAvukatId,MuvekkilId,MuvekkilKonumuId,DosyaDurumuId,DosyaBaslamaTarihi,DosyaBitisTarihi,DosyaAdi,DosyaSehir,DosyaIlce,DosyaMahkemeAdi,DosyaSiraNo,DosyaKonu,DosyaSonDurum,DosyaMuvekkilEvraklariPath,DosyaKarsiTarafEvraklariPath,DosyaMerciEvraklari,DosyaKarsiTarafId")] Dosya dosya)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosya);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dosya);
        }

        // GET: IcraHukuku/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosya = await _context.Dosya.FindAsync(id);
            if (dosya == null)
            {
                return NotFound();
            }
            return View(dosya);
        }

        // POST: IcraHukuku/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DosyaId,SorumluAvukatId,MuvekkilId,MuvekkilKonumuId,DosyaDurumuId,DosyaBaslamaTarihi,DosyaBitisTarihi,DosyaAdi,DosyaSehir,DosyaIlce,DosyaMahkemeAdi,DosyaSiraNo,DosyaKonu,DosyaSonDurum,DosyaMuvekkilEvraklariPath,DosyaKarsiTarafEvraklariPath,DosyaMerciEvraklari,DosyaKarsiTarafId")] Dosya dosya)
        {
            if (id != dosya.DosyaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosya);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosyaExists(dosya.DosyaId))
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
            return View(dosya);
        }

        // GET: IcraHukuku/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosya = await _context.Dosya
                .FirstOrDefaultAsync(m => m.DosyaId == id);
            if (dosya == null)
            {
                return NotFound();
            }

            return View(dosya);
        }

        // POST: IcraHukuku/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dosya = await _context.Dosya.FindAsync(id);
            _context.Dosya.Remove(dosya);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosyaExists(int id)
        {
            return _context.Dosya.Any(e => e.DosyaId == id);
        }
    }
}
