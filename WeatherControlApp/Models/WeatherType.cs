using System.ComponentModel.DataAnnotations;

namespace WeatherControlApp.Models
{
    public class WeatherType
    {

        public int Id {get; set;}
        public string Rain {get; set;}
        public string Storm {get; set;}
        public string Sun {get; set;}
        public string Clouds {get; set;}
        public string Windy {get; set;}
        public string Fog {get; set;}
       
    }
}  

    //  public enum WeatherType
    // {
    //     Rain,
    //     Storm,
    //     Sun,
    //     Clouds,
    //     Windy,
    //     Hurricanes,
    //     Fog,
    //     Snow
    // }