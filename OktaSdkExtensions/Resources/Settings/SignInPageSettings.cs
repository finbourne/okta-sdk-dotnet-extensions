using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public class SignInPageSettings : Resource, ISignInPageSettings
    {
        public string SigninLabel 
        { 
            get => GetStringProperty("signinLabel");
            set => this["signinLabel"] = value;
        }
        public string UsernameLabel 
        { 
            get => GetStringProperty("usernameLabel");
            set => this["usernameLabel"] = value;
        }
        public string UsernameInlineLabel 
        { 
            get => GetStringProperty("usernameInlineLabel");
            set => this["usernameInlineLabel"] = value;
        }
        public string PasswordLabel 
        { 
            get => GetStringProperty("passwordLabel");
            set => this["passwordLabel"] = value;
        }
        public string PasswordInlineLabel 
        { 
            get => GetStringProperty("passwordInlineLabel");
            set => this["passwordInlineLabel"] = value;
        }
        public string ForgottenPasswordLabel 
        { 
            get => GetStringProperty("forgottenPasswordLabel");
            set => this["forgottenPasswordLabel"] = value;
        }
        public string ForgottenPasswordHref 
        { 
            get => GetStringProperty("forgottenPasswordHref");
            set => this["forgottenPasswordHref"] = value;
        }
        public string UnlockAccountLabel 
        { 
            get => GetStringProperty("unlockAccountLabel");
            set => this["unlockAccountLabel"] = value;
        }
        public string UnlockAccountHref 
        { 
            get => GetStringProperty("unlockAccountHref");
            set => this["unlockAccountHref"] = value;
        }
        public string OktaHelpLabel 
        { 
            get => GetStringProperty("oktaHelpLabel");
            set => this["oktaHelpLabel"] = value;
        }
        public string OktaHelpHref 
        { 
            get => GetStringProperty("oktaHelpHref");
            set => this["oktaHelpHref"] = value;
        }
        public string CustomLinkOneText 
        { 
            get => GetStringProperty("customLinkOneText");
            set => this["customLinkOneText"] = value;
        }
        public string CustomLinkOneHref 
        { 
            get => GetStringProperty("customLinkOneHref");
            set => this["customLinkOneHref"] = value;
        }
        public string CustomLinkTwoText 
        { 
            get => GetStringProperty("customLinkTwoText");
            set => this["customLinkTwoText"] = value;
        }
        public string CustomLinkTwoHref 
        { 
            get => GetStringProperty("customLinkTwoHref");
            set => this["customLinkTwoHref"] = value;
        }
        public string FooterHelpTitle 
        { 
            get => GetStringProperty("footerHelpTitle");
            set => this["footerHelpTitle"] = value;
        }
        public string RecoveryFlowPlaceholder 
        { 
            get => GetStringProperty("recoveryFlowPlaceholder");
            set => this["recoveryFlowPlaceholder"] = value;
        }
        public IDefaultOrgLoginPageSettings DefaultOrgLoginPageSettings 
        { 
            get => GetResourceProperty<DefaultOrgLoginPageSettings>("defaultOrgLoginPageSettings");
            set => this["defaultOrgLoginPageSettings"] = value;
        }
    }
}