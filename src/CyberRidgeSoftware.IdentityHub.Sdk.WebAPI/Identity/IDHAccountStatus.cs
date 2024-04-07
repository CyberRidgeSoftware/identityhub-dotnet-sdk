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
    /// Represents the status of a user or a tenant account.
    /// </summary>
    public enum IDHAccountStatus
    {
        /// <summary>
        /// Account is not activve.
        /// </summary>
        Inactive = 0,
        /// <summary>
        /// Account is active.
        /// </summary>
        Active = 1,
        /// <summary>
        /// Account is suspended.
        /// </summary>
        Suspended = 2,
        /// <summary>
        /// Account is closed.
        /// </summary>
        Closed = 3
    }
}
