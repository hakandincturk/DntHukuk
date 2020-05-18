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
    public class CezaMahkemesiMuvekkilKonumuController : Controller
    {
        private readonly AuthDbContext _context;

        public CezaMahkemesiMuvekkilKonumuController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: CezaMahkemesiMuvekkilKonumu
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        // GET: CezaMahkemesiMuvekkilKonumu/Create
        public IActionResult CezaMahkemesiMuvekkilKonumuEkle()
        {
            return View();
        }

        // POST: CezaMahkemesiMuvekkilKonumu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CezaMahkemesiMuvekkilKonumuEkle([Bind("cezaHukukuMuvekkilKonumuId,cezaHukukuMuvekkilKonumuTuru")] CezaMahkemesiMuvekkilKonumu cezaMahkemesiMuvekkilKonumu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cezaMahkemesiMuvekkilKonumu);
                await _context.SaveChangesAsync();
                return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
            }
            return View(cezaMahkemesiMuvekkilKonumu);
        }

        // GET: CezaMahkemesiMuvekkilKonumu/Edit/5
        public async Task<IActionResult> CezaMahkemesiMuvekkilKonumuDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cezaMahkemesiMuvekkilKonumu = await _context.CezaMahkemesiMuvekkilKonumu.FindAsync(id);
            if (cezaMahkemesiMuvekkilKonumu == null)
            {
                return NotFound();
            }
            return View(cezaMahkemesiMuvekkilKonumu);
        }

        // POST: CezaMahkemesiMuvekkilKonumu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CezaMahkemesiMuvekkilKonumuDuzenle(int id, [Bind("cezaHukukuMuvekkilKonumuId,cezaHukukuMuvekkilKonumuTuru")] CezaMahkemesiMuvekkilKonumu cezaMahkemesiMuvekkilKonumu)
        {
            if (id != cezaMahkemesiMuvekkilKonumu.cezaHukukuMuvekkilKonumuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cezaMahkemesiMuvekkilKonumu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CezaMahkemesiMuvekkilKonumuExists(cezaMahkemesiMuvekkilKonumu.cezaHukukuMuvekkilKonumuId))
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
            return View(cezaMahkemesiMuvekkilKonumu);
        }

        // GET: CezaMahkemesiMuvekkilKonumu/Delete/5
        public async Task<IActionResult> CezaMahkemesiMuvekkilKonumuSil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cezaMahkemesiMuvekkilKonumu = await _context.CezaMahkemesiMuvekkilKonumu
                .FirstOrDefaultAsync(m => m.cezaHukukuMuvekkilKonumuId == id);
            if (cezaMahkemesiMuvekkilKonumu == null)
            {
                return NotFound();
            }

            return View(cezaMahkemesiMuvekkilKonumu);
        }

        // POST: CezaMahkemesiMuvekkilKonumu/Delete/5
        [HttpPost, ActionName("CezaMahkemesiMuvekkilKonumuSil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CezaMahkemesiMuvekkilKonumuSilOnay(int id)
        {
            var cezaMahkemesiMuvekkilKonumu = await _context.CezaMahkemesiMuvekkilKonumu.FindAsync(id);
            _context.CezaMahkemesiMuvekkilKonumu.Remove(cezaMahkemesiMuvekkilKonumu);
            await _context.SaveChangesAsync();
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        private bool CezaMahkemesiMuvekkilKonumuExists(int id)
        {
            return _context.CezaMahkemesiMuvekkilKonumu.Any(e => e.cezaHukukuMuvekkilKonumuId == id);
        }
    }
}
