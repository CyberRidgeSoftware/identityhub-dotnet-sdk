# IdentityHub SDK for .NET
**IdentityHub SDK for .NET** is a .NET SDK for CyberRidge Software's IdentityHub. The SDK is free and open source. It contains wrappers that facilitate developers to make IdentityHub API calls. The usage of the framework is governed by the terms and conditions of its [License](https://github.com/cyberridgesoftware/identityhub-dotnet-sdk/blob/master/LICENSE).
## 1.0.0 Changes
IdentityHub SDK for .NET 1.0 is the first release and contains wrappers for several IdentityHub APIs. The following are the highlights:
* ```IDHServiceCollectionExtensions``` class has an extension method ```AddIDHOpenIdAuthentication()``` to configure IdentityHub authentication in ASP.NET Core.
* ```IDHClaimsPrincipalExtensions``` class has an exntension method ```GetIDHUser()``` that returns an instance of ```IDHClaimsUser``` based on the available claims.
* ```IDHApiConsumer``` class offers generic methods that can be used to conveniently call IdentityHub APIs.
* ```IDHUsersApi``` class is a wrapper for /users APIs.
* ```IDHTenantsApi``` class is a wrapper for /tenants APIs.
## Packages
IdentityHub SDK has the following NuGet packages:
* [IdentityHubSdkAspNetCore](https://www.nuget.org/packages/IdentityHubSdkAspNetCore)
* [IdentityHubSdkWebAPI](https://www.nuget.org/packages/IdentityHubSdkWebAPI)
## Installation
Use ```dotnet add package``` command to install IdentityHub SDK for .NET packages:
```
dotnet add package IdentityHubSdkAspNetCore
dotnet add package IdentityHubSdkWebAPI
```
## Issues
If you find a bug in the library or you have an idea about a new feature, please try to search in the existing list of [issues](https://github.com/cyberridgesoftware/identityhub-dotnet-sdk/issues). If the bug or idea is not listed and addressed there, please [open a new issue](https://github.com/cyberridgesoftware/identityhub-dotnet-sdk/issues/new).
