using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebsiteProjectCMart.Controllers
{
	public class Classes : Controller
	{
		// GET: Classes
		public ActionResult Index()
		{
			return View();
		}

		// GET: Classes/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Classes/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Classes/Create
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

		// GET: Classes/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Classes/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
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

		// GET: Classes/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Classes/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
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
