using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherForToday.Models;
using WeatherForToday.ViewModels;
using WeatherLib;

namespace WeatherForToday.Controllers
{
    public class HomeController : Controller
    {

        private IHttpContextAccessor _accessor;


        public HomeController(IHttpContextAccessor accessor)
        {
            ApiHelper.InitializeClient();
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            IEnumerable<RegionModel> Regions = new List<RegionModel>
             {
                new RegionModel{ID="AFR",LocalizedName="Africa",EnglishName="Africa"},
                new RegionModel{ID="ANT",LocalizedName="Antarctica",EnglishName="Antarctica"},
                new RegionModel{ID="ARC",LocalizedName="Arctic",EnglishName="Arctic"},
                new RegionModel{ID="ASI",LocalizedName="Asia",EnglishName="Asia"},
                new RegionModel{ID="CAC",LocalizedName="Central America",EnglishName="Central America"},
                new RegionModel{ID="EUR",LocalizedName="Europe",EnglishName="Europe"},
                new RegionModel{ID="MEA",LocalizedName="Middle East",EnglishName="Middle East"},
                new RegionModel{ID="NAM",LocalizedName="North America",EnglishName="North America"},
                new RegionModel{ID="OCN",LocalizedName="Oceania",EnglishName="Oceania"},
                new RegionModel{ID="SAM",LocalizedName="South America",EnglishName="South America"}
             };

            List<SelectListItem> listToRender = Regions.Select(r => new SelectListItem
            {
                Text = r.EnglishName,
                Value = r.ID
            }).ToList();

            SelectRegion selectRegionModel = new SelectRegion();
            selectRegionModel.AllRegions = listToRender;

            return View(selectRegionModel);
        }

        [httpPost]
        public async Task<IActionResult> SelectCountry(string Region)
        {
            string url = $"http://dataservice.accuweather.com/locations/v1/countries/{ Region }?apikey=KAsv18xGJd2pRClNCSKaDLR4NOx9HCPM";
            var countryDataString = await CallApiEndPoint.LoadDataFromGivenUrl(url);
            var countryList = JsonConvert.DeserializeObject<List<CountryModel>>(countryDataString);
            List<SelectListItem> countryListToRender = countryList.Select(c => new SelectListItem
            {
                Text = c.EnglishName,
                Value = c.ID
            }).ToList();
            ViewBag.sr = Region;
            CountryViewModel cvm = new CountryViewModel();
            cvm.CountryList = countryListToRender;
            return View(cvm);
        }

        [httpPost]
        public async Task<IActionResult> SelectCity(string Country)
        {
            var topcitiesDataString = await GetAllCities.LoadAllCitiesData();
            var citiesList = JsonConvert.DeserializeObject<List<CityInfoModel>>(topcitiesDataString);
            var topCitiesFromCountry = citiesList.Where(city => city.Country.ID == Country);

            if (topCitiesFromCountry.Count() == 0)
            {
                //return city search view
                //get admin area list
                /*
                string url = $"http://dataservice.accuweather.com/locations/v1/adminareas/{ Country }?apikey=KAsv18xGJd2pRClNCSKaDLR4NOx9HCPM";
                var adminAreasData = await CallApiEndPoint.LoadDataFromGivenUrl(url);
                var adminAreaList = JsonConvert.DeserializeObject<List<AdminAreaModel>>(adminAreasData);*/
                CitySearchModel csm = new CitySearchModel();
                csm.CountryCode = Country;

                return View("CitySearch",csm);
            }
            else
            {
                //return available cities
                List<SelectListItem> cityListToRender = topCitiesFromCountry.Select(city => new SelectListItem
                {
                    Text = city.EnglishName,
                    Value = city.Key
                }).ToList();
                CityViewModel cityvm = new CityViewModel();
                cityvm.CitiesList = cityListToRender;

                return View(cityvm);
            }
        }

        public IActionResult CitySearch()
        {
            return View();
        }
        
        [httpPost]
        public async Task<IActionResult> CitySearchResults(CitySearchModel csm)
        {
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/{ csm.CountryCode }/search?apikey=KAsv18xGJd2pRClNCSKaDLR4NOx9HCPM&q={csm.SearchString}";

            var citySearchData = await CallApiEndPoint.LoadDataFromGivenUrl(url);
            var citiesList = JsonConvert.DeserializeObject<List<CityInfoModel>>(citySearchData);
            List<SelectListItem> cityListToRender = citiesList.Select(city => new SelectListItem
            {
                Text = city.EnglishName,
                Value = city.Key
            }).ToList();
            CityViewModel cityvm = new CityViewModel();
            cityvm.CitiesList = cityListToRender;
            return View("SelectCity",cityvm);


        }

        [httpPost]
        public async Task<IActionResult> WeatherResult(CityViewModel cvm)
        {
            var weatherDataString = await GetWeatherData.LoadWeatherData(cvm.CityId);
            var weatherDatalist = JsonConvert.DeserializeObject<List<WeatherInfoModel>>(weatherDataString);
            WeatherInfoModel wm = weatherDatalist[0];

            return View(wm);

        }

    }
}