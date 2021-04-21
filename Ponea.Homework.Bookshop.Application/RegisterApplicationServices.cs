using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ponea.Homework.Bookshop.Application.Profile;

namespace Ponea.Homework.Bookshop.Application
{

    /// <summary>
    /// 
    /// </summary>
    public static class RegisterApplicationServices
    {
        /// <summary>
        /// Adds the application services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}