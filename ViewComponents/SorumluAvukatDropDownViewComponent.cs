using DntHukuk.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class SorumluAvukatDropDownViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SorumluAvukatDropDownViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? avukatId)
        {
            ViewBag.sorumluAvukatId = avukatId ?? null;
            return View(await _userManager.Users.ToListAsync());
        }
    }
}
