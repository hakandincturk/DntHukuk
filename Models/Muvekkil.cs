using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("Muvekkil")]
    public class Muvekkil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid muvekkilId{ get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Müvekkil Adı")]
        public string muvekkilAdi { get; set; }

        [Display(Name = "Müvekkil Soyadı")]
        [Column(TypeName = "nvarchar(100)")]
        public string muvekkilSoyAdi { get; set; }

        [Display(Name = "Müvekkil TC")]
        [Column(TypeName = "nvarchar(11)")]
        public string muvekkilTc { get; set; }

        [Required]
        [Display(Name = "Müvekkil Türü")]
        [Column(TypeName = "int")]
        public int muvekkilTuruId { get; set; }

        [Display(Name = "Sorumlu Avukat")]
        public Guid muvekkilSorumluAvukat { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string muvekkilEmaik { get; set; }

        [Display(Name = "Müvekkil Telefon")]
        [Column(TypeName = "nvarchar(21)")]
        public string muvekkilTelefon { get; set; }

        [Display(Name = "Müvekkil Adres")]
        [Column(TypeName = "nvarchar(155)")]
        public string muvekkilAdres { get; set; }

        [Display(Name = "Müvekkil Açıklama")]
        [Column(TypeName = "nvarchar(155)")]
        public string muvekkilAciklama { get; set; }

        [Display(Name = "Müvekkil Evrak")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string muvekkilEvrakPath { get; set; }


        [Display(Name = "Müvekkil Vergi Dairesi")]
        [Column(TypeName = "nvarchar(100)")]
        public string muvekkilVergiDairesi { get; set; }


        [Display(Name = "Müvekkil Vergi No")]
        [Column(TypeName = "nvarchar(100)")]
        public string muvekkilVergiNo { get; set; }


        [Display(Name = "Müvekkil Yetkili İsim")]
        [Column(TypeName = "nvarchar(100)")]
        public string muvekkilYetkiliIsim { get; set; }


        [Column(TypeName = "DateTime")]
        [Display(Name = "Müvekkil Üyelik Tarihi")]
        public DateTime muvekkilUyelikTarihi { get; set; }

        public Muvekkil()
        {
            this.muvekkilUyelikTarihi = DateTime.Now;
        }

    }
}
