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
    public class DurusmaController : Controller
    {
        private readonly AuthDbContext _context;
        private static AuthDbContext _contextStatic;

        public DurusmaController(AuthDbContext context, AuthDbContext contextStatic)
        {
            _context = context;
            _contextStatic = contextStatic;
        }

        // GET: Durusma
        public IActionResult Index()
        {
            return RedirectToAction("Listele");
        }

        // GET: Durusma
        public async Task<IActionResult> Listele()
        {
            List<Durusma> durusmalar = await _context.Durusma.OrderBy(i => i.DurusmaTarihi).Where(c => c.DurusmaTarihi > DateTime.Now).ToListAsync();
            return View(durusmalar);
        }

        // GET: Durusma
        public async Task<IActionResult> TumunuListele()
        {
            List<Durusma> durusmalar = await _context.Durusma.OrderBy(i => i.DurusmaTarihi).ToListAsync();
            return View(durusmalar);
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

                durusma.DosyaId = Convert.ToInt32((HttpContext.Request.Form["dosyaIdDropDown"]));
                durusma.DurusmaTuruId = Convert.ToInt32((HttpContext.Request.Form["dosyaDurumuIdDropDown"]));

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
                    durusma.DosyaId = Convert.ToInt32((HttpContext.Request.Form["dosyaIdDropDown"]));
                    durusma.DurusmaTuruId = Convert.ToInt32((HttpContext.Request.Form["dosyaDurumuIdDropDown"]));
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

        public static async Task<string> DosyaIdToName(int doysyaId)
        {
            var dosyaInfo = await _contextStatic.Dosyalar.FirstOrDefaultAsync(i => i.DosyaId == doysyaId);
            return dosyaInfo.DosyaAdi ?? "Dosya Silinmiş.";
        }

        public static async Task<string> DurusmaTuruIdToName(int turId)
        {
            var durusmaTuruInfo = await _contextStatic.DurusmaDurum.FirstOrDefaultAsync(i => i.DurusmaDurumId == turId);
            return durusmaTuruInfo.DurusmaDurumu ?? "Duruşma Durumu Silinmiş.";
        }
    }
}
