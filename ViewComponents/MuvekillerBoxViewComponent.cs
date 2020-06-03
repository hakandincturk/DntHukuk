using DntHukuk.Web.Areas.Identity.Data;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class MuvekillerBoxViewComponent : ViewComponent
    {

        private readonly AuthDbContext _context;
        private static UserManager<ApplicationUser> _userManager;

        public MuvekillerBoxViewComponent(AuthDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public static async Task<string> AvukatIdToName(Guid id)
        {
            var user =await  _userManager.FindByIdAsync(id.ToString());
            if (user == null) return "Bilgi Yok.";
            else
            {
                string avukatIsmi = user.userFirstName + " " + user.userLastName;
                return avukatIsmi;
            } 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.MuvekkilSayisi = _context.Muvekkil.Count();
            var sonEklenenMvekkil = await _context.Muvekkil.OrderByDescending(a => a.muvekkilUyelikTarihi).Select(p => p).ToListAsync();
            if (sonEklenenMvekkil.Count == 0)
            {
                Muvekkil muvekkilNew = new Muvekkil
                {
                    muvekkilId = new Guid(),
                    muvekkilAdi = "Bilgi Yok",
                    muvekkilSoyAdi = "Bilgi Yok",
                    muvekkilTc = "Bilgi Yok",
                    muvekkilSorumluAvukat = new Guid(),
                    muvekkilEmaik = "Bilgi Yok",
                    muvekkilTelefon = "Bilgi Yok",
                    muvekkilAdres = "Bilgi Yok",
                    muvekkilAciklama = "Bilgi Yok",
                    muvekkilEvrakPath = "Bilgi Yok",
                    muvekkilVergiDairesi = "Bilgi Yok",
                    muvekkilVergiNo = "Bilgi Yok",
                    muvekkilYetkiliIsim = "Bilgi Yok",
                    muvekkilUyelikTarihi = DateTime.Now
                };

                sonEklenenMvekkil.Add(muvekkilNew);
            }
            return View(sonEklenenMvekkil[0]);
        }
    }
}
