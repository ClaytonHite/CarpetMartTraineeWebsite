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
        private UserBL _userBL;
        public AccountController(UserBL userBL)
        {
            _userBL = userBL;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProfile(UserViewModel uvm)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _uvm = _userBL.CheckExistingProfile(userId);
            if(uvm.FirstName == null || uvm.MiddleName == null || uvm.LastName == null || uvm.AddressLine1 == null ||
                uvm.City == null || uvm.State == null || uvm.Phone == null || uvm.Email == null)
            {
                return View(uvm);
            }
            if(_uvm.Account_Id > 0)
            {
                return View(_uvm);
            }
            _uvm = _userBL.AddUserProfile(uvm, userId);
            return RedirectToAction("Profile", _uvm);
        }
        public IActionResult EditProfile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			_uvm = _userBL.CheckExistingProfile(userId);
            return View(_uvm);
        }
        public IActionResult Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _uvm = _userBL.CheckExistingProfile(userId);
            return View(_uvm);
        }
        public IActionResult EditProfileButton(UserViewModel uvm)
        {
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			_uvm = _userBL.CheckExistingProfile(userId);
            if (uvm.FirstName == null || uvm.MiddleName == null || uvm.LastName == null || uvm.AddressLine1 == null ||
                uvm.City == null || uvm.State == null || uvm.Phone == null || uvm.Email == null)
            {
                return RedirectToAction("EditProfile", uvm);
            }
            _uvm = _userBL.UpdateUserProfile(uvm, userId);

            return RedirectToAction("Profile", _uvm);
		}
        public IActionResult DeleteProfile()
        {
            int result;
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            result = _userBL.DeleteProfile(userId);
            if(result == 0)
            {
                return View();
            }
            return View();
        }
    }
}
