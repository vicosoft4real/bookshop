
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ponea.Homework.Bookshop.Application.Contracts.Persistence;
using Ponea.Homework.Bookshop.Persistence.Repository;

namespace Ponea.Homework.Bookshop.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public static class RegisterPersistence
    {

        /// <summary>
        /// Adds the persistence.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PoneaBookshopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BookShopAssignmentDb")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            services.AddScoped<IBookRepository, BookRepository>();

            return services;



        }
    }
}