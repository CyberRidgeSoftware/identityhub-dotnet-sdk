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
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CyberRidgeSoftware.IdentityHub.Sdk.WebAPI.Identity
{
    /// <summary>
    /// Contains a set of IdentityHub-specific extensions methods of <see cref="ClaimsPrincipal"/>.
    /// </summary>
    public static class IDHClaimsPrincipalExtensions
    {
        /// <summary>
        /// Creates an instance <see cref="IDHClaimsUser"/> based on a set of available claims.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns>Returns an instance of the <see cref="IDHClaimsUser"/> class.</returns>
        public static IDHClaimsUser GetIDHUser(this ClaimsPrincipal claimsPrincipal)
        {
            var claims = claimsPrincipal.Claims;

            if (claims == null || claims.Count() < 1)
            {
                return null;
            }

            var user = new IDHClaimsUser();

            var roles = new List<string>();

            foreach (var claim in claims)
            {
                switch (claim.Type)
                {
                    case "sub":
                        user.Id = claim.Value;
                        break;
                    case "preferred_username":
                        user.UserName = claim.Value;
                        break;
                    case "name":
                        user.Name = claim.Value;
                        break;
                    case "given_name":
                        user.FirstName = claim.Value;
                        break;
                    case "family_name":
                        user.LastName = claim.Value;
                        break;
                    case "email_verified":
                        user.IsEmailConfirmed = Convert.ToBoolean(claim.Value);
                        break;
                    case "email":
                        user.Email = claim.Value;
                        break;
                    case "role":
                        roles.Add(claim.Value);
                        break;
                    case "tenant":
                        user.Tenant = claim.Value;
                        break;
                }
            }

            user.Roles = roles.ToArray();
            return user;
        }
    }
}
