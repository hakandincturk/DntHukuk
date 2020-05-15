using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.Models
{
    [Table("muvekkilTuru")]
    public class MuvekkilTurleri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int muvekkilTuruId { get; set; }

        public string muvekkilTuruAdi { get; set; }
    }
}
