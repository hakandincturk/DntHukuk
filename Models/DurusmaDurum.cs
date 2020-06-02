using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("DurusmaDurum")]
    public class DurusmaDurum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DurusmaDurumId { get; set; }

        [Required]
        [Display(Name = "Duruşma Durumu")]
        [Column(TypeName = "nvarchar(100)")]
        public string DurusmaDurumu { get; set; }
    }
}
