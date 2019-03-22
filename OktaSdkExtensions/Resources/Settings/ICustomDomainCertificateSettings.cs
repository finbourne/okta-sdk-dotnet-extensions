using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public interface ICustomDomainCertificateSettings : IResource
    {
        string CustomDomain { get; set; }
        string Fingerprint { get; set; }
        string Subject { get; set; }
        DateTimeOffset? ExpirationTime { get; set; }
    }
}