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
    public class IcraHukukuMuvekkilKonumuController : Controller
    {
        private readonly AuthDbContext _context;

        public IcraHukukuMuvekkilKonumuController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: IcraHukukuMuvekkilKonumus
        public async Task<IActionResult> Index()
        {
            return View(await _context.IcraHukukuMuvekkilKonumu.ToListAsync());
        }

        public IActionResult IcraHukukuMuvekkilKonumuEkle()
        {
            return View();
        }

        // POST: IcraHukukuMuvekkilKonumus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IcraHukukuMuvekkilKonumuEkle([Bind("Id,IcraHukukMuvekkilKonumu")] IcraHukukuMuvekkilKonumu icraHukukuMuvekkilKonumu)
        {
            if (ModelState.IsValid)
            {
                _context.IcraHukukuMuvekkilKonumu.Add(icraHukukuMuvekkilKonumu);
                await _context.SaveChangesAsync();
                return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
            }
            return View(icraHukukuMuvekkilKonumu);
        }

        // GET: IcraHukukuMuvekkilKonumus/Edit/5
        public async Task<IActionResult> IcraHukukuMuvekkilKonumuDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icraHukukuMuvekkilKonumu = await _context.IcraHukukuMuvekkilKonumu.FindAsync(id);
            if (icraHukukuMuvekkilKonumu == null)
            {
                return NotFound();
            }
            return View(icraHukukuMuvekkilKonumu);
        }

        // POST: IcraHukukuMuvekkilKonumus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IcraHukukuMuvekkilKonumuDuzenle(int id, [Bind("Id,IcraHukukMuvekkilKonumu")] IcraHukukuMuvekkilKonumu icraHukukuMuvekkilKonumu)
        {
            if (id != icraHukukuMuvekkilKonumu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(icraHukukuMuvekkilKonumu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IcraHukukuMuvekkilKonumuExists(icraHukukuMuvekkilKonumu.Id))
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
            return View(icraHukukuMuvekkilKonumu);
        }

        // GET: IcraHukukuMuvekkilKonumus/Delete/5
        public async Task<IActionResult> IcraHukukuMuvekkilKonumuSil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icraHukukuMuvekkilKonumu = await _context.IcraHukukuMuvekkilKonumu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (icraHukukuMuvekkilKonumu == null)
            {
                return NotFound();
            }

            return View(icraHukukuMuvekkilKonumu);
        }

        // POST: IcraHukukuMuvekkilKonumus/Delete/5
        [HttpPost, ActionName("IcraHukukuMuvekkilKonumuSil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IcraHukukuMuvekkilKonumuSilOnay(int id)
        {
            var icraHukukuMuvekkilKonumu = await _context.IcraHukukuMuvekkilKonumu.FindAsync(id);
            _context.IcraHukukuMuvekkilKonumu.Remove(icraHukukuMuvekkilKonumu);
            await _context.SaveChangesAsync();
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        private bool IcraHukukuMuvekkilKonumuExists(int id)
        {
            return _context.IcraHukukuMuvekkilKonumu.Any(e => e.Id == id);
        }
    }
}
