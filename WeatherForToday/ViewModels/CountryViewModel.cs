using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForToday.ViewModels
{
    public class CountryViewModel
    {
        public string Country { get; set; }
        public List<SelectListItem> CountryList { get; set; }

    }
}
