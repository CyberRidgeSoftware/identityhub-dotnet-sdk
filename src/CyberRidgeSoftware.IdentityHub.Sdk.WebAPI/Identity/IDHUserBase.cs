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

namespace CyberRidgeSoftware.IdentityHub.Sdk.WebAPI.Identity
{
    /// <summary>
    /// Represents the base class of a user.
    /// </summary>
    public abstract class IDHUserBase
    {
        /// <summary>
        /// Gets the unique of a user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the unique name of a user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets the email address of a user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets the first name of a user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets the last name of a user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Determines if a user's email address is verified or not.
        /// </summary>
        public bool IsEmailConfirmed { get; set; }
    }
}
