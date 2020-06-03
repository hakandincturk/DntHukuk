using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using Microsoft.AspNetCore.Identity;
using DntHukuk.Web.Areas.Identity.Data;
using DntHukuk.Web.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

namespace DntHukuk.Web.Controllers
{
    [Authorize]
    public class DosyalarController : Controller
    {
        private readonly AuthDbContext _context;
        private static AuthDbContext _staticContext;
        private static UserManager<ApplicationUser> _userManager;

        public DosyalarController(AuthDbContext context, AuthDbContext staticContext, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _staticContext = staticContext;
            _userManager = userManager;
        }

        // GET: Dosyalar
        public async Task<IActionResult> Listele()
        {
            return View(await _context.Dosyalar.ToListAsync());
        }

        // GET: Dosyalar/Details/5
        public async Task<IActionResult> Detay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosyalar = await _context.Dosyalar
                .FirstOrDefaultAsync(m => m.DosyaId == id);
            if (dosyalar == null)
            {
                return NotFound();
            }

            return View(dosyalar);
        }

        // GET: Dosyalar/Edit/5
        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosyalar = await _context.Dosyalar.FindAsync(id);
            if (dosyalar == null)
            {
                return NotFound();
            }
            return View(dosyalar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, [Bind("DosyaId,SorumluAvukatId,MuvekkilId,MuvekkilKonumuId,DosyaDurumuId,DosyaBaslamaTarihi,DosyaBitisTarihi,DosyaAdi,DosyaSehir,DosyaIlce,DosyaMahkemeAdi,DosyaSiraNo,DosyaKonu,DosyaSonDurum,DosyaMuvekkilEvraklariPath,DosyaKarsiTarafEvraklariPath,DosyaMerciEvraklari,DosyaKarsiTarafId,DosyaKarsiTarafBilgi,DosyaTuru")] Models.Dosyalar dosyalar)
        {
            if (id != dosyalar.DosyaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosyalar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosyalarExists(dosyalar.DosyaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Listele));
            }
            return View(dosyalar);
        }

        // GET: Dosyalar/Delete/5
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosyalar = await _context.Dosyalar
                .FirstOrDefaultAsync(m => m.DosyaId == id);
            if (dosyalar == null)
            {
                return NotFound();
            }

            return View(dosyalar);
        }

        // POST: Dosyalar/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SilOnay(int id)
        {
            var dosyalar = await _context.Dosyalar.FindAsync(id);
            _context.Dosyalar.Remove(dosyalar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listele));
        }

        private bool DosyalarExists(int id)
        {
            return _context.Dosyalar.Any(e => e.DosyaId == id);
        }

        public static async Task<string> MuvekkilIdToName(Guid id)
        {
            Muvekkil bosDeger = new Muvekkil();
            bosDeger.muvekkilAdi = "Seçim";
            bosDeger.muvekkilSoyAdi = "Yapmadınız";
            var user = await _staticContext.Muvekkil.FirstOrDefaultAsync(i => i.muvekkilId == id) ?? bosDeger;
            string muvekkilAdiSoyadi= user.muvekkilAdi + " " + user.muvekkilSoyAdi;
            return muvekkilAdiSoyadi;
        }


        public static async Task<string> AvukatIdToName(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            string avukatIsmi = user.userFirstName + " " + user.userLastName;
            return avukatIsmi;
        }
        public static async Task<string> DosyaDurumuIdToName(int id)
        {
            Models.DosyaDurumu bosDeger = new Models.DosyaDurumu();
            bosDeger.dosyaDurumuTuru = "Yapılan Seçim Kaldırıldı.";
            var user = await _staticContext.DosyaDurumu.FirstOrDefaultAsync(i => i.dosyaDurumuId == id) ?? bosDeger;
            string dosyaDurumu = user.dosyaDurumuTuru;
            return dosyaDurumu;
        }

        public static async Task<string> IcraHukukuMuvekkilKonumuIdToName(int id)
        {
            IcraHukukuMuvekkilKonumu bosDeger = new IcraHukukuMuvekkilKonumu();
            bosDeger.IcraHukukMuvekkilKonumu = "Yapılan Seçim Kaldırıldı.";
            var user = await _staticContext.IcraHukukuMuvekkilKonumu.FirstOrDefaultAsync(i=>i.Id == id) ?? bosDeger;
            string muvekkilKonumu = user.IcraHukukMuvekkilKonumu;
            return muvekkilKonumu;
        }

        public static async Task<string> HukukMahkemesiMuvekkilKonumuIdToName(int id)
        {
            HukukMahkemesiMuvekkilKonumu bosDeger = new HukukMahkemesiMuvekkilKonumu();
            bosDeger.hukukMahkemesiMuvekkilKonumuTuru = "Yapılan Seçim Kaldırıldı.";
            var user = await _staticContext.HukukMahkemesiMuvekkilKonumu.FirstOrDefaultAsync(i=>i.hukukMahkemesiMuvekkilKonumuId == id) ?? bosDeger;
            string muvekkilKonumu = user.hukukMahkemesiMuvekkilKonumuTuru;
            return muvekkilKonumu;
        }

        public static async Task<string> CezaMahkemesiMuvekkilKonumuIdToName(int id)
        {
            Models.CezaMahkemesiMuvekkilKonumu bosDeger = new Models.CezaMahkemesiMuvekkilKonumu();
            bosDeger.cezaHukukuMuvekkilKonumuTuru = "Yapılan Seçim Kaldırıldı.";
            var user = await _staticContext.CezaMahkemesiMuvekkilKonumu.FirstOrDefaultAsync(i=>i.cezaHukukuMuvekkilKonumuId == id) ?? bosDeger;
            string muvekkilKonumu = user.cezaHukukuMuvekkilKonumuTuru;
            return muvekkilKonumu;
        }

        public static async Task<string> IdareMahkemesiMuvekkilKonumuIdToName(int id)
        {
            Models.IdareMahkemesiMuvekkilKonumu bosDeger = new Models.IdareMahkemesiMuvekkilKonumu();
            bosDeger.idareMahkemesiMuvekkilKonumuTuru = "Yapılan Seçim Kaldırıldı.";
            var user = await _staticContext.IdareMahkemesiMuvekkilKonumu.FirstOrDefaultAsync(i=>i.idareMahkemesiMuvekkilKonumuId == id) ?? bosDeger;
            string muvekkilKonumu = user.idareMahkemesiMuvekkilKonumuTuru;
            return muvekkilKonumu;
        }

        public static async Task<string> IdareMahkemesiMahkemeTuruIdToName(int id)
        {
            Models.IdareMahkemesiMahkemeTuru bosDeger = new Models.IdareMahkemesiMahkemeTuru();
            bosDeger.idareMahkemesiMahkemeTuruu = "Yapılan Seçim Kaldırıldı.";
            var user = await _staticContext.IdareMahkemesiMahkemeTuru.FirstOrDefaultAsync(i=>i.idareMahkemesiMahkemeTuruId == id) ?? bosDeger;
            string muvekkilKonumu = user.idareMahkemesiMahkemeTuruu;
            return muvekkilKonumu;
        }
    }
}
