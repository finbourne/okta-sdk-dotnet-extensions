using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public interface ILocaleSettings : IResource
    {
        string LocaleString { get; set; }
        Resource AvailableLocaleStrings { get; set; }
        bool? LocaleSetByUser { get; set; }
        IDictionary<string, string> GetAvailableLocaleStrings();
    }
}