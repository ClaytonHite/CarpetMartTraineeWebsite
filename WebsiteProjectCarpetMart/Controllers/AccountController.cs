using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using WebsiteProjectCarpetMart.BusinessLogic;
using WebsiteProjectCarpetMart.ViewModels;
namespace WebsiteProjectCarpetMart.Controllers
{
    public class AccountController : Controller
    {
        public AccountViewModel accountViewModel;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditProfile()
        {
            IdentityUser user = new IdentityUser();
            UserBL userBL = new UserBL();
            userBL.CheckExistingProfile(user.Id);
            return View();
        }
        public IActionResult Login(AccountViewModel avm)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();
            string constring = configuration.GetValue<string>("ConnectionStrings:Default");
            if (avm.Username == null || avm.Password == null)
            {
                avm.EntrySuccessfull = false;
            }
            else
            {
                AccountBL accBL = new AccountBL();
                accountViewModel = accBL.VerifyAccount(avm);
            }
            return View("Login", accountViewModel);
        }
        public IActionResult RegisterAccount(AccountViewModel avm)
        {
            return View("RegisterAccount", accountViewModel);
        }
    }
}
