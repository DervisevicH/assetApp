using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AssetTracker_API.ViewModel;
using AssetTracket_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AssetTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private AssetsTrackerContext _db;
        IConfiguration _config;
        public AdministratorController(AssetsTrackerContext db, IConfiguration config) { _db = db; _config = config; }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginVM model)
        {
            var admin = _db.Administrator.Where(x => x.Username == model.Username && x.Password == model.Password).SingleOrDefault();
            if (admin != null)
            {
                var tokenString = GenerateJSONWebToken(admin);
                return Ok(new LoginResponse { token=tokenString, userId=admin.AdministratorId, username=admin.Username});
            }
            else
            {
                return Unauthorized();
            }
        }
        private string GenerateJSONWebToken(Administrator user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.AdministratorId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience:_config["Jwt:Audiance"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials                
                );
            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;

        }
    }
}