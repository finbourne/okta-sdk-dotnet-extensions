using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolSettings : Resource, IIdentityProviderProtocolSettings 
    {
        public string NameFormat
        {
            get => GetStringProperty("nameFormat");
            set => this["nameFormat"] = value;
        }
    }
}