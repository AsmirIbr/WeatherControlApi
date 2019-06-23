using System.ComponentModel.DataAnnotations;

namespace WeatherControlApp.Models
{
    public class Users
    {

        public int Id {get; set;}
        public string Firstname {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
    }
    
}