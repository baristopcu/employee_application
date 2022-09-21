using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthenticationService.Business.Interfaces;
using AuthenticationService.Data.Entities;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Business.Services
{


    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly string _secretKey;
        public UserService(IGenericRepository<User> userRepository, string secretKey)
        {
            _userRepository = userRepository;
            _secretKey = secretKey; 
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await _userRepository.SingleOrDefaultAsync(x => x.Username == username && x.Password == password, i => i.Role);

            if (user == null)
                return string.Empty;

            string secretKey = _secretKey;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("user_id", user.Id.ToString()),
                    new Claim("role_name", user.Role.RoleName.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string strToken = "Bearer " + tokenHandler.WriteToken(token);

            return strToken;
        }

    }
}
