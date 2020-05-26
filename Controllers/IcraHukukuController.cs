using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using DntHukuk.Web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DntHukuk.Web.Controllers
{
    public class IcraHukukuController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public IcraHukukuController(AuthDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> IcraHukukuDosyaEkle(DosyaViewModel dosyaViewModel)
        {
            Dosya yeniDoysa;

            if (ModelState.IsValid)
            {
                string muvekkilEvraklariUniqeFileName = null;
                string karsiTarafEvraklariUniqeFileName = null;
                string merciEvraklariUniqeFileName = null;

                if (dosyaViewModel.DosyaMuvekkilEvraklari != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "userUploadedFile");
                    muvekkilEvraklariUniqeFileName = Guid.NewGuid().ToString() + "_" + dosyaViewModel.DosyaMuvekkilEvraklari.FileName;
                    string filePath = Path.Combine(uploadsFolder, muvekkilEvraklariUniqeFileName);
                    dosyaViewModel.DosyaMuvekkilEvraklari.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                if (dosyaViewModel.DosyaKarsiTarafEvraklari != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "userUploadedFile");
                    karsiTarafEvraklariUniqeFileName = Guid.NewGuid().ToString() + "_" + dosyaViewModel.DosyaKarsiTarafEvraklari.FileName;
                    string filePath = Path.Combine(uploadsFolder, karsiTarafEvraklariUniqeFileName);
                    dosyaViewModel.DosyaKarsiTarafEvraklari.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                if (dosyaViewModel.DosyaMerciEvraklari != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "userUploadedFile");
                    merciEvraklariUniqeFileName = Guid.NewGuid().ToString() + "_" + dosyaViewModel.DosyaMerciEvraklari.FileName;
                    string filePath = Path.Combine(uploadsFolder, merciEvraklariUniqeFileName);
                    dosyaViewModel.DosyaMerciEvraklari.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                yeniDoysa = new Dosya
                {
                    MuvekkilId = Guid.Parse(HttpContext.Request.Form["muvekkilDropDown"]), 
                    SorumluAvukatId = Guid.Parse(HttpContext.Request.Form["sorumluAvukatDropDown"]),
                    MuvekkilKonumuId = Convert.ToInt32(HttpContext.Request.Form["muvekkilKonumuDropDown"]),
                    DosyaDurumuId = Convert.ToInt32(HttpContext.Request.Form["dosyaDurumuId"]),
                    DosyaBaslamaTarihi = dosyaViewModel.DosyaBaslamaTarihi,
                    DosyaBitisTarihi = dosyaViewModel.DosyaBitisTarihi,
                    DosyaAdi = dosyaViewModel.DosyaAdi,
                    DosyaSehir = dosyaViewModel.DosyaSehir,
                    DosyaIlce = dosyaViewModel.DosyaIlce,
                    DosyaMahkemeAdi = dosyaViewModel.DosyaMahkemeAdi,
                    DosyaSiraNo = dosyaViewModel.DosyaSiraNo,
                    DosyaKonu = dosyaViewModel.DosyaKonu,
                    DosyaSonDurum = dosyaViewModel.DosyaSonDurum,
                    DosyaMuvekkilEvraklariPath = muvekkilEvraklariUniqeFileName ?? null,
                    DosyaKarsiTarafEvraklariPath = karsiTarafEvraklariUniqeFileName ?? null,
                    DosyaMerciEvraklari = merciEvraklariUniqeFileName ?? null
                };
                yeniDoysa.DosyaTuru = 1;
                _context.Add(yeniDoysa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
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
