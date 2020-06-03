using DntHukuk.Web.Data;
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

        public SiradakiDurusmalarBoxViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Durusma.OrderBy(i => i.DurusmaTarihi).Where(c => c.DurusmaTarihi > DateTime.Now).ToListAsync());
        }
    }
}
