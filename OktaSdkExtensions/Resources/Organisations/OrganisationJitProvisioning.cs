using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationJitProvisioning : Resource, IOrganisationJitProvisioning
    {
        public bool? Enabled
        {
            get => GetBooleanProperty("enabled");
            set => this["enabled"] = value;
        }
    }
}