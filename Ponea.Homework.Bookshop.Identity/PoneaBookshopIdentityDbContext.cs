using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ponea.Homework.Bookshop.Identity.Models;

namespace Ponea.Homework.Bookshop.Identity
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{Ponea.Homework.Bookshop.Identity.Models.ApplicationUser}</cref>
    /// </seealso>
    public class PoneaBookshopIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoneaBookshopIdentityDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public PoneaBookshopIdentityDbContext(DbContextOptions<PoneaBookshopIdentityDbContext> options) : base(options)
        {

        }
    }
}