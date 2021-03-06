﻿using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>
            {
                new ApiResource("user_api", "user service"),
                new ApiResource("gateway_api", "gateway service"),
                new ApiResource("contact_api", "contact service"),
                new ApiResource("project_api", "project service")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
                {
                    new Client
                    {
                        ClientId = "android",
                        ClientSecrets = { new Secret("secret".Sha256()) },
                        RefreshTokenExpiration = TokenExpiration.Sliding,
                        AllowOfflineAccess =true,
                        RequireClientSecret = false,
                        AllowedGrantTypes = new List<string>{ "sms_auth_code"},
                        AlwaysIncludeUserClaimsInIdToken =true,
                        AllowedScopes = new List<string>
                        {
                            "gateway_api",
                            "contact_api",
                            "user_api",
                            "project_api",
                            IdentityServerConstants.StandardScopes.OfflineAccess,
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile
                        },
                    }
                };
        }

    }
}
