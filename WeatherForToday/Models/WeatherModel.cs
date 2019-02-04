using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForToday.Models
{
    public class WeatherModel
    {
        public string WeatherText { get; set; }
        public bool IsDayTime { get; set; }
        //public float TemperatureValue { get; set; }
        //public char UnitType { get; set; }
        public string LocalObservationDateTime { get; set; }


    }
}
