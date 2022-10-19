using Microsoft.AspNetCore.Mvc;

namespace WebsiteProjectCarpetMart.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
