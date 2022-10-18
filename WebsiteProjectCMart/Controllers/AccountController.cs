using Microsoft.AspNetCore.Mvc;
using WebsiteProjectCMart.BusinessLogic;
using WebsiteProjectCMart.Models;
using WebsiteProjectCMart.ViewModels;

namespace WebsiteProjectCMart.Controllers
{
	public class AccountController : Controller
	{
        public AccountViewModel accountViewModel;
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Login(AccountViewModel avm)
        {
            if(avm.Username == null || avm.Password == null)
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
    }
}
