using DntHukuk.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class NotlarBoxViewComponent : ViewComponent
    {
        private readonly AuthDbContext _context;

        public NotlarBoxViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Notlar.OrderByDescending(i=> i.notId).ToListAsync());
        }
    }
}
