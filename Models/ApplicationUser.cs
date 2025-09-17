using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CMCSWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Module")]
        public string Module { get; set; }

        [Required]
        [Display(Name = "Qualification")]
        public string Qualification { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }

}
