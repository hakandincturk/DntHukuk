using DntHukuk.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class IdareMahkemesiMuvekkilKonumuBoxViewComponent : ViewComponent
    {
        private readonly AuthDbContext _context;

        public IdareMahkemesiMuvekkilKonumuBoxViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.IdareMahkemesiMuvekkilKonumu.ToListAsync());
        }
    }
}
