using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreWebApi
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
    public class TokenInputModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class TokenViewModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }

    [Authorize]
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        static List<User> _testUser = new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "cutsea110",
                Password = "p@ssw0rd",
            }
        };

        private JwtSecurityToken CreateJwtSecurityToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var token = new JwtSecurityToken(
                issuer: AppConfiguration.SiteUrl,
                audience: AppConfiguration.SiteUrl,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfiguration.SecretKey)),
                    SecurityAlgorithms.HmacSha256
                )
            );
            return token;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Token([FromBody]TokenInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var user = _testUser.First(_ => _.UserName == inputModel.UserName);
                if (user != null && user.Password == inputModel.Password)
                {
                    var token = CreateJwtSecurityToken(user);
                    return Ok(new TokenViewModel
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                    });
                }
            }
            return BadRequest();
        }

        [HttpGet("me")]
        public IActionResult Me()
        {
            var id = User.Claims.First(_ => _.Type == ClaimTypes.Sid).Value;
            var user = _testUser.First(_ => _.Id == id);
            return Ok(new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
            });
        }
    }
}
