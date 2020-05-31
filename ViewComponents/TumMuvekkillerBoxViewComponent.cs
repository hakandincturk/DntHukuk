using DntHukuk.Web.Areas.Identity.Data;
using DntHukuk.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class TumMuvekkillerBoxViewComponent : ViewComponent
    {

        private readonly AuthDbContext _context;

        public TumMuvekkillerBoxViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Muvekkil.OrderByDescending(i => i.muvekkilId).ToListAsync());
        }
    }
}
