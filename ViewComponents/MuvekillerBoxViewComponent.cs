using DntHukuk.Web.Areas.Identity.Data;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using Microsoft.AspNetCore.Identity;
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
        private static UserManager<ApplicationUser> _userManager;

        public MuvekillerBoxViewComponent(AuthDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public static async Task<string> AvukatIdToName(Guid id)
        {
            var user =await  _userManager.FindByIdAsync(id.ToString());
            string avukatIsmi = user.userFirstName + " " + user.userLastName;
            return avukatIsmi;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.MuvekkilSayisi = _context.Muvekkil.Count();
            var sonEklenenMvekkil = await _context.Muvekkil.OrderByDescending(a => a.muvekkilUyelikTarihi).Select(p => p).ToListAsync();
            return View(sonEklenenMvekkil[0]);
        }

    }
}
