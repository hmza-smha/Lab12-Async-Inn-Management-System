using Lab12_Async_Inn_Management_System.Models;
using Lab12_Async_Inn_Management_System.Models.DTOs;
using Lab12_Async_Inn_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;

        public UsersController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult> Login(LoginData data)
        {
            try
            {
                var result = await _user.Authenticate(data, this.ModelState);
                if (result == null)
                {
                    return BadRequest("Username or password is wrong!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(data);

        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO data)
        {
            try
            {
                await _user.Register(data, this.ModelState);
                if (ModelState.IsValid)
                {
                    return Ok("Registered done");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
