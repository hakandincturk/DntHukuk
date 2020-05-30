using DntHukuk.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class CezaMahkemesiMuvekkilKonumuDropDownViewComponent : ViewComponent
    {
        private readonly AuthDbContext _context;

        public CezaMahkemesiMuvekkilKonumuDropDownViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? muvekkilKonumuId)
        {
            ViewBag.muvekkilKonumuId = muvekkilKonumuId ?? null;
            return View(await _context.CezaMahkemesiMuvekkilKonumu.ToListAsync());
        }
    }
}
