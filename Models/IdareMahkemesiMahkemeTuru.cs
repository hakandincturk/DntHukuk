using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("IdareMahkemesiMahkemeTuru")]
    public class IdareMahkemesiMahkemeTuru
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idareMahkemesiMahkemeTuruId { get; set; }

        [Required]
        [DisplayName("İdare Mahkemesi Mahkeme Türü")]
        [Column(TypeName = "nvarchar(55)")]
        public string idareMahkemesiMahkemeTuruu { get; set; }
    }
}
