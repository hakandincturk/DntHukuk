using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("DosyaDurumu")]
    public class DosyaDurumu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dosyaDurumuId { get; set; }

        [Required]
        [DisplayName("İcra Hukuku Müvekkil Konumu")]
        [Column(TypeName = "nvarchar(55)")]
        public string dosyaDurumuTuru { get; set; }
    }
}
