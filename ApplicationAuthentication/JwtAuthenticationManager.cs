using ApplicationAuthentication.Abstraction;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAuthentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key = default;
        public IRepository<User> _usersRepository = default;
        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }


        public async Task<Tuple<string,int>> AuthenticateAsync(UserAuthDto data)
        {
            var user = (await _usersRepository.ReadAsync()).FirstOrDefault(o => o.UserName == data.UserName && o.Password == data.Password);
            if (user == null) { return null; }

            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,data.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tuple<string, int>(tokenHandler.WriteToken(token), user.Id);
        }

        public void SetUserRepo(IRepository<User> usersRepo)
        {
            _usersRepository = usersRepo;
        }
    }
}
