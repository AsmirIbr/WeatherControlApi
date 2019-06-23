using Microsoft.EntityFrameworkCore;

namespace WeatherControlApp.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) :base (options)
        {

        }

        public DbSet<Weather> WeatherItems {get; set;}
        public DbSet<WeatherType> WeatherType {get; set;}
        public DbSet<Location> Location {get; set;}

        public DbSet<Users> Users {get; set;}
        // public DbSet<LoginDto> LoginDto {get; set;}





    }
}