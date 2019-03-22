using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class OidcApplicationSettingsOAuthClient : Resource, IOidcApplicationSettingsOAuthClient
    {
        public string ClientUri
        {
            get => GetStringProperty("client_uri");
            set => this["client_uri"] = value;
        }
        
        public string LogoUri
        {
            get => GetStringProperty("logo_uri");
            set => this["logo_uri"] = value;
        }
        
        public string InitiateLoginUri
        {
            get => GetStringProperty("initiate_login_uri");
            set => this["initiate_login_uri"] = value;
        }
        
        public IList<string> RedirectUris
        {
            get => GetArrayProperty<string>("redirect_uris");
            set => this["redirect_uris"] = value;
        }
        
        public IList<string> PostLogOutRedirectUris {
            get => GetArrayProperty<string>("post_logout_redirect_uris");
            set => this["post_logout_redirect_uris"] = value;
        }
        
        public IList<string> ResponseTypes {
            get => GetArrayProperty<string>("response_types");
            set => this["response_types"] = value;
        }
        
        public IList<string> GrantTypes {
            get => GetArrayProperty<string>("grant_types");
            set => this["grant_types"] = value;
        }
        
        public string ApplicationType
        {
            get => GetStringProperty("application_type");
            set => this["application_type"] = value;
        }
        
        public string TosUri
        {
            get => GetStringProperty("tos_uri");
            set => this["tos_uri"] = value;
        }
        
        public string PolicyUri
        {
            get => GetStringProperty("policy_uri");
            set => this["policy_uri"] = value;
        }
    }
}