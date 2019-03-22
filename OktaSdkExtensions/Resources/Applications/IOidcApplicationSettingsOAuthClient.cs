using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOidcApplicationSettingsOAuthClient : IResource
    {
        string ClientUri { get; set; }
        string LogoUri { get; set; }
        string InitiateLoginUri { get; set; }
        IList<string> RedirectUris { get; set; }
        IList<string> PostLogOutRedirectUris { get; set; }
        IList<string> ResponseTypes { get; set; }
        IList<string> GrantTypes { get; set; }
        
        
        string ApplicationType { get; set; }
        string TosUri { get; set; }
        string PolicyUri { get; set; }
    }
}