using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CvApi.Data;
using CvApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CvDbContext context;
        private readonly JwtSettings jwtSettings;



        public UsersController(CvDbContext context, IOptions<JwtSettings> jwtSettings )
        {
            this.context = context;
            this.jwtSettings = jwtSettings.Value;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]UserBindingModel userBindingModel)
        {
            this.context.Users.Add(new AppliactionUser()
            {
                Username = userBindingModel.Username,
                Password = userBindingModel.Password,
                Email = userBindingModel.Email
            });

           await context.SaveChangesAsync();

            return this.Ok("some");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserBindingModel userBindingModel)
        {
            var userFromDb = await this.context.Users.FirstOrDefaultAsync(user => user.Username == userBindingModel.Username &&
            user.Password == userBindingModel.Password);

            if (userFromDb == null)
            {
                return this.BadRequest("Username or Password is invalid.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromDb.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return this.Ok(token);
        }
    }
}

