using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Models.Domain;

namespace StudentManagement.Repositories
{
    public class  TokenHandler : ITokenHandler 
    {
        public IConfiguration _configuration { get; }
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName,user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname,user.LastName));
            claims.Add(new Claim(ClaimTypes.Email,user.EmailAddress));
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires : DateTime.Now.AddMinutes(15),
                signingCredentials : credentials
            );

            var JwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return JwtToken;
        }
    }
}