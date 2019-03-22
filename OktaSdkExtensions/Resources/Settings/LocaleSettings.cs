using System.Collections.Generic;
using System.Linq;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public class LocaleSettings : Resource, ILocaleSettings
    {
        public string LocaleString { 
            get => GetStringProperty("localeString");
            set => this["localeString"] = value;
        }
        public Resource AvailableLocaleStrings { 
            get => GetResourceProperty<Resource>("availableLocaleStrings");
            set => this["availableLocaleStrings"] = value;
        }
        public bool? LocaleSetByUser 
        { 
            get => GetBooleanProperty("localeSetByUser");
            set => this["localeSetByUser"] = value;
        }

        public IDictionary<string, string> GetAvailableLocaleStrings()
            => AvailableLocaleStrings?.GetData().ToDictionary(
                k => k.Key,
                v => v.Value as string);

    }
}