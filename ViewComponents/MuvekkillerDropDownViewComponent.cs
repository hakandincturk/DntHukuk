using DntHukuk.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class MuvekkillerDropDownViewComponent:ViewComponent
    {
        private readonly AuthDbContext _context;

        public MuvekkillerDropDownViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? muvekkilId, bool? sadeceOkunur)
        {
            ViewBag.muvekkilId = muvekkilId ?? null;
            ViewBag.sadeceOkunur = sadeceOkunur ?? false;
            return View(await _context.Muvekkil.ToListAsync());
        }
    }
}
