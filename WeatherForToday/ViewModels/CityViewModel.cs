using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForToday.ViewModels
{
    public class CityViewModel
    {
        public string CityId { get; set; }
        public List<SelectListItem> CitiesList { get; set; }
    }
}
