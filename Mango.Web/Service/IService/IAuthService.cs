using Mango.Web.Models;
using Mango.Web.Models.Dto;
using Microsoft.AspNetCore.Identity.Data;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequest);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto loginRequest);
        Task<ResponseDto?> AssingRoleAsync(RegistrationRequestDto loginRequest);

    }
}
