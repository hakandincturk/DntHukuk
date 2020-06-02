using DntHukuk.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class DosyaDropDownViewComponent : ViewComponent
    {
        private readonly AuthDbContext _context;

        public DosyaDropDownViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            ViewBag.dosyaId = id ?? null;
            return View(await _context.Dosyalar.ToListAsync());
        }
    }
}
