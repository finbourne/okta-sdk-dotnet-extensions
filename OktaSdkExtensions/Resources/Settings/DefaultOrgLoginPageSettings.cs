using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public class DefaultOrgLoginPageSettings : Resource, IDefaultOrgLoginPageSettings
    {
        public string Locale  
        { 
            get => GetStringProperty("locale");
            set => this["locale"] = value;
        }
        public string DefaultForgottenPasswordHrefDisplay  
        { 
            get => GetStringProperty("defaultForgottenPasswordHrefDisplay");
            set => this["defaultForgottenPasswordHrefDisplay"] = value;
        }
        public string DefaultUnlockAccountHrefDisplay  
        { 
            get => GetStringProperty("defaultUnlockAccountHrefDisplay");
            set => this["defaultUnlockAccountHrefDisplay"] = value;
        }
        public string DefaultOktaHelpHrefDisplay  
        { 
            get => GetStringProperty("defaultOktaHelpHrefDisplay");
            set => this["defaultOktaHelpHrefDisplay"] = value;
        }
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
    }
}