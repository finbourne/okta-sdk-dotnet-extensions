using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class OidcApplicationCredentialsOAuthClient : Resource, IOidcApplicationCredentialsOAuthClient
    {
        public string ClientId
        {
            get => GetStringProperty("client_id");
            set => this["client_id"] = value;
        }

        public bool? AutoKeyRotation
        {
            get => GetBooleanProperty("autoKeyRotation");
            set => this["autoKeyRotation"] = value;
        }

        public string TokenEndpointAuthMethod
        {
            get => GetStringProperty("token_endpoint_auth_method");
            set => this["token_endpoint_auth_method"] = value;
        }
    }
}