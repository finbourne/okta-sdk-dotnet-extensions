using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public interface IDefaultApplicationSettings : IResource
    {
        bool? DefaultApplicationSpecified { get; set; }
        string DefaultApplicationURI { get; set; }
    }
}