using DataLibrary.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using WebsiteProjectCarpetMart.BusinessLogic;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.Controllers
{
    public class ClassController : Controller
    {
        private ClassBL _classBL;
        private RegisteredClassesBL _registeredClassesBL;
        public ClassController(ClassBL classBL, RegisteredClassesBL registeredClassesBL)
        {
            _classBL = classBL;
            _registeredClassesBL = registeredClassesBL;
        }
        public IActionResult ClassList()
        {
            List<ClassViewModel> rCVMList = _classBL.ClassList();
            return View(rCVMList);
        }
        public IActionResult AddClass(ClassViewModel cVM)
        {
            if (ModelState.IsValid)
            {
                cVM = _classBL.AddClass(cVM);
                return RedirectToAction("ClassList");
            }
            return View(cVM);
        }
        public ActionResult RegisterForClass(string className)
        {
            className = _classBL.RegisterForClass(className, User.FindFirstValue(ClaimTypes.NameIdentifier));
            ClassViewModel cVM = new ClassViewModel();
            cVM.ClassName = className;
            return View(cVM);
        }
        public IActionResult ViewRegisteredTraineesByClass(string className)
        {
            List<RegisteredClassesViewModel> rCVMList = _registeredClassesBL.GetListOfTraineesForClass(className);
            for (int i = 0; i < rCVMList.Count; i++)
            {
                if (rCVMList[i].ClassViewModel.ClassName == className)
                {
                    return View(rCVMList[i]);
                }
            }
            RegisteredClassesViewModel rCVM = new RegisteredClassesViewModel();
            rCVM.UserViewModelList = new List<UserViewModel>();
            return View(rCVM);
        }
    }
}
