using System;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerCredentialSigning
    {
        string RotationMode { get; set; }
        DateTimeOffset? LastRotated { get; set; }
        DateTimeOffset? NextRotation { get; set; }
        string Kid { get; set; }
    }
}