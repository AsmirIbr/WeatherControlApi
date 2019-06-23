using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherControlApp.Models;

namespace WeatherControlApp.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase 
    {
        private readonly WeatherContext _context;

        public LocationController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/location
        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocation()
        {
            return _context.Location;
        }

        // GET: api/location/n
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Location> GetLocationItem(int id)
        {
            var locationItem = _context.Location.Find(id);

            if(locationItem == null)
            {
                return NotFound();
            }

            return locationItem;
        }

        //POST: api/location
        [Authorize]
        [HttpPost]
        public ActionResult<Location> PostLocationItem(Location location)
        {
            _context.Location.Add(location);
            _context.SaveChanges();

            return CreatedAtAction("GetWeatherItem", new Weather{Id = location.Id}, location);
        }

        //PUT: api/location/n
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult PutLocationItem(int id, Location location)
        {
            if(id != location.Id){
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE: /api/location/n
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Location> DeleteLocationItem(int id)
        {
            var locationItem = _context.Location.Find(id);
            if(locationItem == null)
            {
                return NotFound();
            }

            _context.Location.Remove(locationItem);
            _context.SaveChanges();

            return locationItem;
        }

    }
}