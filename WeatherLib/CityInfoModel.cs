using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherLib
{
    public class CityInfoModel
    {

        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public Region Region { get; set; }
        public Country Country { get; set; }
        public AdministrativeArea AdministrativeArea { get; set; }
        public TimeZone TimeZone { get; set; }
        public GeoPosition GeoPosition { get; set; }
        public bool IsAlias { get; set; }
        public SupplementalAdminArea[] SupplementalAdminAreas { get; set; }
        public string[] DataSets { get; set; }
        public ParentCity ParentCity { get; set; }
    }


    public class ParentCity
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class GeoPosition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Elevation Elevation { get; set; }
    }

    public class Elevation
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

 

    public class TimeZone
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public float GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public DateTime? NextOffsetChange { get; set; }
    }

    public class AdministrativeArea
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public int Level { get; set; }
        public string LocalizedType { get; set; }
        public string EnglishType { get; set; }
        public string CountryID { get; set; }
    }

    public class Country
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class Region
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public partial class SupplementalAdminArea
    {
        public int Level { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public enum DataSet { AirQuality, AirQualityRegional, Alerts, DailyAirQualityForecast, DailyLocalIndices, DailyPollenForecast, ForecastConfidence, HourlyLocalIndices, MinuteCast, PremiumAirQuality };

}
