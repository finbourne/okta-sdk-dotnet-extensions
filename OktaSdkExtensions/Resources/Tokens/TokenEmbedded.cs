using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Tokens
{
    public class TokenEmbedded : Resource, ITokenEmbedded
    {
        public ITokenEmbeddedUser User
        {
            get => GetResourceProperty<TokenEmbeddedUser>("user");
            set => this["user"] = value;
        }
    }
}