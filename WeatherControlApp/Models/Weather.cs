namespace WeatherControlApp.Models
{
    public class Weather
    {

        public int Id {get; set;}
        public int Temperature {get; set;}
        public string Humidity {get; set;}
        public WeatherType Type {get; set;}
        // [EnumDataType(typeof(WeatherType), ErrorMessage = "Weather type value doesn't exist within enum")]
        // public WeatherType Type { get; set;}
    }
    

    public enum WeatherType
    {
        Rain,
        Storm,
        Sun,
        Clouds,
        Windy,
        Hurricanes,
        Fog,
        Snow
    }
}