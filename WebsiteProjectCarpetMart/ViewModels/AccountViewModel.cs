using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebsiteProjectCMart.ViewModels
{
    public class AccountViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EntrySuccessfull { get; set; }
    }
}
