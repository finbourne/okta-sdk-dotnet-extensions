using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public class CustomDomainSettings : Resource, ICustomDomainSettings
    {
        public string CustomDomain { 
            get => GetStringProperty("customDomain");
            set => this["customDomain"] = value;
        }
        public string TxtRecord { 
            get => GetStringProperty("txtRecord");
            set => this["txtRecord"] = value;
        }
        public string TxtSubdomainRecord { 
            get => GetStringProperty("txtSubdomainRecord");
            set => this["txtSubdomainRecord"] = value;
        }
        public string ValidationStatus { 
            get => GetStringProperty("validationStatus");
            set => this["validationStatus"] = value;
        }
        public string OktaSubdomain { 
            get => GetStringProperty("oktaSubdomain");
            set => this["oktaSubdomain"] = value;
        }
        public string Cname { 
            get => GetStringProperty("cname");
            set => this["cname"] = value;
        }
    }
}