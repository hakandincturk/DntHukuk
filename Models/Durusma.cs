using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("Durusma")]
    public class Durusma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DurusmaId { get; set; }

        [Required]
        [Display(Name = "Dosya")]
        public int DosyaId { get; set; }

        [Required]
        [Display(Name = "Duruşma Türü")]
        [Column(TypeName = "int")]
        public int DurusmaTuruId { get; set; }

        [Required]
        [Display(Name = "Duruşma Adı")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DurusmaAdi{ get; set; }

        [Required]
        [Display(Name = "Mahkeme Açıklama")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string MahkemeAciklama { get; set; }

        [Display(Name = "Duruşma Tarihi")]
        [Column(TypeName = "DateTime")]
        public DateTime DurusmaTarihi { get; set; }
    }
}