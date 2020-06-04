using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DntHukuk.Web.ViewModel
{
    public class ApplicationUserViewModel
    {

        [PersonalData]
        [Column(TypeName = "nvarchar(55)")]
        public string userFirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(55)")]
        public string userLastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(75)")]
        public string userEmail { get; set; }

        [PersonalData]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [PersonalData]
        public IFormFile userImagePath { get; set; }
    }
}
