using Lab12_Async_Inn_Management_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Authenticate(LoginData data, ModelStateDictionary modelState);
    }
}
