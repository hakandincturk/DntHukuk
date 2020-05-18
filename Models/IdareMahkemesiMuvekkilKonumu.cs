using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("IdareMahkemesiMuvekkilKonumu")]
    public class IdareMahkemesiMuvekkilKonumu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idareMahkemesiMuvekkilKonumuId { get; set; }

        [Required]
        [DisplayName("İdare Mahkemesi Muvekkil Konumu")]
        [Column(TypeName = "nvarchar(55)")]
        public string idareMahkemesiMuvekkilKonumuTuru { get; set; }
    }
}
