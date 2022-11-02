using Newtonsoft.Json;
using WebsiteProjectCarpetMart.Models;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.BusinessLogic
{
    public class WeatherBL
    {
        public static async Task<WeatherViewModel> GetWeatherViewModel(string city, List<WeatherViewModel> weatherList)
        {
            for (int i = 0; i < weatherList.Count; i++)
            {
                if(weatherList[i].Name == city)
                {
                    if((DateTime.UtcNow - weatherList[i].DateTimeUpdated).TotalMinutes >= 10)
                    {
                        weatherList.Remove(weatherList[i]);
                    }
                    else
                    {
                        return weatherList[i];
                    }
                }
            }
            WeatherAPIModel wam = new WeatherAPIModel();
            string apiKey = "710f85fcadb00029bbf5074c54cefe19";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city},US&appid={apiKey}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                wam = JsonConvert.DeserializeObject<WeatherAPIModel>(responseBody);                
            }
            WeatherViewModel weather = ConvertWeatherAPIModelToWeatherModel(wam);
            weather.index = weatherList.Count;
            weatherList.Add(weather);
            return weather;
        }
        public static WeatherViewModel ConvertWeatherAPIModelToWeatherModel(WeatherAPIModel wam)
        {
            WeatherViewModel weather = new WeatherViewModel();
            weather.DateTimeUpdated = DateTime.UtcNow;
            weather.Name = wam.name;
            weather.Temp = (int)(1.8 * (wam.main.temp - 273) + 32);
            weather.FeelsLike = (int)(1.8 * (wam.main.feels_like - 273) + 32);
            weather.SkyCondition = wam.weather[0].description;
            return weather;
        }
        
	}
}
