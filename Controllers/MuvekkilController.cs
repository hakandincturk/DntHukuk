using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using DntHukuk.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace DntHukuk.Web.Controllers
{
    [Authorize]
    public class MuvekkilController : Controller
    {
        private readonly AuthDbContext _context;
        private static UserManager<ApplicationUser> _userManager;

        
        public MuvekkilController(AuthDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Listele");
        }

        // GET: Muvekkils
        public async Task<IActionResult> Listele()
        {
            return View(await _context.Muvekkil.ToListAsync());
        }

        public static async Task<string> AvukatIdToName(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return "Bilgi Yok";
            string avukatIsmi = user.userFirstName + " " + user.userLastName;
            return avukatIsmi;
        }

        // GET: Muvekkils/Details/5
        public async Task<IActionResult> Detay(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muvekkil = await _context.Muvekkil
                .FirstOrDefaultAsync(m => m.muvekkilId == id);
            if (muvekkil == null)
            {
                return NotFound();
            }

            return View(muvekkil);
        }

        // GET: Muvekkils/Create
        public IActionResult Ekle()
        {
            return View();
        }

        // POST: Muvekkils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("muvekkilId,muvekkilAdi,muvekkilSoyAdi,muvekkilTc,muvekkilTuruId,muvekkilSorumluAvukat,muvekkilEmaik,muvekkilTelefon,muvekkilAdres,muvekkilAciklama,muvekkilEvrakPath,muvekkilVergiDairesi,muvekkilVergiNo,muvekkilYetkiliIsim, muvekkilUyelikTarihi")] Muvekkil muvekkil)
        {
            if (ModelState.IsValid)
            {
                muvekkil.muvekkilId = Guid.NewGuid();
                muvekkil.muvekkilSorumluAvukat = Guid.Parse(HttpContext.Request.Form["sorumluAvukatDropDown"]);
                muvekkil.muvekkilTuruId = Convert.ToInt32(HttpContext.Request.Form["muvekkilTurleriDropDown"]);
                muvekkil.muvekkilEvrakPath = "";
                _context.Add(muvekkil);
                await _context.SaveChangesAsync();
                return RedirectToAction("Listele");
            }
            return View(muvekkil);
        }

        // GET: Muvekkils/Edit/5
        public async Task<IActionResult> Duzenle(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muvekkil = await _context.Muvekkil.FindAsync(id);
            if (muvekkil == null)
            {
                return NotFound();
            }
            return View(muvekkil);
        }

        // POST: Muvekkils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(Guid id, [Bind("muvekkilId,muvekkilAdi,muvekkilSoyAdi,muvekkilTc,muvekkilTuruId,muvekkilSorumluAvukat,muvekkilEmaik,muvekkilTelefon,muvekkilAdres,muvekkilAciklama,muvekkilEvrakPath,muvekkilVergiDairesi,muvekkilVergiNo,muvekkilYetkiliIsim")] Muvekkil muvekkil)
        {
            if (id != muvekkil.muvekkilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    muvekkil.muvekkilUyelikTarihi = Convert.ToDateTime(await muvekkilAsilUyelikTarihi(id));
                    muvekkil.muvekkilSorumluAvukat = Guid.Parse(HttpContext.Request.Form["sorumluAvukatDropDown"]);
                    muvekkil.muvekkilTuruId = Convert.ToInt32(HttpContext.Request.Form["muvekkilTurleriDropDown"]);
                    _context.Update(muvekkil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuvekkilExists(muvekkil.muvekkilId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Listele");
            }
            return View(muvekkil);
        }

        public async Task<DateTime> muvekkilAsilUyelikTarihi(Guid id)
        {
            var muvekkil = await _context.Muvekkil.AsNoTracking().Where(p=> p.muvekkilId == id).FirstOrDefaultAsync();
            return muvekkil.muvekkilUyelikTarihi;
        }

        // GET: Muvekkils/Delete/5
        public async Task<IActionResult> Sil(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muvekkil = await _context.Muvekkil
                .FirstOrDefaultAsync(m => m.muvekkilId == id);
            if (muvekkil == null)
            {
                return NotFound();
            }

            return View(muvekkil);
        }

        // POST: Muvekkils/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SilOnay(Guid id)
        {
            var muvekkil = await _context.Muvekkil.FindAsync(id);
            _context.Muvekkil.Remove(muvekkil);
            await _context.SaveChangesAsync();
            return RedirectToAction("Listele");
        }

        private bool MuvekkilExists(Guid id)
        {
            return _context.Muvekkil.Any(e => e.muvekkilId == id);
        }
    }
}
