using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForToday.Models;

namespace WeatherForToday.ViewModels
{
    public class SelectRegion
    {
        public string Region { get; set; }
        public List<SelectListItem> AllRegions { get; set; }
    }
}
