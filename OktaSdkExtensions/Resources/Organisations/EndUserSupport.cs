using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class EndUserSupport : Resource, IEndUserSupport
    {
        public string PhoneNumber
        {
            get => GetStringProperty("phoneNumber");
            set => this["phoneNumber"] = value;
        }
    }
}