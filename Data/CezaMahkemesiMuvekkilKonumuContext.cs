using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DntHukuk.Web.Models;

namespace DntHukuk.Web.Data
{
    public class CezaMahkemesiMuvekkilKonumuContext : DbContext
    {
        public CezaMahkemesiMuvekkilKonumuContext (DbContextOptions<CezaMahkemesiMuvekkilKonumuContext> options)
            : base(options)
        {
        }

        public DbSet<DntHukuk.Web.Models.CezaMahkemesiMuvekkilKonumu> CezaMahkemesiMuvekkilKonumu { get; set; }
    }
}
