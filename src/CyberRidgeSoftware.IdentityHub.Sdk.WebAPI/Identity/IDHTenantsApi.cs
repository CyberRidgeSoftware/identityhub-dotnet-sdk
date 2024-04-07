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
    /// Represents a wrapper of the /tenants API of IdentityHub.
    /// </summary>
    public class IDHTenantsApi : IDHApiConsumer
    {
        /// <summary>
        /// Creates an instance of the <see cref="IDHTenantsApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="address">The root address of the APIs.</param>
        /// <exception cref="ArgumentNullException">If address or apiVersion, accessToken is empty or null.</exception>
        public IDHTenantsApi(string address, string apiVersion, string accessToken)
            : base(address, apiVersion, accessToken) { }


        /// <summary>
        /// Creates an instance of the <see cref="IDHTenantsApi"/> class.
        /// </summary>
        /// <param name="address">The root address of the APIs.</param> 
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If address or accessToken is empty or null.</exception>
        public IDHTenantsApi(string address, string accessToken)
        : base(address, accessToken) { }

        /// <summary>
        /// Creates an instance of the <see cref="IDHTenantsApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If accessToken is empty or null.</exception>
        public IDHTenantsApi(string accessToken)
        : base(accessToken) { }

        /// <summary>
        /// Gets a list of tenants as a JSON string.
        /// </summary>
        public async Task<string> GetTenantsAsStringAsync()
        {
            return await GetStringAsync("tenants");
        }

        /// <summary>
        /// Gets a tenant by tenant ID as a JSON string.
        /// </summary>
        /// <param name="id">The ID of the tenant.</param>
        /// <returns>Returns a JSON string.</returns>
        public async Task<string> GetTenantsByIdAsStringAsync(string id)
        {
            return await GetStringAsync("tenants", new Dictionary<string, string> {{ "id", id }});
        }

        /// <summary>
        /// Gets a list of tenants.
        /// </summary>
        /// <returns>Returns an array of <see cref="IDHTenant"/>.</returns>
        public async Task<IDHTenant[]> GetTenantsAsync()
        {
            var tenants = await GetArrayAsync<IDHTenant>("tenants");
            return tenants;
        }

        /// <summary>
        /// Gets a tenant by ID.
        /// </summary>
        /// <param name="id">The ID of the tenant.</param>
        /// <returns>Returns an instance of the <see cref="IDHTenant"/> class.</returns>
        public async Task<IDHTenant> GetTenantByIdAsync(string id)
        {
            return await GetAsync<IDHTenant>("tenants", new Dictionary<string, string> { { "id", id } });
        }
    }
}
