﻿using DntHukuk.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewComponents
{
    public class MuvekkilTurleriDropDownViewComponent : ViewComponent
    {
        private readonly AuthDbContext _context;

        public MuvekkilTurleriDropDownViewComponent(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? muvekkilTuruId)
        {
            ViewBag.muvekkilTuruId = muvekkilTuruId ?? null;
            return View(await _context.muvekkilTurleri.ToListAsync());
        }
    }
}
