using System;

namespace MetaWeatherLibrary.Models
{
    public class Consolidated_Weather
    {
        public float Air_pressure { get; set; }
        public string Applicable_date { get; set; }
        public DateTime Created { get; set; }
        public int Humidity { get; set; }
        public long Id { get; set; }
        public float Max_temp { get; set; }
        public float Min_temp { get; set; }
        public int Predictability { get; set; }
        public float The_temp { get; set; }
        public float Visibility { get; set; }
        public string Weather_state_abbr { get; set; }
        public string Weather_state_name { get; set; }
        public float Wind_direction { get; set; }
        public string Wind_direction_compass { get; set; }
        public float Wind_speed { get; set; }
    }
}