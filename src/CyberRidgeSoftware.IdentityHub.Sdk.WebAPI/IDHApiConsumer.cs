﻿/**********************************************************************************
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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace CyberRidgeSoftware.IdentityHub.Sdk.WebAPI
{
    /// <summary>
    /// Represents the core IdentityHub API wrapper.
    /// </summary>
    public class IDHApiConsumer
    {
        private const string DEFAULT_API_VERSION = "v1";
        private const string DEFAULT_ADDRESS = "https://api.identityhub.cyberridge.io";
        /// <summary>
        /// Creates an instance of the <see cref="IDHApiConsumer"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="address">The root address of the APIs.</param>
        /// <exception cref="ArgumentNullException">If address or apiVersion, accessToken is empty or null.</exception>
        public IDHApiConsumer(string address, string apiVersion, string accessToken)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            if (string.IsNullOrEmpty(apiVersion))
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            this.Address = address;
            this.AccessToken = accessToken;
            this.ApiVersion = apiVersion;
        }

        /// <summary>
        /// Creates an instance of the <see cref="IDHApiConsumer"/> class.
        /// </summary>
        /// <param name="address">The root address of the APIs.</param> 
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If address or accessToken is empty or null.</exception>
        public IDHApiConsumer(string address, string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            this.Address = address;
            this.AccessToken = accessToken;
            this.ApiVersion = DEFAULT_API_VERSION;
        }

        /// <summary>
        /// Creates an instance of the <see cref="IDHApiConsumer"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If accessToken is empty or null.</exception>
        public IDHApiConsumer(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            this.Address = DEFAULT_ADDRESS;
            this.AccessToken = accessToken;
            this.ApiVersion = DEFAULT_API_VERSION;
        }

        /// <summary>
        /// Gets or sets the root address of the API.
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Gets or sets the API version. This value is appended to the API URI.
        /// </summary>
        protected string ApiVersion { get; private set; }

        /// <summary>
        /// Gets or sets the access token for API authorization.
        /// </summary>
        protected string AccessToken { get; private set; }

        /// <summary>
        /// Calls a IdentityHub API and returns an array of objects.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <returns>Returns API response as an array of the generic type of T.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        public async Task<T[]> GetArrayAsync<T>(string path)
        {
            var response = await GetStringAsync(path);
            var deserializedData = JsonConvert.DeserializeObject<IDHApiResponseArray<T>>(response);
            return deserializedData.Data;
        }

        /// <summary>
        /// Calls a IdentityHub API and returns an array of objects.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <param name="parameters">The set of parameters to be included in the API call.</param>
        /// <returns>Returns API response as an array of the generic type of T.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        public async Task<T[]> GetArrayAsync<T>(string path, Dictionary<string, string> parameters)
        {
            var response = await GetStringAsync(path, parameters);
            var deserializedData = JsonConvert.DeserializeObject<IDHApiResponseArray<T>>(response);
            return deserializedData.Data;
        }

        /// <summary>
        /// Calls a IdentityHub API and returns an object.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <param name="parameters">The set of parameters to be included in the API call.</param>
        /// <returns>Returns API response as an array of the generic type of T.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        public async Task<T> GetAsync<T>(string path, Dictionary<string, string> parameters)
        {
            var response = await GetStringAsync(path, parameters);
            var deserializedData = JsonConvert.DeserializeObject<IDHApiResponse<T>> (response);
            return deserializedData.Data;
        }

        /// <summary>
        /// Calls a IdentityHub API and returns an object.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <returns>Returns API response as an array of the generic type of T.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        public async Task<T> GetAsync<T>(string path)
        {
            var response = await GetStringAsync(path);
            var deserializedData = JsonConvert.DeserializeObject<T>(response);
            return deserializedData;
        }

        /// <summary>
        /// Calls a IdentityHub API and returns a string response.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <returns>Returns API response as a string.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        protected Task<string> GetStringAsync(string path)
        {
            return GetStringAsync(path, null);
        }

        /// <summary>
        /// Calls a IdentityHub API and returns a string response.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <param name="parameters">The set of parameters to be included in the API call.</param>
        /// <returns>Returns API response as a string.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        protected async Task<string> GetStringAsync(string path, Dictionary<string, string> parameters)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(AccessToken);

            var uri = new StringBuilder();
            uri.Append($"{Address}/{ApiVersion}");

            if (!path.StartsWith("/"))
            {
                uri.Append("/");
            }

            uri.Append(path);

            if (parameters != null && parameters.Count > 0)
            {
                if(!path.Contains("?"))
                {
                    uri.Append("?");
                }
                else
                {
                    if(!path.EndsWith("?"))
                    {
                        uri.Append("&");
                    }
                }

                foreach(var key in parameters.Keys)
                {
                    uri.Append($"{key}={parameters[key]}&");
                }
            }

            var response = await apiClient.GetAsync(uri.ToString());

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
