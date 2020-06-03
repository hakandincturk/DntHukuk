using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace DntHukuk.Web.Controllers
{
    [Authorize]
    public class DurusmaDurumController : Controller
    {
        private readonly AuthDbContext _context;

        public DurusmaDurumController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: DurusmaDurum
        public IActionResult Index()
        {
            return RedirectToAction("YoneticiAyarlariListele", "Ayarlar");
        }

        // GET: DurusmaDurum/Create
        public IActionResult Ekle()
        {
            return View();
        }

        // POST: DurusmaDurum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("DurusmaDurumId,DurusmaDurumu")] DurusmaDurum durusmaDurum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(durusmaDurum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(durusmaDurum);
        }

        // GET: DurusmaDurum/Edit/5
        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durusmaDurum = await _context.DurusmaDurum.FindAsync(id);
            if (durusmaDurum == null)
            {
                return NotFound();
            }
            return View(durusmaDurum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, [Bind("DurusmaDurumId,DurusmaDurumu")] DurusmaDurum durusmaDurum)
        {
            if (id != durusmaDurum.DurusmaDurumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(durusmaDurum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DurusmaDurumExists(durusmaDurum.DurusmaDurumId))
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
            return View(durusmaDurum);
        }

        // GET: DurusmaDurum/Delete/5
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durusmaDurum = await _context.DurusmaDurum
                .FirstOrDefaultAsync(m => m.DurusmaDurumId == id);
            if (durusmaDurum == null)
            {
                return NotFound();
            }

            return View(durusmaDurum);
        }

        // POST: DurusmaDurum/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SilOnay(int id)
        {
            var durusmaDurum = await _context.DurusmaDurum.FindAsync(id);
            _context.DurusmaDurum.Remove(durusmaDurum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DurusmaDurumExists(int id)
        {
            return _context.DurusmaDurum.Any(e => e.DurusmaDurumId == id);
        }
    }
}
