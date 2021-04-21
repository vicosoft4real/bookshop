using Microsoft.AspNetCore.Identity;

namespace Ponea.Homework.Bookshop.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}