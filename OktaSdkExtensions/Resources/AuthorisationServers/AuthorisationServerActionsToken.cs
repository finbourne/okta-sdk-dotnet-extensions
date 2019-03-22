using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServerActionsToken : Resource, IAuthorisationServerActionsToken
    {
        public int? AccessTokenLifetimeMinutes 
        { 
            get => GetIntegerProperty("accessTokenLifetimeMinutes");
            set => this["accessTokenLifetimeMinutes"] = value;
        }
        
        public int? RefreshTokenLifetimeMinutes 
        { 
            get => GetIntegerProperty("refreshTokenLifetimeMinutes");
            set => this["refreshTokenLifetimeMinutes"] = value;
        }
        
        public int? RefreshTokenWindowMinutes 
        { 
            get => GetIntegerProperty("refreshTokenWindowMinutes");
            set => this["refreshTokenWindowMinutes"] = value;
        }
    }
}