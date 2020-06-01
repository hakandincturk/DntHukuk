using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;

namespace DntHukuk.Web.Controllers
{
    public class NotlarController : Controller
    {
        private readonly AuthDbContext _context;

        public NotlarController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: Notlar
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Notlar/Details/5
        public async Task<IActionResult> Detay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notlar = await _context.Notlar
                .FirstOrDefaultAsync(m => m.notId == id);
            if (notlar == null)
            {
                return NotFound();
            }

            return View(notlar);
        }

        // GET: Notlar/Create
        public IActionResult Ekle()
        {
            return View();
        }

        // POST: Notlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("notId,Not")] Notlar notlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notlar);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(notlar);
        }

        // GET: Notlar/Delete/5
        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notlar = await _context.Notlar
                .FirstOrDefaultAsync(m => m.notId == id);
            if (notlar == null)
            {
                return NotFound();
            }

            return View(notlar);
        }

        // POST: Notlar/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SilOnay(int id)
        {
            var notlar = await _context.Notlar.FindAsync(id);
            _context.Notlar.Remove(notlar);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool NotlarExists(int id)
        {
            return _context.Notlar.Any(e => e.notId == id);
        }
    }
}
