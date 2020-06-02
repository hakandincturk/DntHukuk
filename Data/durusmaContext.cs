using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Models;

namespace DntHukuk.Web.Data
{
    public class durusmaContext : DbContext
    {
        public durusmaContext (DbContextOptions<durusmaContext> options)
            : base(options)
        {
        }

        public DbSet<DntHukuk.Web.Models.Durusma> Durusma { get; set; }
    }
}
