using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServerCredentialSigning : Resource, IAuthorisationServerCredentialSigning
    {
        public string RotationMode
        {
            get => GetStringProperty("rotationMode");
            set => this["rotationMode"] = value;
        }
        
        public DateTimeOffset? LastRotated 
        { 
            get => GetDateTimeProperty("lastRotated");
            set => this["lastRotated"] = value;
        }
        
        public DateTimeOffset? NextRotation 
        { 
            get => GetDateTimeProperty("nextRotation");
            set => this["nextRotation"] = value;
        }
        
        public string Kid
        {
            get => GetStringProperty("kid");
            set => this["kid"] = value;
        }
    }
}