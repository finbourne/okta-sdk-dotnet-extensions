using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Tokens
{
    public class TokenEmbeddedUser : Resource, ITokenEmbeddedUser
    {
        public string Id
        {
            get => GetStringProperty("id");
            set => this["id"] = value;
        }

        public string DisplayName {
            get => GetStringProperty("displayName");
            set => this["displayName"] = value;
        }
        public string Login {
            get => GetStringProperty("login");
            set => this["login"] = value;
        }
        public string Role {
            get => GetStringProperty("role");
            set => this["role"] = value;
        }
    }
}