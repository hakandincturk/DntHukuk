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
    public class IdareMahkemesiMuvekkilKonumuController : Controller
    {
        private readonly AuthDbContext _context;

        public IdareMahkemesiMuvekkilKonumuController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: IdareMahkemesiMuvekkilKonumu
        public IActionResult Index()
        {
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        // GET: IdareMahkemesiMuvekkilKonumu/Create
        public IActionResult IdareMahkemesiMuvekkilKonumuEkle()
        {
            return View();
        }

        // POST: IdareMahkemesiMuvekkilKonumu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdareMahkemesiMuvekkilKonumuEkle([Bind("idareMahkemesiMuvekkilKonumuId,idareMahkemesiMuvekkilKonumuTuru")] IdareMahkemesiMuvekkilKonumu idareMahkemesiMuvekkilKonumu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idareMahkemesiMuvekkilKonumu);
                await _context.SaveChangesAsync();
                return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
            }
            return View(idareMahkemesiMuvekkilKonumu);
        }

        // GET: IdareMahkemesiMuvekkilKonumu/Edit/5
        public async Task<IActionResult> IdareMahkemesiMuvekkilKonumuDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idareMahkemesiMuvekkilKonumu = await _context.IdareMahkemesiMuvekkilKonumu.FindAsync(id);
            if (idareMahkemesiMuvekkilKonumu == null)
            {
                return NotFound();
            }
            return View(idareMahkemesiMuvekkilKonumu);
        }

        // POST: IdareMahkemesiMuvekkilKonumu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdareMahkemesiMuvekkilKonumuDuzenle(int id, [Bind("idareMahkemesiMuvekkilKonumuId,idareMahkemesiMuvekkilKonumuTuru")] IdareMahkemesiMuvekkilKonumu idareMahkemesiMuvekkilKonumu)
        {
            if (id != idareMahkemesiMuvekkilKonumu.idareMahkemesiMuvekkilKonumuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idareMahkemesiMuvekkilKonumu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdareMahkemesiMuvekkilKonumuExists(idareMahkemesiMuvekkilKonumu.idareMahkemesiMuvekkilKonumuId))
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
            return View(idareMahkemesiMuvekkilKonumu);
        }

        // GET: IdareMahkemesiMuvekkilKonumu/Delete/5
        public async Task<IActionResult> IdareMahkemesiMuvekkilKonumuSil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idareMahkemesiMuvekkilKonumu = await _context.IdareMahkemesiMuvekkilKonumu
                .FirstOrDefaultAsync(m => m.idareMahkemesiMuvekkilKonumuId == id);
            if (idareMahkemesiMuvekkilKonumu == null)
            {
                return NotFound();
            }

            return View(idareMahkemesiMuvekkilKonumu);
        }

        // POST: IdareMahkemesiMuvekkilKonumu/Delete/5
        [HttpPost, ActionName("IdareMahkemesiMuvekkilKonumuSil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdareMahkemesiMuvekkilKonumuSilOnay(int id)
        {
            var idareMahkemesiMuvekkilKonumu = await _context.IdareMahkemesiMuvekkilKonumu.FindAsync(id);
            _context.IdareMahkemesiMuvekkilKonumu.Remove(idareMahkemesiMuvekkilKonumu);
            await _context.SaveChangesAsync();
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        private bool IdareMahkemesiMuvekkilKonumuExists(int id)
        {
            return _context.IdareMahkemesiMuvekkilKonumu.Any(e => e.idareMahkemesiMuvekkilKonumuId == id);
        }
    }
}
