using System;
using System.Collections.Generic;
using System.Text;

namespace MetaWeatherLibrary.Models
{

    public class SearchQueryItem
    {
        public string Title { get; set; }
        public string Location_type { get; set; }
        public int WoeId { get; set; }
        public string Latt_long { get; set; }
    }
}