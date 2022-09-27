using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BackendAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private DataBaseContext data_context;
        public AuthenticateController(IConfiguration configuration, DataBaseContext data_context)
        {
            Configuration = configuration;
            this.data_context = data_context;
        }

        public IConfiguration Configuration { get; }

        public IActionResult Post()
        {

            var authorizationHeader = Request.Headers["Authorization"].First();
            var key = authorizationHeader.Split(' ')[1];
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(key)).Split(':');
            var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:ServerSecret"]));

            Users user = this.data_context.User.Where(u => u.Email == credentials[0] && u.Password == credentials[1]).FirstOrDefault();

            if (user != null)
            {
                var result = new
                {
                    token = GenerateToken(serverSecret, user)
                };
                return Ok(result);//status code
            }
            return BadRequest("Invalid Email/Password");//status code
        }

        private string GenerateToken(SecurityKey key, Users user)
        {
            var now = DateTime.UtcNow;
            var issuer = Configuration["JWT:Issuer"];
            var audience = Configuration["JWT:Audience"];
            var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                });
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(issuer, audience, identity,
            now, now.Add(TimeSpan.FromHours(100)), now, signingCredentials);
            var encodedJwt = handler.WriteToken(token);
            return encodedJwt;
        }
    }
}
