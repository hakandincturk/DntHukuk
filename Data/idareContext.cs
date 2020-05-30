using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Models;

namespace DntHukuk.Web.Data
{
    public class idareContext : DbContext
    {
        public idareContext (DbContextOptions<idareContext> options)
            : base(options)
        {
        }

        public DbSet<DntHukuk.Web.Models.Dosyalar> Dosyalar { get; set; }
    }
}
