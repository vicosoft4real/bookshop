using System.Threading.Tasks;
using Ponea.Homework.Bookshop.Application.Models;

namespace Ponea.Homework.Bookshop.Application.Contracts.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates the asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        /// <summary>
        /// Registers the asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}