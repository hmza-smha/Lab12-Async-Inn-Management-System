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
    public class RoomsController : ControllerBase
    {
        // all paths must exist in the controller, and its impementation in repo
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var rooms = await _room.GetRooms();
            return Ok(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            RoomDTO room = await _room.GetRoom(id);
            return Ok(room);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            var modifiedRoom = await _room.UpdateRoom(id, room);

            return Ok(modifiedRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "DistrictManager")]
        public async Task<ActionResult<Room>> PostRoom(RoomDTO room)
        {
            Room newRoom = await _room.Create(room);
            return Ok(newRoom);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "DistrictManager")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _room.Delete(id);

            return NoContent();
        }


        [HttpPost("{roomId}/Amenity/{amenityId}")]
        [Authorize(Roles = "DistrictManager,PropertyManager,Agent")]
        public async Task <ActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();
        }

        [HttpDelete("{roomId}/Amenity/{amenityId}")]
        [Authorize(Roles = "DistrictManager,PropertyManager,Agent")]
        public async Task<ActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmentityFromRoom(roomId, amenityId);
            return NoContent();
        }

        //private bool RoomExists(int id)
        //{
        //    return _context.Rooms.Any(e => e.Id == id);
        //}
    }
}
