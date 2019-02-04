using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForToday.Models
{
    public class LocationModel
    {
        [Required(ErrorMessage = "Please enter location ID")]
        public string LocationKey { get; set; }

    }
}
