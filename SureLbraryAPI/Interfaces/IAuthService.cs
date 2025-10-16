using SureLbraryAPI.DTOs;
using SureLbraryAPI.Models;
using SureLbraryAPI.Utilities;

namespace SureLbraryAPI.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDetails<GetUserDTO>> RegisterAsync(CreateUserDTO request);
        Task<ResponseDetails<ResponseLoginDTO>> LoginUserAsync(LoginUserDTO request);
    }
}
