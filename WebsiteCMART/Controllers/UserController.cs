using Microsoft.AspNetCore.Mvc;

namespace WebsiteProjectCMart.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
