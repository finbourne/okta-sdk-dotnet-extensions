using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public interface ICustomDomainSettings : IResource
    {
        string CustomDomain { get; set; }
        string TxtRecord { get; set; }
        string TxtSubdomainRecord { get; set; }
        string ValidationStatus { get; set; }
        string OktaSubdomain { get; set; }
        string Cname { get; set; }
    }
}