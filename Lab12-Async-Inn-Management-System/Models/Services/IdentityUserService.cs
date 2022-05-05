using Lab12_Async_Inn_Management_System.Models.DTOs;
using Lab12_Async_Inn_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public IdentityUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserDTO> Authenticate(LoginData data)
        {
            var user = await _userManager.FindByNameAsync(data.UserName);

            if (user == null)
                throw new Exception("User does not exist in the database!");

            if(user.PasswordHash != data.Password)
                throw new Exception("Wrong Password!");

            await _signInManager.SignInAsync(user, isPersistent: false);

            return new UserDTO
            {
                Id = user.Id,
                Username = user.UserName
            };
        }

        public async Task<ApplicationUser> Register(RegisterUserDTO data)
        {
            //throw new NotImplementedException();

            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return user;
            }

            return null;

        }
    }
}
