using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Realcommerce_Fullstack.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace Realcommerce_Fullstack.Controllers
{
	[Route("api/CityWeather")]
	public class CityWeatherController : Controller
	{
		private IConfiguration _configuration;
		private readonly TaliaWeatherContext _context;
		private readonly IHostingEnvironment hostEnvironment;
		private string apiKey;
		private bool prod = false;
		public CityWeatherController(IConfiguration configuration, IHostingEnvironment httpHostEnvironment, TaliaWeatherContext weatherContext)
		{
			_configuration = configuration;
			_context = weatherContext;
			hostEnvironment = httpHostEnvironment;
			apiKey = _configuration["apiKey"];

		}

		[HttpGet]
		[Route("Search")]
		public IActionResult GetCities(String query)
		{
			if (String.IsNullOrEmpty(query))
				return Ok();
			
			var url = @"http://dataservice.accuweather.com/locations/v1/cities/autocomplete" + "?apikey=" + apiKey + "&q=" + query;

			var res = getAccuweatherData(url);
			return Ok(res);

		}
		[HttpGet]
		[Route("GetCurrentWeather")]
		public IActionResult GetCurrentWeather(String query)
		{
			if (String.IsNullOrEmpty(query))
				return Ok();
			var url = @"http://dataservice.accuweather.com/currentconditions/v1/" + query + "?apikey=" + apiKey;
			var cityWeather = _context.CityWeathers.Find(query);

			if (cityWeather == null)
			{
				JToken weather;

				weather = getAccuweatherData(url)[0];

				Weather cityWeatherItem = new Weather()
				{
					TemperatureC = Double.Parse(weather["Temperature"]["Metric"]["Value"].ToString()),
					WeatherText = weather["WeatherText"].ToString()
				};
				return Ok(cityWeatherItem);
			}
			return Ok(cityWeather);
		}




		[HttpGet]
		[Route("GetCityWeatherItems")]
		public ActionResult<IEnumerable<CityWeather>> GetCityWeatherItems()
		{
			return _context.CityWeathers.ToList();
		}

		[HttpGet]
		[Route("GetCityWeatherItem")]
		public ActionResult<CityWeather> GetCityWeatherItem(string key)
		{
			var cityWeather = _context.CityWeathers.Find(key);

			if (cityWeather == null)
			{
				return NotFound();
			}

			return cityWeather;
		}

		[HttpPost]
		[Route("AddToCityWeathers")]
		public IActionResult AddToCityWeathers([FromBody] CityWeather item)
		{
			if (item == null)
				return Ok();

			_context.CityWeathers.Add(item);
			_context.SaveChanges();

			return CreatedAtAction(nameof(GetCityWeatherItem), new { key = item.Key }, item);

		}
		[HttpPost]
		[Route("DeleteCityWeather")]
		public IActionResult DeleteCityWeather([FromBody] String query)
		{
			if (String.IsNullOrEmpty(query))
				return Ok();

			var cityWeather = _context.CityWeathers.Find(query);

			if (cityWeather == null)
			{
				return NotFound();
			}

			_context.CityWeathers.Remove(cityWeather);
			_context.SaveChanges();

			return NoContent();

		}

		private JArray getAccuweatherData(string url)
		{

			HttpResponseMessage res = new HttpResponseMessage();
			HttpClient client = new HttpClient();
			try
			{
				res = client.GetAsync(url).Result;
			}
			catch (Exception e) { }

			if (res.IsSuccessStatusCode)
				return res.Content.ReadAsAsync<JArray>().Result;
			return null;
		}


	}
}
