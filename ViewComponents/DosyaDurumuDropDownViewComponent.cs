using DntHukuk.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class DosyaDurumuDropDownViewComponent : ViewComponent
    {
        private readonly AuthDbContext _context;

        public DosyaDurumuDropDownViewComponent(AuthDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? dosyaDurumuId)
        {
            ViewBag.dosyaDurumuId = dosyaDurumuId ?? null;
            return View(await _context.DosyaDurumu.ToListAsync());
        }
    }
}
