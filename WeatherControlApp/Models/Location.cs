using System.ComponentModel.DataAnnotations;

namespace WeatherControlApp.Models
{
    public class Location
    {

        public int Id {get; set;}
        public string Name {get; set;}
        public string Country {get; set;}
        public int ZipCode {get; set;}
    }
    
}