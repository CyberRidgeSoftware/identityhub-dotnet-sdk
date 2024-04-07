/**********************************************************************************
 *  Copyright (c) CyberRidge Software (P) Ltd.
 *
 *  All rights reserved. This software and its documentation are confidential and
 *  proprietary to CyberRidge Software (P) Ltd. No part of the software or its
 *  documentation may be reproduced, modified, or disclosed without prior written
 *  consent from CyberRidge Software (P) Ltd.
 *
 *  CyberRidge Software (P) Ltd. retains all intellectual property rights to the
 *  code and any derivative works thereof. Unauthorized copying or reproduction
 *  of this code or any part thereof is strictly prohibited.
 *
 *  This software is provided "as is" without warranty of any kind, express or
 *  implied, including, but not limited to, the implied warranties of
 *  merchantability, fitness for a particular purpose, or non-infringement.
 *
 *  CyberRidge Software (P) Ltd. reserves the right to make changes to the software
 *  or its documentation at any time without notice.
 *
 *  This notice may not be removed or altered from any source distribution.
 **********************************************************************************/

using System;

namespace CyberRidgeSoftware.IdentityHub.Sdk.WebAPI.Identity
{
    /// <summary>
    /// Represents a IdentityHub tenant.
    /// </summary>
    public class IDHTenant : IDHTenant<string>
    { }

    /// <summary>
    /// Represents a IdentityHub tenant.
    /// </summary>
    public class IDHTenant<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets the unique ID of a tenant.
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Gets the unique name of a tenant.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets a friendly name of a tenant.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets the current status of a tenant.
        /// </summary>
        public IDHTenantStatus Status { get; set; }

        /// <summary>
        /// Gets the ID of a user who owns the tenant.
        /// </summary>
        public string OwnerUserId { get; set; }

        /// <summary>
        /// Gets the country of a tenant.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets the currency of a tenant.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets the system language of a tenant.
        /// </summary>
        public string SystemLanguage { get; set; }

        /// <summary>
        /// Gets the time zone of a tenant.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets the preferred date format of a tenant.
        /// </summary>
        public string DateFormat { get; set; }
    }
}
