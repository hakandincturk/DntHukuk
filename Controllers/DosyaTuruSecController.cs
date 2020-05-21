using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DntHukuk.Web.Controllers
{
    public class DosyaTuruSecController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}