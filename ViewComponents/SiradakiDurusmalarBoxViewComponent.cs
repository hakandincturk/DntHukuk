using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class SiradakiDurusmalarBoxViewComponent : ViewComponent
    {
        private readonly AuthDbContext _context;
        private static AuthDbContext _contextStatic;

        public SiradakiDurusmalarBoxViewComponent(AuthDbContext context, AuthDbContext contextStatic)
        {
            _context = context;
            _contextStatic = contextStatic;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Durusma.OrderBy(i => i.DurusmaTarihi).Where(c => c.DurusmaTarihi > DateTime.Now).ToListAsync());
        }

        public async static Task<string> DosyaIdToName(int id)
        {
            Dosyalar dosyaInfo = await _contextStatic.Dosyalar.FirstOrDefaultAsync(i => i.DosyaId == id);
            if (dosyaInfo == null) return "Dosya Silinmiş";
            else return dosyaInfo.DosyaAdi;
        }

        public async static Task<string> DurusmaDurumuIdToName(int id)
        {
            DurusmaDurum dosyaInfo = await _contextStatic.DurusmaDurum.FirstOrDefaultAsync(i => i.DurusmaDurumId == id);
            if (dosyaInfo == null) return "Durusma Durumu Silinmiş.";
            else return dosyaInfo.DurusmaDurumu;
        }

    }
}
