using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebsiteProjectCarpetMart.BusinessLogic;
using WebsiteProjectCarpetMart.ViewModels;
namespace WebsiteProjectCarpetMart.Controllers
{
    public class AccountController : Controller
    {
        private UserViewModel _uvm = new UserViewModel();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProfile(UserViewModel uvm)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserBL userBL = new UserBL();
            _uvm = userBL.CheckExistingProfile(userId);
            if(uvm.FirstName == null || uvm.MiddleName == null || uvm.LastName == null || uvm.AddressLine1 == null)
            {
                return View(_uvm);
            }
            if(_uvm.Account_Id > 0)
            {
                return View(_uvm);
            }
            _uvm = userBL.AddUserProfile(uvm, userId);
            return RedirectToAction("Profile", _uvm);
        }
        public IActionResult EditProfile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			UserBL userBL = new UserBL();
			_uvm = userBL.CheckExistingProfile(userId);
            return View(_uvm);
        }
        public IActionResult Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserBL userBL = new UserBL();
            _uvm = userBL.CheckExistingProfile(userId);
            return View(_uvm);
        }
        public IActionResult EditProfileButton(UserViewModel uvm)
        {
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			UserBL userBL = new UserBL();
			_uvm = userBL.CheckExistingProfile(userId);
            _uvm = userBL.UpdateUserProfile(uvm, userId);

            return RedirectToAction("Profile", _uvm);
		}
        public IActionResult DeleteProfile()
        {
            int result;
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserBL userBL = new UserBL();
            _uvm = userBL.CheckExistingProfile(userId);
            result = userBL.DeleteProfile(userId);
            if(result == 0)
            {
                return View();
            }
            return View();
        }
    }
}
