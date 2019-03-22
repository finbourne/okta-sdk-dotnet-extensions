using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public interface ISignOutSettings: IResource
    {
        string SignOutPage { get; set; }
        string SignOutPageUrl { get; set; }
    }
}