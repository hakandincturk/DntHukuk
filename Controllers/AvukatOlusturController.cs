using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DntHukuk.Web.Areas.Identity.Data;
using DntHukuk.Web.Areas.Identity.Pages.Account;
using DntHukuk.Web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DntHukuk.Web.Controllers
{
    public class AvukatOlusturController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AvukatOlusturController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(ApplicationUserViewModel userInf)
        {
            ApplicationUser user;
            if (ModelState.IsValid)
            {
                string userImagePathUniqeName = null;

                if (userInf.userImagePath != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "userUploadedFile");
                    userImagePathUniqeName = Guid.NewGuid().ToString() + "_" + userInf.userImagePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, userImagePathUniqeName);
                    userInf.userImagePath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                user = new ApplicationUser
                {
                    UserName = userInf.userEmail,
                    Email = userInf.userEmail,
                    userEmail = userInf.userEmail,
                    userFirstName = userInf.userFirstName,
                    userLastName = userInf.userLastName,
                    userImagePath = userImagePathUniqeName,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, userInf.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Kullanıcı oluşturuldu.");
                    return RedirectToAction("PersonelListesi", "Ayarlar");
                }

            }
            return View(userInf);
        }

        [HttpGet]
        public async Task<IActionResult> Sil(Guid id)
        {
            int userCount = _userManager.Users.Count();
            if (userCount > 1)
            {
                ApplicationUser DeleteUser = await _userManager.FindByIdAsync(id.ToString());
                var result = await _userManager.DeleteAsync(DeleteUser);
                if (result.Succeeded) return RedirectToAction("PersonelListesi", "Ayarlar");
                else return RedirectToAction("PersonelListesi", "Ayarlar");
            }
            else return RedirectToAction("PersonelListesli", "Ayarlar");
        }
    }
}