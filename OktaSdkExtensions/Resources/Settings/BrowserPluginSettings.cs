using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public class BrowserPluginSettings : Resource, IBrowserPluginSettings
    {
        public bool? AdminManaged  
        { 
            get => GetBooleanProperty("adminManaged");
            set => this["adminManaged"] = value;
        }
        public string EnabledGroup  
        { 
            get => GetStringProperty("enabledGroup");
            set => this["enabledGroup"] = value;
        }
        public bool? PreventBrowserPasswordSave  
        { 
            get => GetBooleanProperty("preventBrowserPasswordSave");
            set => this["preventBrowserPasswordSave"] = value;
        }
        public bool? PreventBrowserOktaPasswordSave  
        { 
            get => GetBooleanProperty("preventBrowserOktaPasswordSave");
            set => this["preventBrowserOktaPasswordSave"] = value;
        }
        public bool? AntiPhishingEnabled  
        { 
            get => GetBooleanProperty("antiPhishingEnabled");
            set => this["antiPhishingEnabled"] = value;
        }
        public bool? AntiPhishingWhiteListedUrls  
        { 
            get => GetBooleanProperty("antiPhishingWhiteListedUrls");
            set => this["antiPhishingWhiteListedUrls"] = value;
        }
        public bool? WarningState  
        { 
            get => GetBooleanProperty("warningState");
            set => this["warningState"] = value;
        }
    }
}