using System.Threading.Tasks;
using Domain.AppUser.Model;
using Domain.AppUser.Service;
using Entity;
using Entity.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            var isCorrect = await _userManager.CheckPasswordAsync(applicationUser, @"Qweqwerty@123");
            if (isCorrect)
            {
                return new ObjectResult("token");

            }
            else
            {
                return new ObjectResult(applicationUser.PasswordHash);

            }
            // return new UnauthorizedObjectResult("Unauthorized");
        }

    }
}