using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12_Async_Inn_Management_System.Data;
using Lab12_Async_Inn_Management_System.Models;
using Lab12_Async_Inn_Management_System.Models.Interfaces;
using Lab12_Async_Inn_Management_System.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Lab12_Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            var aminities =  await _amenity.GetAmenities();
            return Ok(aminities);
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            var amenity = await _amenity.GetAmenity(id);
            return Ok(amenity);
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "DistrictManager")]
        public async Task<IActionResult> PutAmenity(int id, AmenityDTO amenity)
        {
            if (id != amenity.ID)
            {
                return BadRequest();
            }

            var modifiedAmenity = await _amenity.UpdateAmenity(id, amenity);
            return Ok(modifiedAmenity);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "DistrictManager")]
        public async Task<ActionResult<Amenity>> PostAmenity(AmenityDTO amenity)
        {
            var newAmenity = await _amenity.Create(amenity);
            return Ok(newAmenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "DistrictManager")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            await _amenity.Delete(id);
            return NoContent();
        }

        //private bool AmenityExists(int id)
        //{
        //    return _context.Amenities.Any(e => e.Id == id);
        //}
    }
}
