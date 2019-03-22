using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationTokenLifetime : Resource, IOrganisationTokenLifetime
    {
        public int? IdleSession
        {
            get => GetIntegerProperty("idleSession");
            set => this["idleSession"] = value;
        }

        public int? Activation
        {
            get => GetIntegerProperty("activation");
            set => this["activation"] = value;
        }
    }
}