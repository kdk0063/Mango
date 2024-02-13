using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace Mango.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        //implment helper functions by dependency injection
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUsers> _userManger;
        private readonly RoleManager<IdentityRole> _roleManger;

        //dependency injection 
        public AuthService(AppDbContext db,
            UserManager<ApplicationUsers> userManager,
            RoleManager<IdentityRole> roleManger)
        {
            _db = db;
            _userManger = userManager;
            _roleManger = roleManger;
        }


        public async Task<string> Register(registrationRequestDto registrationRequestDto) 
        {
            ApplicationUsers user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber,
            };

            try
            {
                var result = await _userManger.CreateAsync(user, registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);
                    
                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception ex) 
            {
               
            }

            return "Error encountered";
        }

        public Task<LoginRequestDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

    }
}
