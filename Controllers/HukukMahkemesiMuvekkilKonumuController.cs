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
    public class HukukMahkemesiMuvekkilKonumuController : Controller
    {
        private readonly AuthDbContext _context;

        public HukukMahkemesiMuvekkilKonumuController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: HukukMahkemesiMuvekkilKonumu
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        // GET: HukukMahkemesiMuvekkilKonumu/Create
        public IActionResult HukukMahkemesiMuvekkilKonumuEkle()
        {
            return View();
        }

        // POST: HukukMahkemesiMuvekkilKonumu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HukukMahkemesiMuvekkilKonumuEkle([Bind("hukukMahkemesiMuvekkilKonumuId,hukukMahkemesiMuvekkilKonumuTuru")] HukukMahkemesiMuvekkilKonumu hukukMahkemesiMuvekkilKonumu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hukukMahkemesiMuvekkilKonumu);
                await _context.SaveChangesAsync();
                return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
            }
            return View(hukukMahkemesiMuvekkilKonumu);
        }

        // GET: HukukMahkemesiMuvekkilKonumu/Edit/5
        public async Task<IActionResult> HukukMahkemesiMuvekkilKonumuDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hukukMahkemesiMuvekkilKonumu = await _context.HukukMahkemesiMuvekkilKonumu.FindAsync(id);
            if (hukukMahkemesiMuvekkilKonumu == null)
            {
                return NotFound();
            }
            return View(hukukMahkemesiMuvekkilKonumu);
        }

        // POST: HukukMahkemesiMuvekkilKonumu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HukukMahkemesiMuvekkilKonumuDuzenle(int id, [Bind("hukukMahkemesiMuvekkilKonumuId,hukukMahkemesiMuvekkilKonumuTuru")] HukukMahkemesiMuvekkilKonumu hukukMahkemesiMuvekkilKonumu)
        {
            if (id != hukukMahkemesiMuvekkilKonumu.hukukMahkemesiMuvekkilKonumuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hukukMahkemesiMuvekkilKonumu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HukukMahkemesiMuvekkilKonumuExists(hukukMahkemesiMuvekkilKonumu.hukukMahkemesiMuvekkilKonumuId))
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
            return View(hukukMahkemesiMuvekkilKonumu);
        }

        // GET: HukukMahkemesiMuvekkilKonumu/Delete/5
        public async Task<IActionResult> HukukMahkemesiMuvekkilKonumuSil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hukukMahkemesiMuvekkilKonumu = await _context.HukukMahkemesiMuvekkilKonumu
                .FirstOrDefaultAsync(m => m.hukukMahkemesiMuvekkilKonumuId == id);
            if (hukukMahkemesiMuvekkilKonumu == null)
            {
                return NotFound();
            }

            return View(hukukMahkemesiMuvekkilKonumu);
        }

        // POST: HukukMahkemesiMuvekkilKonumu/Delete/5
        [HttpPost, ActionName("HukukMahkemesiMuvekkilKonumuSil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HukukMahkemesiMuvekkilKonumuSilOnay(int id)
        {
            var hukukMahkemesiMuvekkilKonumu = await _context.HukukMahkemesiMuvekkilKonumu.FindAsync(id);
            _context.HukukMahkemesiMuvekkilKonumu.Remove(hukukMahkemesiMuvekkilKonumu);
            await _context.SaveChangesAsync();
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        private bool HukukMahkemesiMuvekkilKonumuExists(int id)
        {
            return _context.HukukMahkemesiMuvekkilKonumu.Any(e => e.hukukMahkemesiMuvekkilKonumuId == id);
        }
    }
}
