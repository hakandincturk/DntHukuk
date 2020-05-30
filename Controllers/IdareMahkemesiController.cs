using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using Microsoft.AspNetCore.Hosting;
using DntHukuk.Web.ViewModel;
using System.IO;

namespace DntHukuk.Web.Controllers
{
    public class IdareMahkemesiController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public IdareMahkemesiController(AuthDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: IdareMahkemesi/Create
        public IActionResult IdareMahkemesiDosyaEkle()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdareMahkemesiDosyaEkle(DosyalarViewModel dosyaViewModel)
        {
            Dosyalar yeniDosya;

            if (ModelState.IsValid){

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

                yeniDosya = new Dosyalar
                {
                    MuvekkilId = Guid.Parse(HttpContext.Request.Form["muvekkillerDropDown"]),
                    SorumluAvukatId = Guid.Parse(HttpContext.Request.Form["sorumluAvukatDropDown"]),
                    MuvekkilKonumuId = Convert.ToInt32(HttpContext.Request.Form["idareMahkemesiMuvekkilKonumuIdDropDown"]),
                    DosyaDurumuId = Convert.ToInt32(HttpContext.Request.Form["dosyaDurumuIdDropDown"]),
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
                    DosyaMerciEvraklari = merciEvraklariUniqeFileName ?? null,
                    DosyaKarsiTarafBilgi = dosyaViewModel.DosyaKarsiTarafBilgi,
                    DosyaTuru = 4,
                    DosyaKarsiTarafId = 0
                };

                _context.Add(yeniDosya);
                await _context.SaveChangesAsync();
                return RedirectToAction("Listele", "Ayarlar");
            }
            return View();
        }
    }
}
