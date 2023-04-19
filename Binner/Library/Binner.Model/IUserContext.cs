﻿namespace Binner.Model
{
    public interface IUserContext
    {
        /// <summary>
        /// Email address
        /// </summary>
        string EmailAddress { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        string PhoneNumber { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        int UserId { get; set; }

        /// <summary>
        /// Organization Id
        /// </summary>
        int OrganizationId { get; set; }
    }
}