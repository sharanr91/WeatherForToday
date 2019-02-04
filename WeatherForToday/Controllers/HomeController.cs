using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherForToday.Models;
using WeatherLib;

namespace WeatherForToday.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            ApiHelper.InitializeClient();
        }
        //ApiHelper.InitializeClient();
        public IActionResult Index()
        {
            return View();
        }

        [httpPost]
        public async Task<IActionResult> WeatherResult(LocationModel key)
        {
            if (ModelState.IsValid)
            {
                //perth key = 26797
                var weatherData = await GetWeatherData.LoadWeatherData(Convert.ToInt32( key.LocationKey));
                ViewBag.result = weatherData;
                var weatherDatalist = JsonConvert.DeserializeObject<List<WeatherInfoModel>>(weatherData);
                //WeatherInfoModel wm = new WeatherInfoModel();
                //wm = JsonConvert.DeserializeObject<WeatherInfoModel>(weatherData.Substring(1,weatherData.Length-2));
                WeatherInfoModel wm = weatherDatalist[0];
                return View(wm);
            }
            else
            {
                return View("Index");
            }
           
        }

        //public IActionResult WeatherResult()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://dataservice.accuweather.com");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Add("apikey", "KAsv18xGJd2pRClNCSKaDLR4NOx9HCPM");
        //    HttpResponseMessage response = client.GetAsync("/currentconditions/v1/26797?apikey=KAsv18xGJd2pRClNCSKaDLR4NOx9HCPM").Result;
        //    WeatherInfoModel wInfomodel = new WeatherInfoModel();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        ViewBag.result = response.ToString();
        //        //ViewBag.result = response.Content.ReadAsAsync<WeatherInfoModel>().Result;
        //    }
        //    else
        //    {
        //        ViewBag.result = "Error";
        //    }

        //    return View();
        //}
    }
}