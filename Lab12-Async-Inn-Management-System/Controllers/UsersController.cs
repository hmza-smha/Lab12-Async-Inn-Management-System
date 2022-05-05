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
        public Task<UserDTO> Login(LoginData data)
        {
            return _user.Authenticate(data);
        }

        [HttpPost("Register")]
        public Task<ApplicationUser> Register(RegisterUserDTO data)
        {
            return _user.Register(data);
        }
    }
}
