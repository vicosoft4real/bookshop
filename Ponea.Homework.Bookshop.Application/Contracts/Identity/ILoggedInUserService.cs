namespace Ponea.Homework.Bookshop.Application.Contracts.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoggedInUserService
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; }
    }
}