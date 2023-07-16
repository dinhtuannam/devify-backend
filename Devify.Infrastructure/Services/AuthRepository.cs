using Devify.Entity;
using Microsoft.AspNetCore.Identity;
using Devify.Application.Interfaces;
using Devify.Infrastructure.Persistance;
using Devify.Application.DTO.RequestDTO;
using Devify.Application.DTO.ResponseDTO;

namespace Devify.Infrastructure.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ApplicationUser> Login(string name, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(name, password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(name);
                await _signInManager.SignInAsync(user, false);            
                return user;
            }
            return null;
        }
        public async Task<ApiResponse> Register(RegisterRequest model)
        {
            var validateResult = await ValidateRegister(model);
            if (validateResult.Success == false)
                return validateResult;
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.Phone
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var newUser = await _userManager.FindByEmailAsync(model.Email);

                await _userManager.AddToRoleAsync(newUser, "Customer");
                return new ApiResponse
                {
                    Success = true,
                    Message = "Register successfully",
                    Data = newUser
                };
            }
            else
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Username or password are not correct"
                };
            }
        }
        public async Task<ApiResponse> ValidateRegister(RegisterRequest model)
        {
            if (model.Username.Contains(" "))
                return new ApiResponse
                {
                    Success = false,
                    Message = "Username cannot have space character",
                };
            if (model.Password.Contains(" "))
                return new ApiResponse
                {
                    Success = false,
                    Message = "Password cannot have space character",
                };
            var checkUsernameUnique = await _userManager.FindByNameAsync(model.Username);
            if (checkUsernameUnique != null)
                return new ApiResponse
                {
                    Success = false,
                    Message = "Username already used",
                };
            if (model.Username.Contains(" "))
                return new ApiResponse
                {
                    Success = false,
                    Message = "Password cannot have space character",
                };
            if (!model.Password.Contains("@"))
                return new ApiResponse
                {
                    Success = false,
                    Message = "Password must contains @",
                };
            if (model.Password.Length < 8)
                return new ApiResponse
                {
                    Success = false,
                    Message = "Password must greater than 8 characters",
                };
            if (!model.Email.Contains("@"))
                return new ApiResponse
                {
                    Success = false,
                    Message = "Email must contains @",
                };

            return new ApiResponse
            {
                Success = true,
                Message = "Password must greater than 8 characters",
            };
        }
    }
}
