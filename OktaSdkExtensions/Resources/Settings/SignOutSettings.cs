using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public class SignOutSettings : Resource, ISignOutSettings
    {
        public string SignOutPage 
        { 
            get => GetStringProperty("signOutPage");
            set => this["signOutPage"] = value;
        }
        public string SignOutPageUrl 
        { 
            get => GetStringProperty("signOutPageUrl");
            set => this["signOutPageUrl"] = value;
        }
    }
}