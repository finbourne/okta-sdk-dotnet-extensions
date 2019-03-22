using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationAccountRecovery : Resource, IOrganisationAccountRecovery
    {
        public bool? SmsPasswordReset
        {
            get => GetBooleanProperty("smsPasswordReset");
            set => this["smsPasswordReset"] = value;
        }
    }
}