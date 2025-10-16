using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Management.Smo;
using SureLbraryAPI.Context;
using SureLbraryAPI.DTOs;
using SureLbraryAPI.Interfaces;
using SureLbraryAPI.Models;
using SureLbraryAPI.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User = SureLbraryAPI.Models.User;

namespace SureLbraryAPI.Repository
{
    public class AuthRepository(LibraryContext _context, IConfiguration configuration) : IAuthService
    {
        public async Task<ResponseDetails<ResponseLoginDTO>> LoginUserAsync(LoginUserDTO loginDetails)        
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDetails.Email);
                if (user is null)
                {
                    return ResponseDetails<ResponseLoginDTO>.Failed("Credentials are Invalid", "InCorrect Details", 400);
                }
                var passwordIsCorrect = BCrypt.Net.BCrypt.Verify(loginDetails.Password,user.Password);
                if (!passwordIsCorrect) 
                {
                    return ResponseDetails<ResponseLoginDTO>.Failed("Credentails are Invalid", "Incorrect Details",400);
                }
                string token = CreateToken(user);
                var response = new ResponseLoginDTO
                {
                    Id =user.Id,
                    Token=token
                };
               
                {
                    return ResponseDetails<ResponseLoginDTO>.Success(response, "Login was Successful", 200);
                }
            }
            catch (Exception ex)
            {
                return ResponseDetails<ResponseLoginDTO>.Failed("User unable to Login", ex.Message, ex.HResult);
            }
        }

        public async Task<ResponseDetails<GetUserDTO>> RegisterAsync(CreateUserDTO request)
        {
            try
            {
                var userAlreadyExists = await _context.Users.AnyAsync(u => u.Email == request.Email);
                if (userAlreadyExists)
                {
                    return ResponseDetails<GetUserDTO>.Failed("Registeration Unsuccessful","$User with Email{Email} already Exist",400);
                }
                var user = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
                    //Password = new PasswordHasher<User>()
                    //.HashPassword(user, request.Password)
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                var userDTO = new GetUserDTO
                {
                    Email = user.Email,
                    Name=user.Name,
                    MembershipCode = user.MembershipCode,
                };
                return ResponseDetails<GetUserDTO>.Success(userDTO,"Registeration Successful",200);
 
            }
            catch(Exception ex)  
            {
                return ResponseDetails<GetUserDTO>.Failed("An Exception was caught",ex.Message,ex.HResult);
            }
        }
        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:SigningKey")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }           
}
