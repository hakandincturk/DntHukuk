using DntHukuk.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class DurusmaDurumuDropDownViewComponent : ViewComponent
    {
        private AuthDbContext _context;

        public DurusmaDurumuDropDownViewComponent(AuthDbContext context, AuthDbContext contextStatic)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? dosyaDurumuId)
        {
            ViewBag.DosyaDurumu = dosyaDurumuId ?? null;
            return View(await _context.DosyaDurumu.ToListAsync());
        }
    }
}
