using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DntHukuk.Web.Controllers
{
    [Authorize]
    public class AyarlarController : Controller
    {
        private readonly AuthDbContext _context;

        public AyarlarController(AuthDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("YoneticiAyarlariListele");
        }

        public IActionResult YoneticiAyarlariListele()
        {
            return View();
        }

        public IActionResult PersonelListesi()
        {
            return View();
        }

    }
}