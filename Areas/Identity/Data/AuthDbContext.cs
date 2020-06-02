using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DntHukuk.Web.Areas.Identity.Data;
using DntHukuk.Web.Models;
using DntHukuk.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DntHukuk.Web.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<MuvekkilTurleri> muvekkilTurleri { get; set; }
        public DbSet<Muvekkil> Muvekkil { get; set; }
        public DbSet<IcraHukukuMuvekkilKonumu> IcraHukukuMuvekkilKonumu { get; set; }
        public DbSet<HukukMahkemesiMuvekkilKonumu> HukukMahkemesiMuvekkilKonumu { get; set; }
        public DbSet<CezaMahkemesiMuvekkilKonumu> CezaMahkemesiMuvekkilKonumu { get; set; }
        public DbSet<IdareMahkemesiMuvekkilKonumu> IdareMahkemesiMuvekkilKonumu { get; set; }
        public DbSet<IdareMahkemesiMahkemeTuru> IdareMahkemesiMahkemeTuru { get; set; }
        public DbSet<DosyaDurumu> DosyaDurumu { get; set; }
        public DbSet<Dosyalar> Dosyalar { get; set; }
        public DbSet<Notlar> Notlar { get; set; }
        public DbSet<DurusmaDurum> DurusmaDurum { get; set; }
        public DbSet<Durusma> Durusma { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
