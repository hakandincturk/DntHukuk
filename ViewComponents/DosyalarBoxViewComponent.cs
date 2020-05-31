using DntHukuk.Web.Data;
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
            return View(sonEklenenDosya[0]);
        }
    }
}
