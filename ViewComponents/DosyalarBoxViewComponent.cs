using DntHukuk.Web.Data;
using DntHukuk.Web.Migrations;
using DntHukuk.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class DosyalarBoxViewComponent : ViewComponent
    {

        private readonly AuthDbContext _context;

        public DosyalarBoxViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.KayitSayisi = _context.Dosyalar.Count();
            var sonEklenenDosya = await _context.Dosyalar.OrderByDescending(a => a.DosyaId).Select(p => p).ToListAsync();
            if (sonEklenenDosya.Count == 0) {
                Models.Dosyalar dosya = new Models.Dosyalar {
                    SorumluAvukatId = new Guid(),
                    MuvekkilId = new Guid(),
                    MuvekkilKonumuId = 0,
                    DosyaDurumuId = 0,
                    DosyaBaslamaTarihi = DateTime.Now,
                    DosyaBitisTarihi = DateTime.Now,
                    DosyaAdi = "Dosya Bulunamadı.",
                    DosyaSehir = "Yok",
                    DosyaIlce = "Yok",
                    DosyaMahkemeAdi = "Yok",
                    DosyaSiraNo = "",
                    DosyaKonu = "Yok",
                    DosyaSonDurum = "Yok",
                    DosyaMuvekkilEvraklariPath = "",
                    DosyaKarsiTarafEvraklariPath = "",
                    DosyaMerciEvraklari = "",
                    DosyaKarsiTarafBilgi = ""
                };
                sonEklenenDosya.Add(dosya);
            } 
            return View(sonEklenenDosya[0]);
        }
    }
}
