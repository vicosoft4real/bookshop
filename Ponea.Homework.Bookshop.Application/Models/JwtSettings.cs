﻿namespace Ponea.Homework.Bookshop.Application.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets the issuer.
        /// </summary>
        /// <value>
        /// The issuer.
        /// </value>
        public string Issuer { get; set; }
        /// <summary>
        /// Gets or sets the audience.
        /// </summary>
        /// <value>
        /// The audience.
        /// </value>
        public string Audience { get; set; }
        /// <summary>
        /// Gets or sets the duration in minutes.
        /// </summary>
        /// <value>
        /// The duration in minutes.
        /// </value>
        public double DurationInMinutes { get; set; }
    }
}