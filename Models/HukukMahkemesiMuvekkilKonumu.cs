using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("HukukMahkemesiMuvekkilKonumu")]
    public class HukukMahkemesiMuvekkilKonumu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int hukukMahkemesiMuvekkilKonumuId { get; set; }

        [Required]
        [DisplayName("Hukuk Mahkemesi Muvekkil Konumu")]
        [Column(TypeName = "nvarchar(55)")]
        public string hukukMahkemesiMuvekkilKonumuTuru { get; set; }
    }
}
