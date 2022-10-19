using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebsiteProjectCarpetMart.Models;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.Controllers
{
    public class HomeController : Controller
    {
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
            if (wvm.name == null)
            {

            }
            else
            {
                //wvm = await GetWeatherViewModel(wvm.name);
                //return View(wvm);
                return RedirectToAction("WeatherView", await GetWeatherViewModel(wvm.name));
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        static async Task<WeatherViewModel> GetWeatherViewModel(string city)
        {
            WeatherViewModel wvm = new WeatherViewModel();
            string apiKey = "710f85fcadb00029bbf5074c54cefe19";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city},US&appid={apiKey}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                wvm = JsonConvert.DeserializeObject<WeatherViewModel>(responseBody);
            }
            return wvm;
        }
        public IActionResult WeatherView(WeatherViewModel wvm)
        {
            return View(wvm);
        }
    }
}