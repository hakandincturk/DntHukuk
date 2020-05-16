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
    public class MuvekillerBoxViewComponent : ViewComponent
    {

        private readonly AuthDbContext _context;

        public MuvekillerBoxViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.MuvekkilSayisi = _context.Muvekkil.Count();
            var sonEklenenMvekkil = await _context.Muvekkil.OrderByDescending(a => a.muvekkilUyelikTarihi).Select(p => p).ToListAsync();
            return View(sonEklenenMvekkil[0]);
        }

    }
}
