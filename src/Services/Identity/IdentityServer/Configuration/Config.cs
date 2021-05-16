// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Configuration
{
    public class Config
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("apiclient1.all"),
                new ApiScope("apiclient2.all"),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource(){
                    Name = "apiclient1",
                    DisplayName = "Api Client 1",
                    ApiSecrets = {new Secret("F7A3C0B1-4DD3-4582-B97F-95BE515C8988".Sha256()) },
                    Scopes = { "apiclient1.all" }
                },
                new ApiResource(){
                    Name = "apiclient2",
                    DisplayName = "Api Client 2",
                    ApiSecrets = {new Secret("C3E66AFE-BEA2-4FD3-9C5F-F521B93EF9E7".Sha256()) },
                    Scopes = { "apiclient2.all" }
                },

            };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl)
        {
            return new List<Client>
            {
                 new Client
                {
                    ClientId = "WebClient1",
                    ClientName = "Web Client 1",
                    ClientSecrets = { new Secret("8ED388A1-B278-4108-AA75-897B282B0BA0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AccessTokenType = AccessTokenType.Reference,

                    RedirectUris = { $"{clientsUrl["WebClient1"]}/signin-oidc" },
                    FrontChannelLogoutUri = $"{clientsUrl["WebClient1"]}/signout-oidc",
                    PostLogoutRedirectUris = { $"{clientsUrl["WebClient1"]}/signout-callback-oidc" },

                    RequirePkce=false,
                    AllowOfflineAccess = true,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apiclient1.all"
                     }
                },
                new Client
                {
                    ClientId = "WebClient2",
                    ClientName = "Web Client 2",
                    ClientSecrets = { new Secret("02721AA5-CC37-4EC4-A652-16C610663027".Sha256()) },

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AccessTokenType = AccessTokenType.Reference,

                    RedirectUris = { $"{clientsUrl["WebClient2"]}/signin-oidc" },
                    FrontChannelLogoutUri = $"{clientsUrl["WebClient2"]}/signout-oidc",
                    PostLogoutRedirectUris = { $"{clientsUrl["WebClient2"]}/signout-callback-oidc" },

                    RequirePkce=false,
                    AllowOfflineAccess = true,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apiclient2.all"
                     }
                },
               
            };
        }
    }
}
