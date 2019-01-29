using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.AppUser.Model;
using Domain.AppUser.Service;
using Entity;
using Entity.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers

{
    [Route("api/[controller]/[action]")]
    public class LoginController
    {
        private readonly UserManager<AplicationUser> _userManager;
        public LoginController(UserManager<AplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Login([FromBody] AplicationUserModel aplicationUserModel)
        {
            var applicationUser = await _userManager.FindByNameAsync(aplicationUserModel.Login);
            var isCorrect = await _userManager.CheckPasswordAsync(applicationUser, aplicationUserModel.Password);
            if (isCorrect)
            {
                var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.Sub,applicationUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecureKeyKey"));
                var token = new JwtSecurityToken(
                    issuer: "http://oec.com",
                    audience: "http://oec.com",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                return new OkObjectResult(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    }
                );
            }
            else
            {
                return new UnauthorizedObjectResult("Unauthorized");

            }

        }

    }
}