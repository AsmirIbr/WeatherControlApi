using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherControlApp.Models;

namespace WeatherControlApp.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase 
    {
        private readonly WeatherContext _context;

        public WeatherController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/weather
        [HttpGet]
        public ActionResult<IEnumerable<Weather>> GetWeather()
        {
            return _context.WeatherItems;
        }

        // GET: api/weather/n
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Weather> GetWeatherItem(int id)
        {
            var weatherItem = _context.WeatherItems.Find(id);

            if(weatherItem == null)
            {
                return NotFound();
            }

            return weatherItem;
        }

        //POST: api/weather
        [Authorize]
        [HttpPost]
        public ActionResult<Weather> PostWeatherItem(Weather weather)
        {
            _context.WeatherItems.Add(weather);
            _context.SaveChanges();

            return CreatedAtAction("GetWeatherItem", new Weather{Id = weather.Id}, weather);
        }

        //PUT: api/weather/n
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult PutWeatherItem(int id, Weather weather)
        {
            if(id != weather.Id){
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE: /api/Weather/n
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Weather> DeleteWeatherItem(int id)
        {
            var weatherItem = _context.WeatherItems.Find(id);
            if(weatherItem == null)
            {
                return NotFound();
            }

            _context.WeatherItems.Remove(weatherItem);
            _context.SaveChanges();

            return weatherItem;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> GetString()
        // {
        //     return new string[] {"this", "is", "hard", "coded"};
        // }
    }
}