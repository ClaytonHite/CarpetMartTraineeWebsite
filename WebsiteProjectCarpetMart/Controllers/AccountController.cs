using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult RegisterAccount(AccountViewModel avm)
        {
            return View("RegisterAccount", accountViewModel);
        }
    }
}
