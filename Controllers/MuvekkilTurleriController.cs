using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Data;
using DntHukuk.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace DntHukuk.Web.Controllers
{
    [Authorize]
    public class MuvekkilTurleriController : Controller
    {
        private readonly AuthDbContext _context;

        public MuvekkilTurleriController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: MuvekkilTurleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.muvekkilTurleri.ToListAsync());
        }

        // GET: MuvekkilTurleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muvekkilTurleri = await _context.muvekkilTurleri
                .FirstOrDefaultAsync(m => m.muvekkilTuruId == id);
            if (muvekkilTurleri == null)
            {
                return NotFound();
            }

            return View(muvekkilTurleri);
        }

        // GET: MuvekkilTurleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MuvekkilTurleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("muvekkilTuruId,muvekkilTuruAdi")] MuvekkilTurleri muvekkilTurleri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muvekkilTurleri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muvekkilTurleri);
        }

        // GET: MuvekkilTurleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muvekkilTurleri = await _context.muvekkilTurleri.FindAsync(id);
            if (muvekkilTurleri == null)
            {
                return NotFound();
            }
            return View(muvekkilTurleri);
        }

        // POST: MuvekkilTurleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("muvekkilTuruId,muvekkilTuruAdi")] MuvekkilTurleri muvekkilTurleri)
        {
            if (id != muvekkilTurleri.muvekkilTuruId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muvekkilTurleri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuvekkilTurleriExists(muvekkilTurleri.muvekkilTuruId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(muvekkilTurleri);
        }

        // GET: MuvekkilTurleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muvekkilTurleri = await _context.muvekkilTurleri
                .FirstOrDefaultAsync(m => m.muvekkilTuruId == id);
            if (muvekkilTurleri == null)
            {
                return NotFound();
            }

            return View(muvekkilTurleri);
        }

        // POST: MuvekkilTurleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var muvekkilTurleri = await _context.muvekkilTurleri.FindAsync(id);
            _context.muvekkilTurleri.Remove(muvekkilTurleri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuvekkilTurleriExists(int id)
        {
            return _context.muvekkilTurleri.Any(e => e.muvekkilTuruId == id);
        }
    }
}
