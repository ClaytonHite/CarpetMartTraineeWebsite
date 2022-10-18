using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebsiteProjectCMart.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [Required]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string AddressLine1 { get; set; }
        [Display(Name = "Apt or Unit #")]
        public string AddressLine2 { get; set; }
        [Display(Name = "City")]
        [Required]
        public string City { get; set; }
        [Display(Name = "State")]
        [Required]
        public string State { get; set; }
        [Display(Name = "Zip")]
        [Required]
        public string Zip { get; set; }
        [Display(Name = "Phone")]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Account")]
        [Required]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
    }
}
