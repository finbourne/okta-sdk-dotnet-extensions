using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public class CustomDomainCertificateSettings : Resource, ICustomDomainCertificateSettings
    {
        public string CustomDomain { 
            get => GetStringProperty("customDomain");
            set => this["customDomain"] = value;
        }

        public string Fingerprint { 
            get => GetStringProperty("fingerprint");
            set => this["fingerprint"] = value;
        }
        public string Subject { 
            get => GetStringProperty("subject");
            set => this["subject"] = value;
        }
        public DateTimeOffset? ExpirationTime { 
            get => GetDateTimeProperty("expirationTime");
            set => this["expirationTime"] = value;
        }

    }
}