using System;
using System.Linq;
using Entity.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Entity.Seed
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AplicationContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AplicationUser>>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                AplicationUser user = new AplicationUser()
                {
                    Email = "mateuscod88@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "mateuscod"
                };
                userManager.CreateAsync(user, "Qweqwerty@123");
            }
        }
    }
}