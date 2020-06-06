using System;

namespace MetaWeatherLibrary.Models
{
    public class LocationModel
    {
        public Consolidated_Weather[] Consolidated_weather { get; set; }
        public string Latt_long { get; set; }
        public string Location_type { get; set; }
        public Parent Parent { get; set; }
        public Source[] Sources { get; set; }
        public DateTime Sun_rise { get; set; }
        public DateTime Sun_set { get; set; }
        public DateTime Time { get; set; }
        public string Timezone { get; set; }
        public string Timezone_name { get; set; }
        public string Title { get; set; }
        public int Woeid { get; set; }
    }
}