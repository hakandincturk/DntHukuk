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
    public class IdareMahkemesiMahkemeTuruController : Controller
    {
        private readonly AuthDbContext _context;

        public IdareMahkemesiMahkemeTuruController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: IdareMahkemesiMahkemeTuru
        public IActionResult Index()
        {
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        // GET: IdareMahkemesiMahkemeTuru/Create
        public IActionResult IdareMahkemesiMahkemeTuruEkle()
        {
            return View();
        }

        // POST: IdareMahkemesiMahkemeTuru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdareMahkemesiMahkemeTuruEkle([Bind("idareMahkemesiMahkemeTuruId,idareMahkemesiMahkemeTuruu")] IdareMahkemesiMahkemeTuru idareMahkemesiMahkemeTuru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idareMahkemesiMahkemeTuru);
                await _context.SaveChangesAsync();
                return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
            }
            return View(idareMahkemesiMahkemeTuru);
        }

        public async Task<IActionResult> IdareMahkemesiMahkemeTuruDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idareMahkemesiMahkemeTuru = await _context.IdareMahkemesiMahkemeTuru.FindAsync(id);
            if (idareMahkemesiMahkemeTuru == null)
            {
                return NotFound();
            }
            return View(idareMahkemesiMahkemeTuru);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdareMahkemesiMahkemeTuruDuzenle(int id, [Bind("idareMahkemesiMahkemeTuruId,idareMahkemesiMahkemeTuruu")] IdareMahkemesiMahkemeTuru idareMahkemesiMahkemeTuru)
        {
            if (id != idareMahkemesiMahkemeTuru.idareMahkemesiMahkemeTuruId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idareMahkemesiMahkemeTuru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdareMahkemesiMahkemeTuruExists(idareMahkemesiMahkemeTuru.idareMahkemesiMahkemeTuruId))
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
            return View(idareMahkemesiMahkemeTuru);
        }

        public async Task<IActionResult> IdareMahkemesiMahkemeTuruSil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idareMahkemesiMahkemeTuru = await _context.IdareMahkemesiMahkemeTuru
                .FirstOrDefaultAsync(m => m.idareMahkemesiMahkemeTuruId == id);
            if (idareMahkemesiMahkemeTuru == null)
            {
                return NotFound();
            }

            return View(idareMahkemesiMahkemeTuru);
        }

        // POST: IdareMahkemesiMahkemeTuru/Delete/5
        [HttpPost, ActionName("IdareMahkemesiMahkemeTuruSil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdareMahkemesiMahkemeTuruSilOnay(int id)
        {
            var idareMahkemesiMahkemeTuru = await _context.IdareMahkemesiMahkemeTuru.FindAsync(id);
            _context.IdareMahkemesiMahkemeTuru.Remove(idareMahkemesiMahkemeTuru);
            await _context.SaveChangesAsync();
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        private bool IdareMahkemesiMahkemeTuruExists(int id)
        {
            return _context.IdareMahkemesiMahkemeTuru.Any(e => e.idareMahkemesiMahkemeTuruId == id);
        }
    }
}
