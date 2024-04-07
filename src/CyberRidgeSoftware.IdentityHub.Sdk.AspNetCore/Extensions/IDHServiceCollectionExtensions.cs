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

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace CyberRidgeSoftware.IdentityHub.Sdk.AspNetCore.Extensions
{
    /// <summary>
    /// Extension methods for setting up authentication services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class IDHServiceCollectionExtensions
    {
        private static string[] _scopes = { "email", "phone", "role", "tenant", "api" };

        /// <summary>
        /// Registers services required by authentication services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> parameter.</param>
        /// <param name="authority">The authority parameter. The default value is https://identityhub.cyberridge.io.</param>
        /// <param name="clientId">The client ID of the IdentityHub API service.</param>
        /// <param name="clientSecret">The client secret of the IdentityHub API service.</param>
        /// <param name="scopes">An array of scopes. If not provided then the default list of scopes will be used.</param>
        /// <param name="claimsFromUserInfoEndpoint">Determines if user info endpoint is used to retrieve additional claims. The default value is true.</param>
        /// <param name="defaultMapInboundClaims">Determines if the InboundClaimTypeMap is used.</param>
        /// <param name="piiInLogs">Determines if the PII is shown in logs.</param>
        /// <param name="openIdEvents">OpenId events.</param>
        /// <param name="cookieAuthenticationCookieEvents">Cookie authentication events.</param>
        /// <returns>Returns an instance of the <see cref="AuthenticationBuilder"/> class which can be used to further configure authentication.</returns>
        public static AuthenticationBuilder AddIDHOpenIdAuthentication(this IServiceCollection services, string clientId, string clientSecret, string authority = "https://identityhub.cyberridge.io", string[] scopes = null, bool claimsFromUserInfoEndpoint = true, bool defaultMapInboundClaims= false, bool piiInLogs = false, OpenIdConnectEvents openIdEvents = null, CookieAuthenticationEvents cookieAuthenticationCookieEvents = null)
        {
            if(string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if(string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }

            JwtSecurityTokenHandler.DefaultMapInboundClaims = defaultMapInboundClaims;
            IdentityModelEventSource.ShowPII = piiInLogs;

            return services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", options =>
            {
                if (cookieAuthenticationCookieEvents != null)
                {
                    options.Events = cookieAuthenticationCookieEvents;
                }
            })
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = authority;

                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.ResponseType = "code";

                options.SaveTokens = true;

                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                };

                if(openIdEvents != null)
                {
					options.Events = openIdEvents;
				}

				if (scopes == null)
                {
                    foreach (var scope in _scopes)
                    {
                        options.Scope.Add(scope);
                    }
                }
                else
                {
                    foreach (var scope in scopes)
                    {
                        options.Scope.Add(scope);
                    }
                }

                options.GetClaimsFromUserInfoEndpoint = claimsFromUserInfoEndpoint;
            });
        }

		/// <summary>
		/// Registers services required by authentication services.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection"/> parameter.</param>
		/// <param name="authority">The authority parameter. The default value is https://identityhub.cyberridge.io.</param>
        /// <param name="validateAudience">Determines if the audience will be validated during token validation.</param>
		/// <returns>Returns an instance of the <see cref="AuthenticationBuilder"/> class which can be used to further configure authentication.</returns>
		public static AuthenticationBuilder AddIDHBearerTokenAuthentication(this IServiceCollection services, string authority = "https://identityhub.cyberridge.io", bool validateAudience = false)
		{
			return services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = authority;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
		}

		/// <summary>
		/// Adds authorization policy services to <see cref="IServiceCollection"/> requiring API scope.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection"/> parameter.</param>
		/// <param name="policy">The name of the policy. The default value is ApiScope.</param>
		/// <returns>Returns an instance of the <see cref="IServiceCollection"/> class which can be used to further register more services.</returns>
		public static IServiceCollection AddIDHApiAuthorization(this IServiceCollection services, string policy = "ApiScope")
		{
			return services.AddAuthorization(options =>
			{
				options.AddPolicy(policy, policy =>
				{
					policy.RequireAuthenticatedUser();
					policy.RequireClaim("scope", "api");
				});
			});
		}
	}
}
