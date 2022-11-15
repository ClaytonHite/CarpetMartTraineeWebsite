using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebsiteProjectCarpetMart.BusinessLogic;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult ClassList()
        {
            ClassBL classBL = new ClassBL();
            List<ClassViewModel> cVMList = classBL.ClassList();
            return View(cVMList);
        }

        // GET: ClassController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
