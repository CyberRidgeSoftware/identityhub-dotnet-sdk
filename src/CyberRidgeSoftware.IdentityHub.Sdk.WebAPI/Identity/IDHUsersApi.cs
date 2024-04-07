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
using System.Threading.Tasks;

namespace CyberRidgeSoftware.IdentityHub.Sdk.WebAPI.Identity
{
    /// <summary>
    /// Represents a wrapper of the /users API of IdentityHub.
    /// </summary>
    public class IDHUsersApi : IDHApiConsumer
    {
        /// <summary>
        /// Creates an instance of the <see cref="IDHUsersApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="address">The root address of the APIs.</param>
        /// <exception cref="ArgumentNullException">If address or apiVersion, accessToken is empty or null.</exception>
        public IDHUsersApi(string address, string apiVersion, string accessToken)
            : base(address, apiVersion, accessToken) { }


        /// <summary>
        /// Creates an instance of the <see cref="IDHUsersApi"/> class.
        /// </summary>
        /// <param name="address">The root address of the APIs.</param> 
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If address or accessToken is empty or null.</exception>
        public IDHUsersApi(string address, string accessToken)
        : base(address, accessToken) { }

        /// <summary>
        /// Creates an instance of the <see cref="IDHUsersApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If accessToken is empty or null.</exception>
        public IDHUsersApi(string accessToken)
        : base(accessToken) { }

        /// <summary>
        /// Gets a list of users as a JSON string.
        /// </summary>
        /// <returns>Returns a JSON string.</returns>
        public async Task<string> GetUsersAsStringAsync()
        {
            return await GetStringAsync("users");
        }

        /// <summary>
        /// Gets a list of users.
        /// </summary>
        /// <returns>Returns an array of <see cref="IDHUser"/>.</returns>
        public async Task<IDHUser[]> GetUsersAsync()
        {
            var users = await GetArrayAsync<IDHUser>("users");
            return users;
        }

        /// <summary>
        /// Gets a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public async Task<IDHUser> GetUserByIdAsync(string id)
        {
            return await GetAsync<IDHUser>("users" , new Dictionary<string, string> { { "id", id } });
        }

        /// <summary>
        /// Gets a user by user ID as a JSON string.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>Returns a JSON string.</returns>
        public async Task<string> GetUserByIdAsStringAsync(string id)
        {
            return await GetStringAsync("users", new Dictionary<string, string> {{ "id", id }});
        }
    }
}
