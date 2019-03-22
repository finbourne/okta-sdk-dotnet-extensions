using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationPolicy : Resource, IOrganisationPolicy
    {
        public IOrganisationTokenLifetime TokenLifetime
        {
            get => GetResourceProperty<OrganisationTokenLifetime>("tokenLifetime");
            set => this["tokenLifetime"] = value;
        }
        
        public IOrganisationJitProvisioning JitProvisioning
        {
            get => GetResourceProperty<OrganisationJitProvisioning>("jitProvisioning");
            set => this["jitProvisioning"] = value;
        }

        public IOrganisationAccountRecovery AccountRecovery
        {
            get => GetResourceProperty<OrganisationAccountRecovery>("accountRecovery");
            set => this["accountRecovery"] = value;
        }

        public IOrganisationIdpSettings IdpSettings
        {
            get => GetResourceProperty<OrganisationIdpSettings>("idpSettings");
            set => this["idpSettings"] = value;
        }

        public IOrganisationVisibility Visibility
        {
            get => GetResourceProperty<OrganisationVisibility>("visibility");
            set => this["visibility"] = value;
        }
    }
}