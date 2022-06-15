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
        private RoleManager<ApplicationUser> _roleManager;

        public IdentityUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationUser> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public async Task<UserDTO> Authenticate(LoginData data, ModelStateDictionary modelState)
        {
            var user = await _userManager.FindByNameAsync(data.UserName);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, data.Password, false, false);

            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            modelState.AddModelError(string.Empty, "Invalid Login");
            return null;
        }

        public async Task<ApplicationUser> Register(RegisterUserDTO data, ModelStateDictionary modelState)
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
                //await _userManager.AddToRoleAsync(user, "DistrictManager");
                //await _userManager.AddToRoleAsync(user, "PropertyManager");
                //await _userManager.AddToRoleAsync(user, "Agent");
                return user;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    var errorKey =
                        error.Code.Contains("Password") ? nameof(data.Password) :
                        error.Code.Contains("Email") ? nameof(data.Email) :
                        error.Code.Contains("UserName") ? nameof(data.Username) :
                        "";
                    modelState.AddModelError(errorKey, error.Description);
                }
                return null;
            }


        }
    }
}
