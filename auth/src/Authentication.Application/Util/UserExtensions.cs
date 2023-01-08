using authentication.Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace authentication.Application.Util
{
    public static class UserExtensions
    {
        public static string GenerateToken(this User user,string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static void SetSalt(this User user,PasswordUtil passwordUtil) 
        {
            user.Salt = passwordUtil.GetPasswordHash(Guid.NewGuid().ToString());
        }
        public static void SetPassword(this User user,string password, PasswordUtil passwordUtil)
        {
            user.Password = passwordUtil.GetPasswordHash($"{password}{user.Salt}");
        }
    }
}
