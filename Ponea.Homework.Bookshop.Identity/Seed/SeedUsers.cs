using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Ponea.Homework.Bookshop.Identity.Models;

namespace Ponea.Homework.Bookshop.Identity.Seed
{
    /// <summary>
    /// 
    /// </summary>
    public static class SeedUsers
    {
        /// <summary>
        /// Seeds the asynchronous.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "Victor",
                LastName = "Oluwayemi",
                UserName = "vicosoft",
                Email = "vicosoft4real@gmail.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "P@ssw0rd123");
            }
        }
    }
}