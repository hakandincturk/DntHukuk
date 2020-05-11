using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DntHukuk.Web.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
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
        [DataType(DataType.Text)]
        public int userAccesLevel { get; set; }
    }
}
