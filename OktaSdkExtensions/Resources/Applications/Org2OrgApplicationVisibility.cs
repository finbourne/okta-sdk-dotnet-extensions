using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class Org2OrgApplicationVisibility : Resource, IOrg2OrgApplicationVisibility
    {
        /// <inheritdoc/>
        public bool? AutoSubmitToolbar 
        {
            get => GetBooleanProperty("autoSubmitToolbar");
            set => this["autoSubmitToolbar"] = value;
        }
        
        /// <inheritdoc/>
        public IApplicationVisibilityHide Hide 
        {
            get => GetResourceProperty<ApplicationVisibilityHide>("hide");
            set => this["hide"] = value;
        }
        
        public IOrg2OrgApplicationVisibilityAppLinks AppLinks 
        {
            get => GetResourceProperty<Org2OrgApplicationVisibilityAppLinks>("appLinks");
            set => this["appLinks"] = value;
        }
    }
}