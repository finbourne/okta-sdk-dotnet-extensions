using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationVisibilityHide : Resource, IOrganisationVisibilityHide
    {
        public bool? RememberMe
        {
            get => GetBooleanProperty("rememberMe");
            set => this["rememberMe"] = value;
        }
        
        public bool? LockedStatus
        {
            get => GetBooleanProperty("lockedStatus");
            set => this["lockedStatus"] = value;
        }
    }
}