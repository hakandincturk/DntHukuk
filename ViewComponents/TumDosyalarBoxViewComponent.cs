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
    public class TumDosyalarBoxViewComponent : ViewComponent
    {

        private readonly AuthDbContext _context;
        private static UserManager<ApplicationUser> _userManager;

        public TumDosyalarBoxViewComponent(AuthDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager= userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Dosyalar.OrderByDescending(i => i.DosyaId).ToListAsync());
        }

        public static async Task<string> AvukatIdToName(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            string avukatIsmi = user.userFirstName + " " + user.userLastName;
            return avukatIsmi;
        }
    }
}
