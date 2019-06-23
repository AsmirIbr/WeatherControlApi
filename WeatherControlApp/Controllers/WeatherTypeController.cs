using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherControlApp.Models;

namespace WeatherControlApp.Controllers
{
    [Route("api/weathertype")]
    [ApiController]
    public class WeatherTypeController : ControllerBase 
    {
        private readonly WeatherContext _context;

        public WeatherTypeController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/weathertype

        [HttpGet]
        public ActionResult<IEnumerable<WeatherType>> GetWeather()
        {
            return _context.WeatherType;
        }

        // GET: api/weathertype/n
        [HttpGet("{id}")]
        public ActionResult<WeatherType> GetWeatherType(int id)
        {
            var weatherType = _context.WeatherType.Find(id);

            if(weatherType == null)
            {
                return NotFound();
            }

            return weatherType;
        }

        //POST: api/weathertype
        [Authorize]
        [HttpPost]
        public ActionResult<Weather> PostWeatherType(WeatherType weatherType)
        {
            _context.WeatherType.Add(weatherType);
            _context.SaveChanges();

            return CreatedAtAction("GetWeatherType", new Weather{Id = weatherType.Id}, weatherType);
        }

        //PUT: api/weathertype/n
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult PutWeatherType(int id, WeatherType weatherType)
        {
            if(id != weatherType.Id){
                return BadRequest();
            }

            _context.Entry(weatherType).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE: /api/weathertype/n
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<WeatherType> DeleteWeatherType(int id)
        {
            var weatherType = _context.WeatherType.Find(id);
            if(weatherType == null)
            {
                return NotFound();
            }

            _context.WeatherType.Remove(weatherType);
            _context.SaveChanges();

            return weatherType;
        }

    }
}