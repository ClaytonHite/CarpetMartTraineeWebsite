using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebsiteProjectCarpetMart.Models;
using WebsiteProjectCarpetMart.BusinessLogic;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.Controllers
{
    public class HomeController : Controller
    {
        static List<WeatherViewModel> _weatherList = new List<WeatherViewModel>();
        static WeatherViewModel _weather;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Weather(WeatherViewModel wvm)
        {
            if (wvm.Name == null)
            {

            }
            else
            {
                wvm = await WeatherBL.GetWeatherViewModel(wvm.Name, _weatherList);
                _weather = wvm;
                return RedirectToAction("GetWeather");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult GetWeather()
        {
            return View(_weather);
        }
    }
}