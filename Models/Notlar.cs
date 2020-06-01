using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("Notlar")]
    public class Notlar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int notId { get; set; }

        [Required]
        [Display(Name = "Not")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Not { get; set; }
    }
}
