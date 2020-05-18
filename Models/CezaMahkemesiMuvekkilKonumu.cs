using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("CezaHukukuMuvekkilKonumu")]
    public class CezaMahkemesiMuvekkilKonumu
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cezaHukukuMuvekkilKonumuId { get; set; }

        [Required]
        [DisplayName("Ceza Mahkemesi Muvekkil Konumu")]
        [Column(TypeName = "nvarchar(55)")]
        public string cezaHukukuMuvekkilKonumuTuru { get; set; }
    }
}
