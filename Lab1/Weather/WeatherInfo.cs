using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public class WeatherInfo
    {
        public int? cod { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public int dt { get; set; }
        public WeatherInfoMain? main { get; set; }
        public WeatherInfoWind? wind { get; set; }
        public IList<WeatherInfoWeatherItem>? weather { get; set; }
        //public WeatherInfoWeatherItem weather { get; set; }
        //public string? dt_txt { get; set; }
    }
}
