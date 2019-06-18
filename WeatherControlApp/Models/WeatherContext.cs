using Microsoft.EntityFrameworkCore;

namespace WeatherControlApp.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) :base (options)
        {

        }

        public DbSet<Weather> WeatherItems {get; set;}
    }
}