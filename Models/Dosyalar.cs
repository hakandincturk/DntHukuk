using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("Dosyalar")]
    public class Dosyalar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DosyaId { get; set; }

        [Required]
        [Display(Name = "Sorumlu Avukat Adı Soyadı")]
        public Guid SorumluAvukatId { get; set; }

        [Required]
        [Display(Name = "Müvekkil Adı Soyadı")]
        public Guid MuvekkilId { get; set; }

        [Required]
        [Display(Name = "Müvekkil Konumu")]
        [Column(TypeName = "int")]
        public int MuvekkilKonumuId { get; set; }

        [Required]
        [Display(Name = "Dosya Durumu")]
        [Column(TypeName = "int")]
        public int DosyaDurumuId { get; set; }

        [Display(Name = "Başlama Tarihi")]
        [Column(TypeName = "DateTime")]
        public DateTime DosyaBaslamaTarihi { get; set; }

        [Column(TypeName = "DateTime")]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime DosyaBitisTarihi { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Dosya Adı")]
        public string DosyaAdi { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Şehir")]
        public string DosyaSehir { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "İlçe")]
        public string DosyaIlce { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Mahkeme")]
        public string DosyaMahkemeAdi { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Sıra No")]
        public string DosyaSiraNo { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Konu")]
        public string DosyaKonu { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Son Durum/Açıklama")]
        public string DosyaSonDurum { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Müvekkil Evrakları")]
        public string DosyaMuvekkilEvraklariPath { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Karşı Taraf Evrakları")]
        public string DosyaKarsiTarafEvraklariPath { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Merci Evrakları")]
        public string DosyaMerciEvraklari { get; set; }

        [Column(TypeName = "int")]
        [Display(Name = "Karşı Taraf")]
        public int DosyaKarsiTarafId { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Karşı Taraf Bilgi")]
        public string DosyaKarsiTarafBilgi { get; set; }

        [Column(TypeName = "int")]
        public int DosyaTuru { get; set; }

    }
}