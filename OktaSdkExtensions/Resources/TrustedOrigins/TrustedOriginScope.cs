using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.TrustedOrigins
{
    public class TrustedOriginScope : Resource, ITrustedOriginScope
    {
        public string Type
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
    }
}